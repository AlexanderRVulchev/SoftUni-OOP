// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities; // should be removed for Judge
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private const string DEF_SONG_NAME = "Song";
        private TimeSpan DEF_SONG_DURATION = new TimeSpan(0, 2, 18);
        private const string DEF_PERFORMER_FIRSTNAME = "First name";
        private const string DEF_PERFORMER_LASTNAME = "Last name";
        private const int DEF_PERFORMER_AGE = 25;


        private Song song;
        private Performer performer;
        private Stage stage;

        [SetUp]
        public void Setup()
        {
            song = new Song(DEF_SONG_NAME, DEF_SONG_DURATION);
            performer = new Performer(DEF_PERFORMER_FIRSTNAME, DEF_PERFORMER_LASTNAME, DEF_PERFORMER_AGE);
            stage = new Stage();
            stage.AddPerformer(performer);
            stage.AddSong(song);
        }

        [Test]
        public void ValidateNullValue_TestingMethodsWithNullArguments()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, DEF_PERFORMER_FIRSTNAME));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(DEF_SONG_NAME, null));
        }


        [Test]
        public void AddPerformer_AddsAPerformerToTheCollection()
        {
            Assert.AreEqual(stage.Performers.Count, 1);
            Assert.AreSame(stage.Performers.First(), performer);
        }

        [Test]
        public void AddPerformer_ThrowsForPerformerUnder18()
        {
            TestDelegate action = () => stage.AddPerformer(new Performer(DEF_PERFORMER_FIRSTNAME, DEF_PERFORMER_LASTNAME, 17));
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void AddSong_ThrowsForDurationUnder1Minute()
        {
            TimeSpan duration = new TimeSpan(0, 0, 15);
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("Short song", duration)));
        }

        [Test]
        public void AddSongToPerformer_ReturnsCorrectString()
        {
            string expectedOutput = $"{song} will be performed by {performer}";
            Assert.AreEqual(stage.AddSongToPerformer(song.Name, performer.FullName), expectedOutput);
        }
        
        [Test]
        public void Play_ReturnsCorrectString()
        {            
            stage.AddSongToPerformer(song.Name, performer.FullName);            
            string expectedOutput = $"1 performers played 1 songs";
            Assert.AreEqual(stage.Play(), expectedOutput);
        }
    }
}