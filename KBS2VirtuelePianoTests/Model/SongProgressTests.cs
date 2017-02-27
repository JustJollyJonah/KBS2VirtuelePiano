using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2VirtuelePiano.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KBS2VirtuelePiano.Model.Tests
{
    [TestClass()]
    public class SongProgressTests
    {
        [TestMethod()]
        public void SongProgress_Register()
        {
            // Arrange
            SongPlayer player = new SongPlayer(null, null);
            player.CurrentSong.AutoGenerate();
            player.ToggleSound();
            SongProgress prog = new SongProgress(player);

            // Start "playing" the song
            player.Start();
            Thread.Sleep(800);
            player.Tick();

            // Assert validity of unit test
            Assert.IsTrue(player.currentNotes.Count > 0);

            // Play one note correctly
            Note first = player.currentNotes.First();
            prog.Register(new PianoButton(
                first.Octave,
                first.Letter + (first.Black ? "#" : "")
            ));

            // Assert
            Assert.AreEqual(1, prog.HitCount);
        }

        [TestMethod()]
        public void SongProgress_GetMaximumScore()
        {
            // Arrange
            SongPlayer player = new SongPlayer(null, null);
            player.CurrentSong.AutoGenerate();
            player.ToggleSound();
            SongProgress prog = new SongProgress(player);

            // Act
            int max = prog.GetMaximumScore();

            // Assert
            Assert.AreEqual(
                Piano.OCTAVEN * 7,
                max
            );
        }

        [TestMethod()]
        public void SongProgress_GetResultingScore()
        {
            // Arrange
            SongPlayer player = new SongPlayer(null, null);
            player.CurrentSong.AutoGenerate();
            player.ToggleSound();
            SongProgress prog = new SongProgress(player);

            // Start playing
            player.Start();
            Thread.Sleep(800);
            player.Tick();

            // Assert validity of unit test
            Assert.IsTrue(player.currentNotes.Count > 0);
            
            // Play first note correctly
            Note first = player.currentNotes.First();
            prog.Register(new PianoButton(
                first.Octave,
                first.Letter + (first.Black ? "#" : "")
            ));

            // Act
            int max = prog.GetMaximumScore();
            int score = prog.HitCount;

            // Expected resulting score is 1 / max
            Assert.AreEqual(
                ((double)prog.HitCount) / (double)max,
                (double)prog.GetResultingScore(),
                0.00001d
            );
        }


    }
}