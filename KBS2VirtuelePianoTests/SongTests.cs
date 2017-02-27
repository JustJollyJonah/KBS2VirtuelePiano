using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2VirtuelePiano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;

namespace KBS2VirtuelePiano.Tests
{
    [TestClass()]
    public class SongTests
    {
        [TestMethod()]
        public void Song_GetXPerMeasure_WhenTimeSignatureIs_4_4_ShouldReturnFULL()
        {
            // Arrange
            Song s = new Song(4, 4);

            // Act
            int xPerMeasure = s.GetXPerMeasure();

            // Assert
            Assert.AreEqual((int)ComponentLength.FULL, xPerMeasure);
        }

        [TestMethod()]
        public void Song_GetXPerMeasure_WhenTimeSignatureIs_4_2_ShouldReturnTwoFULL()
        {
            // Arrange
            Song s = new Song(4, 2);

            // Act
            int xPerMeasure = s.GetXPerMeasure();

            // Assert
            Assert.AreEqual(2 * (int)ComponentLength.FULL, xPerMeasure);
        }

        [TestMethod()]
        public void Song_GetXPerMeasure_WhenTimeSignatureIs_1_1_ShouldReturnFULL()
        {
            // Arrange
            Song s = new Song(1, 1);

            // Act
            int xPerMeasure = s.GetXPerMeasure();

            // Assert
            Assert.AreEqual((int)ComponentLength.FULL, xPerMeasure);
        }

        [TestMethod()]
        public void Song_GetMillisecondsPerX_WhenTimeSignatureIs_4_4_ShouldReturn_62_5()
        {
            // Arrange
            Song s = new Song(4, 4);

            // Act
            double msPerX = s.GetMillisecondsPerX(60); // TODO: bpm

            // Assert
            Assert.AreEqual(125, msPerX, 0.001);
        }

        [TestMethod()]
        public void Song_GetMillisecondsPerX_WhenTimeSignatureIs_4_2_ShouldReturn_31_25()
        {
            // Arrange
            Song s = new Song(4, 2);

            // Act
            double msPerX = s.GetMillisecondsPerX(60); // TODO: bpm

            // Assert
            Assert.AreEqual(62.5, msPerX, 0.001);
        }

        [TestMethod()]
        public void GetSongComponentsAtXTest_ShouldReturnListWithOneNote()
        {
            //Arrange
            List<SongComponent> songComponentAtX = new List<SongComponent>();
            Measure m1 = new Measure();
            Measure m2 = new Measure();
            Song song = new Song();
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1 * (int)ComponentLength.QUARTER));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2 * (int)ComponentLength.QUARTER));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));
            song.Measures.Add(m1);
            song.Measures.Add(m2);
            //Act
            songComponentAtX = song.GetSongComponentsAtX(0);

            //Assert
            Assert.AreEqual(1, songComponentAtX.Count);
        }

        [TestMethod()]
        public void GetSongComponentsAtXTest_ShouldReturnListWithTwoNotes()
        {
            //Arrange
            List<SongComponent> songComponentAtX = new List<SongComponent>();
            Measure m1 = new Measure();
            Measure m2 = new Measure();
            Song song = new Song();
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2 * (int)ComponentLength.QUARTER));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));
            song.Measures.Add(m1);
            song.Measures.Add(m2);
            //Act
            songComponentAtX = song.GetSongComponentsAtX(0);

            //Assert
            Assert.AreEqual(2, songComponentAtX.Count);
        }

        [TestMethod()]
        public void GetSongCompnentsAtXTest_ShouldReturnEmptyList()
        {
            //Arrange
            List<SongComponent> songComponentAtX = new List<SongComponent>();
            Measure m1 = new Measure();
            Measure m2 = new Measure();
            Song song = new Song();
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2 * (int)ComponentLength.QUARTER));
            m1.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2 * (int)ComponentLength.QUARTER));
            m2.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));
            song.Measures.Add(m1);
            song.Measures.Add(m2);
            //Act
            songComponentAtX = song.GetSongComponentsAtX(0);

            //Assert
            Assert.AreEqual(0, songComponentAtX.Count);
        }
    }
}