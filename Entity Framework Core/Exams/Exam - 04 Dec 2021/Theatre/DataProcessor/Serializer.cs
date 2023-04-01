using Newtonsoft.Json;

namespace Theatre.DataProcessor
{

    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                        .Sum(x => x.Price),
                    Tickets = t.Tickets
                        .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                        .Select(x => new
                        {
                            x.Price,
                            x.RowNumber
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            throw new NotImplementedException();
        }
    }
}
