using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2VirtuelePiano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS2VirtuelePiano.Model;

namespace KBS2VirtuelePiano.Tests
{
    [TestClass()]
    public class MeasureTests
    {
        [TestMethod()]
        public void GetComponentsAtTest_ShouldReturnOneObjectSameAsExpected()
        {
            //Arrange
            int x = 0;
            List<SongComponent> listComponentAt = new List<SongComponent>();
            Measure measure = new Measure();
            Note testNote = new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0);
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1 * (int)ComponentLength.QUARTER));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2 * (int)ComponentLength.QUARTER));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));

            //Act
            listComponentAt = measure.GetComponentsAt(x);

            //Assert
            Assert.AreEqual(testNote, listComponentAt[x]);
        }

        [TestMethod()]
        public void GetComponentsAtTest_ShouldReturnListWithOneComponent()
        {
            //Arrange
            int x = 0;
            List<SongComponent> listComponentAt = new List<SongComponent>();
            Measure measure = new Measure();
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1 * (int)ComponentLength.QUARTER));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 2 * (int)ComponentLength.QUARTER));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));

            //Act
            listComponentAt = measure.GetComponentsAt(x);

            //Assert
            Assert.AreEqual(1, listComponentAt.Count);
        }

        [TestMethod()]
        public void GetComponentsAtTest_ShouldReturnListWithTwoComponents()
        {
            //Arrange
            int x = 1;
            List<SongComponent> listComponentAt = new List<SongComponent>();
            Measure measure = new Measure();
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3 * (int)ComponentLength.QUARTER));

            //Act
            listComponentAt = measure.GetComponentsAt(x);

            //Assert
            Assert.AreEqual(2, listComponentAt.Count);
        }

        [TestMethod()]
        public void GetComponentsAtTest_ShouldReturnListWithNoComponents()
        {
            //Arrange
            int x = 2;
            List<SongComponent> listComponentAt = new List<SongComponent>();
            Measure measure = new Measure();
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 0));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 1));
            measure.Components.Add(new Note(NoteLetter.C, 4, false, ComponentLength.QUARTER, 3));

            //Act
            listComponentAt = measure.GetComponentsAt(x);

            //Assert
            Assert.AreEqual(0, listComponentAt.Count);
        }
    }
}