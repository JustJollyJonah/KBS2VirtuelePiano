using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2VirtuelePiano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS2VirtuelePiano.View;

namespace KBS2VirtuelePiano.Tests
{
    /*
    [TestClass()]
    public class PanelSongTests
    {
        PanelSong panelSong = new PanelSong();

        
        [TestMethod()]
        public void ToggleSound_ShouldChangeSoundEnableToFalse()
        {
            // arrange
            bool before = panelSong.SoundEnabled;

            // Act
            panelSong.ToggleSound();
            bool after = panelSong.SoundEnabled;

            // Assert
            Assert.IsFalse(after);
        }

        [TestMethod()]
        public void ToggleSound_ShouldChangeSoundEnableToTrue()
        {
            // arrange
            bool before = panelSong.SoundEnabled;

            // Act
            panelSong.ToggleSound();
            panelSong.ToggleSound();
            bool after = panelSong.SoundEnabled;

            // Assert
            Assert.IsTrue(after);
        }

        [TestMethod()]
        public void ToggleSound_ShouldChangeAmplitudeTo0()
        {
            // arrange
            float before = panelSong.sineWaveProvider.Amplitude;

            // Act
            panelSong.ToggleSound();
            
            float after = panelSong.sineWaveProvider.Amplitude;
            float expected = 0f;
          
            // Assert
            Assert.AreEqual(expected,after,"Is niet veranderd naar 0");
        }

        [TestMethod()]
        public void ToggleSound_ShouldChangeAmplitudeToSTandardState()
        {
            // arrange
            float before = panelSong.sineWaveProvider.Amplitude;

            // Act
            panelSong.ToggleSound();
            panelSong.ToggleSound();

            float after = panelSong.sineWaveProvider.Amplitude;
            float expected = 0.25f;
           
            // Assert
            Assert.AreEqual(expected, after, "Is niet veranderd naar 0");
        }

        [TestMethod()]
        public void ToggleNoteLength_ShouldChangeRenderNoteLenghtToTrue()
        {
            // arrange
            bool before = panelSong.RenderNoteLength;

            // Act
            panelSong.ToggleNoteLength();
            bool after = panelSong.RenderNoteLength;

            // Assert
            Assert.IsTrue(after);
        }

        [TestMethod()]
        public void ToggleNoteLength_ShouldChangeRenderNoteLenghtToFalse()
        {
            // arrange
            panelSong.RenderNoteLength = true;

            // Act
            panelSong.ToggleNoteLength();

            // Assert
            Assert.IsFalse(panelSong.RenderNoteLength);
        }

        [TestMethod()]
        public void PlayNoteTest_ShouldReturnTrue()
        {

        }
    }*/
}