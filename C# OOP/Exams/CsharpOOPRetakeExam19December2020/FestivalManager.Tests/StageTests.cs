// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

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

        }
    }
}