using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId.HasValue &&
                            a.ProducerId.Value == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            s.Name,
                            Price = s.Price.ToString("f2"),
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToArray(),
                    AlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");

                sb.AppendLine("-Songs:");
                int count = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{count++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songsInfo = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToList(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray();

            int songCounter = 1;
            foreach (var song in songsInfo)
            {
                sb.AppendLine($"-Song #{songCounter++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                if (song.Performers.Count > 0)
                    song.Performers.ForEach(p => sb.AppendLine($"---Performer: {p}"));

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
