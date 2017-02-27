using System.Collections.Generic;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KBS2VirtuelePianoTests
{
    [TestClass()]
    public class RowTests
    {
        [TestMethod()]
        public void RefactorListToMultiListTest_ShouldReturnMultiListWithOneList()
        {
            //Arrange
            Row row1 = new Row(0 ,0);
            List<SongComponent> singleList = new List<SongComponent>();
            List<List<SongComponent>> multiList = new List<List<SongComponent>>();
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });

            //Act
            multiList = row1.RefactorListToMultiList(singleList);

            //Assert
            Assert.AreEqual(multiList.Count, 1);
        }

        [TestMethod()]
        public void RefactorListToMultiListTest_ShouldReturnListWithThreeList()
        {
            //Arange
            Row row1 = new Row(0, 0);
            List<SongComponent> singleList = new List<SongComponent>();
            List<List<SongComponent>> multiList = new List<List<SongComponent>>();
            singleList.Add(new Note() { Length = ComponentLength.FULL });
            singleList.Add(new Note() { Length = ComponentLength.QUARTER });
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });
            //Act
            multiList = row1.RefactorListToMultiList(singleList);
            //Assert
            Assert.AreEqual(multiList.Count, 3);
        }

        [TestMethod()]
        public void RefactorListToMultiListTest_ShouldReturnListWithThreeListWithDifferentNoteLengths()
        {
            //Arange
            Row row1 = new Row(0, 0);
            List<SongComponent> singleList = new List<SongComponent>();
            List<List<SongComponent>> multiList = new List<List<SongComponent>>();
            singleList.Add(new Note() { Length = ComponentLength.FULL });
            singleList.Add(new Note() { Length = ComponentLength.QUARTER });
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });
            //Act
            multiList = row1.RefactorListToMultiList(singleList);
            //Assert
            Assert.AreEqual(multiList.Count, 3);
        }
        [TestMethod()]
        public void RefactorListToMultiListTest_ShouldReturnListWithThreeListFirstAndLastAreEights()
        {
            //Arange
            Row row1 = new Row(0, 0);
            List<SongComponent> singleList = new List<SongComponent>();
            List<List<SongComponent>> multiList = new List<List<SongComponent>>();
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });
            singleList.Add(new Note() { Length = ComponentLength.QUARTER });
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });
            singleList.Add(new Note() { Length = ComponentLength.EIGHTH });

            //Act
            multiList = row1.RefactorListToMultiList(singleList);
            //Assert
            Assert.AreEqual(multiList.Count, 3);
        }
    }
}