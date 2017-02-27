using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2VirtuelePiano.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Model.Tests
{
    [TestClass()]
    public class NoteTests
    {
        [TestMethod()]
        public void Note_GetLocalKeyNumberFromC()
        {
            // Arrange
            Note n = new Note(NoteLetter.C, 4, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(0, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromCSharp()
        {
            // Arrange
            Note n = new Note(NoteLetter.C, 4, true, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(1, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromE()
        {
            // Arrange
            Note n = new Note(NoteLetter.E, 4, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(4, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromD()
        {
            // Arrange
            Note n = new Note(NoteLetter.D, 4, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(2, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromDSharp()
        {
            // Arrange
            Note n = new Note(NoteLetter.D, 4, true, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(3, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromB()
        {
            // Arrange
            Note n = new Note(NoteLetter.B, 4, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(11, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromBSharp()
        {
            // Arrange
            Note n = new Note(NoteLetter.B, 4, true, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(12, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromA()
        {
            // Arrange
            Note n = new Note(NoteLetter.A, 4, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(9, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromASharp()
        {
            // Arrange
            Note n = new Note(NoteLetter.A, 4, true, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(10, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromG()
        {
            // Arrange
            Note n = new Note(NoteLetter.G, 4, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(7, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromGSharp()
        {
            // Arrange
            Note n = new Note(NoteLetter.G, 4, true, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(8, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromF()
        {
            // Arrange
            Note n = new Note(NoteLetter.F, 4, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(5, num);
        }

        [TestMethod()]
        public void Note_GetLocalKeyNumberFromFSharp()
        {
            // Arrange
            Note n = new Note(NoteLetter.F, 4, true, ComponentLength.FULL, 0);

            // Act
            int num = n.GetLocalKeyNumber();

            // Assert
            Assert.AreEqual(6, num);
        }

        [TestMethod()]
        public void Note_GetAbsoluteKeyNumber_WhenOctaveIsFour_WhenLetterIsC_ShouldReturnFourty()
        {
            // Arrange
            Note n = new Note(NoteLetter.C, 4, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetAbsoluteKeyNumber();

            // Assert
            Assert.AreEqual(40, num);
        }

        [TestMethod()]
        public void Note_GetAbsoluteKeyNumber_WhenOctaveIsThree_WhenLetterIsC_ShouldReturnTwentyEight()
        {
            // Arrange
            Note n = new Note(NoteLetter.C, 3, false, ComponentLength.FULL, 0);

            // Act
            int num = n.GetAbsoluteKeyNumber();

            // Assert
            Assert.AreEqual(28, num);
        }

        [TestMethod()]
        public void Note_GetFrequencyInHz_WhenOctaveIsFour_WhenLetterIsC()
        {
            // Arrange
            Note n = new Note(NoteLetter.C, 4, false, ComponentLength.FULL, 0);

            // Act
            double hz = n.GetFrequencyInHz();

            // Assert
            Assert.AreEqual(261.626, hz, 0.1);
        }

        [TestMethod()]
        public void Note_GetFrequencyInHz_WhenOctaveIsThree_WhenLetterIsC()
        {
            // Arrange
            Note n = new Note(NoteLetter.C, 3, false, ComponentLength.FULL, 0);

            // Act
            double hz = n.GetFrequencyInHz();

            // Assert
            Assert.AreEqual(130.813, hz, 0.1);
        }

        [TestMethod()]
        public void Note_GetFrequencyInHz_WhenOctaveIsFive_WhenLetterIsC()
        {
            // Arrange
            Note n = new Note(NoteLetter.C, 5, false, ComponentLength.FULL, 0);

            // Act
            double hz = n.GetFrequencyInHz();

            // Assert
            Assert.AreEqual(523.251, hz, 0.1);
        }

        [TestMethod()]
        public void Note_GetNoteLetterFromLetter_WhenArgumentIsA_ShouldReturnA()
        {
            // Act & Assert
            Assert.AreEqual(NoteLetter.A, Note.GetNoteLetterFromLetter("A"));
        }

        [TestMethod()]
        public void Note_GetNoteLetterFromLetter_WhenArgumentIsB_ShouldReturnB()
        {
            // Act & Assert
            Assert.AreEqual(NoteLetter.B, Note.GetNoteLetterFromLetter("B"));
        }

        [TestMethod()]
        public void Note_GetNoteLetterFromLetter_WhenArgumentIsC_ShouldReturnC()
        {
            // Act & Assert
            Assert.AreEqual(NoteLetter.C, Note.GetNoteLetterFromLetter("C"));
        }

        [TestMethod()]
        public void Note_GetNoteLetterFromLetter_WhenArgumentIsD_ShouldReturnD()
        {
            // Act & Assert
            Assert.AreEqual(NoteLetter.D, Note.GetNoteLetterFromLetter("D"));
        }

        [TestMethod()]
        public void Note_GetNoteLetterFromLetter_WhenArgumentIsE_ShouldReturnE()
        {
            // Act & Assert
            Assert.AreEqual(NoteLetter.E, Note.GetNoteLetterFromLetter("E"));
        }

        [TestMethod()]
        public void Note_GetNoteLetterFromLetter_WhenArgumentIsF_ShouldReturnF()
        {
            // Act & Assert
            Assert.AreEqual(NoteLetter.F, Note.GetNoteLetterFromLetter("F"));
        }

        [TestMethod()]
        public void Note_GetNoteLetterFromLetter_WhenArgumentIsG_ShouldReturnG()
        {
            // Act & Assert
            Assert.AreEqual(NoteLetter.G, Note.GetNoteLetterFromLetter("G"));
        }
    }
}