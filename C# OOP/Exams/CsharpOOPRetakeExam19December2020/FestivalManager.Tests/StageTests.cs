// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
        }

        [Test]
        public void TestConstructor_ValidData()
        {
            Assert.AreEqual(0, stage.Performers.Count);
        }
        [Test]
        public void PerformesMethod_ShouldAddPerformers_ValidData()
        {
            var performer1 = new Performer("Mitko", "Dimitrow", 21);
            var performer2 = new Performer("Goshko", "Goshkow", 22);
            var performer3 = new Performer("Iwan", "Iwanow", 23);

            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddPerformer(performer3);

            List<Performer> performers = new List<Performer>();
            performers.Add(performer1);
            performers.Add(performer2);
            performers.Add(performer3);

            var collection = stage.Performers;

            Assert.AreEqual(3, collection.Count);
            CollectionAssert.AreEqual(performers.AsReadOnly(), collection);
        }
        [Test]
        public void PerformesMethod_ShouldThrowException_InvalidYears()
        {
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Blago", "Blagow", 15)));
        }
        [Test]
        public void PerformesMethod_ShouldThrowException_InvalidPerformer()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }
        [Test]
        public void PerformerProp_ShouldReturnReadOnly()
        {
            var performer1 = new Performer("Mitko", "Dimitrow", 21);
            var performer2 = new Performer("Goshko", "Goshkow", 22);
            var performer3 = new Performer("Iwan", "Iwanow", 23);

            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddPerformer(performer3);

            List<Performer> performers = new List<Performer>();
            performers.Add(performer1);
            performers.Add(performer2);
            performers.Add(performer3);

            var collection = stage.Performers;

            Assert.True(collection is IReadOnlyCollection<Performer>);
            CollectionAssert.AreEqual(performers.AsReadOnly(), collection);
        }
        [Test]
        public void AddSongMethod_ShouldAddSong_ValidData()
        {
            var song1 = new Song("retro", new TimeSpan(0, 3, 30));
            var song2 = new Song("Rok", new TimeSpan(0, 3, 30));
            var song3 = new Song("DujdWali", new TimeSpan(0, 3, 30));

            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSong(song3);
        }
        [Test]
        public void AddSongMethod_ShouldThrowException_InvalidMins()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("Rok", new TimeSpan(0, 0, 30))));
        }
        [Test]
        public void AddSongMethod_ShouldThrowException_InvalidSong()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }
        [Test]
        public void AddSongToPerformer_ShouldThrowException_InvalidSong()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Iwan"));
        }
        [Test]
        public void AddSongToPerformer_ShouldThrowException_InvalidPerformer()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Sonata", null));
        }
        [Test]
        public void AddSongToPerformer_ShouldAddSongToThePerformer_ValidData()
        {
            var performer1 = new Performer("Mitko", "Dimitrow", 21);
            var performer2 = new Performer("Goshko", "Goshkow", 22);
            var song = new Song("retro", new TimeSpan(0, 3, 30));
            var song2 = new Song("nowo retro", new TimeSpan(0, 3, 31));

            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSong(song);
            stage.AddSong(song2);

            var returnedString = stage.AddSongToPerformer(song.Name, performer1.FullName);
            var returnedString2 = stage.AddSongToPerformer(song2.Name, performer1.FullName);
            var expectedString = $"{song.Name} ({song.Duration:mm\\:ss}) will be performed by {performer1.FullName}";
            var expectedString2 = $"{song2.Name} ({song2.Duration:mm\\:ss}) will be performed by {performer1.FullName}";

            var performerSongList = stage.Performers.FirstOrDefault(x => x.FullName == performer1.FullName).SongList;
            var expectedSongList = new List<Song>()
            {
                song,
                song2
            };

            Assert.AreEqual(expectedString, returnedString);
            Assert.AreEqual(expectedString2, returnedString2);
            CollectionAssert.AreEqual(expectedSongList, performerSongList);
        }
        [Test]
        public void AddSongToPerformer_ShouldThrowException_PerformerDoesNotExists()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Sonata", "Sasho"), "There is no performer with this name.");
        }
        [Test]
        public void AddSongToPerformer_ShouldThrowException_SongDoesNotExists()
        {
            var performer1 = new Performer("Mitko", "Dimitrow", 21);
            stage.AddPerformer(performer1);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Sonata", "Mitko"), "There is no song with this name.");
        }
        [Test]
        public void PlayMethod_ShouldPlayAllSongs_ValidData()
        {
            var performer1 = new Performer("Mitko", "Dimitrow", 21);
            var performer2 = new Performer("Goshko", "Goshkow", 22);
            var song = new Song("retro", new TimeSpan(0, 3, 30));
            var song2 = new Song("nowo retro", new TimeSpan(0, 3, 31));
            var song3 = new Song("staro retro", new TimeSpan(0, 3, 31));
            var song4 = new Song("hubawo retro", new TimeSpan(0, 3, 31));

            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSong(song);
            stage.AddSong(song2);
            stage.AddSong(song3);
            stage.AddSong(song4);

            stage.AddSongToPerformer(song.Name, performer1.FullName);
            stage.AddSongToPerformer(song2.Name, performer1.FullName);
            stage.AddSongToPerformer(song3.Name, performer1.FullName);

            stage.AddSongToPerformer(song3.Name, performer2.FullName);
            stage.AddSongToPerformer(song4.Name, performer2.FullName);

            var returnedResult = stage.Play();
            var expectedReuslt = $"{stage.Performers.Count} performers played 5 songs";

            Assert.AreEqual(expectedReuslt, returnedResult);
        }
    }
}