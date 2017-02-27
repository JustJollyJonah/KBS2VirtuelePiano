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
    public class PianoTests
    {
        [TestMethod()]
        public void Piano_FindKey_WhenKeyExists_ShouldReturnKey()
        {
            // Arrange
            Piano p = new Piano();

            // Act
            PianoKey pk = p.FindKey(4, "C", false);

            // Assert
            Assert.AreEqual("C", pk.Name);
            Assert.AreEqual(4, pk.Octave);
            Assert.AreEqual(false, pk.Black);
        }

        [TestMethod()]
        public void Piano_FindKey_WhenKeyDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            Piano p = new Piano();

            // Act
            PianoKey pk = p.FindKey(4, "Q", false);

            // Assert
            Assert.IsNull(pk);
        }

        [TestMethod()]
        public void Piano_FindKeys_WhenOctaveExists_WhenSearchingForWhiteKeys_ShouldReturnSevenWhiteKeys()
        {
            // Arrange
            Piano p = new Piano();

            // Act
            List<PianoKey> pks = p.FindKeys(Piano.BASE_OCTAAF, false);

            // Assert
            Assert.AreEqual(7, pks.Count);
            Assert.IsTrue(pks.Contains(new PianoKey(Piano.BASE_OCTAAF, "C")));
            Assert.IsTrue(pks.Contains(new PianoKey(Piano.BASE_OCTAAF, "D")));
            Assert.IsTrue(pks.Contains(new PianoKey(Piano.BASE_OCTAAF, "E")));
            Assert.IsTrue(pks.Contains(new PianoKey(Piano.BASE_OCTAAF, "F")));
            Assert.IsTrue(pks.Contains(new PianoKey(Piano.BASE_OCTAAF, "G")));
            Assert.IsTrue(pks.Contains(new PianoKey(Piano.BASE_OCTAAF, "A")));
            Assert.IsTrue(pks.Contains(new PianoKey(Piano.BASE_OCTAAF, "B")));
        }

        [TestMethod()]
        public void Piano_FindKeys_WhenOctaveDoesNotExist_ShouldReturnEmptyList()
        {
            // Arrange
            Piano p = new Piano();

            // Act
            List<PianoKey> pks = p.FindKeys(Piano.BASE_OCTAAF + Piano.OCTAVEN, false);

            // Assert
            Assert.IsNotNull(pks);
            Assert.AreEqual(0, pks.Count);
        }

        [TestMethod()]
        public void Piano_Enable_WhenKeyExists_ShouldSetEnabledToTrue()
        {
            // Arrange
            Piano p = new Piano();
            int oct = Piano.BASE_OCTAAF;
            string letter = "C";
            bool special = false;

            // Act
            p.Enable(oct, letter, special);

            // Assert
            PianoKey pk = p.FindKey(oct, letter, special);
            Assert.IsNotNull(pk);
            Assert.IsTrue(pk.Enabled);
        }

        [TestMethod()]
        public void Piano_Enable_WhenKeyDoesNotExist_ShouldDoNothing()
        {
            // Arrange
            Piano p = new Piano();
            int oct = Piano.BASE_OCTAAF + Piano.OCTAVEN;
            string letter = "C";
            bool special = false;

            // Act
            p.Enable(oct, letter, special);

            // Assert
            Assert.IsNull(p.FindKey(oct, letter, special));
        }

        [TestMethod()]
        public void Piano_Disable_WhenKeyExists_ShouldSetEnabledToTrue()
        {
            // Arrange
            Piano p = new Piano();
            int oct = Piano.BASE_OCTAAF;
            string letter = "C";
            bool special = false;

            // Act
            p.Enable(oct, letter, special);
            p.Disable(oct, letter, special);

            // Assert
            PianoKey pk = p.FindKey(oct, letter, special);
            Assert.IsNotNull(pk);
            Assert.IsFalse(pk.Enabled);
        }

        [TestMethod()]
        public void Piano_Disable_WhenKeyDoesNotExist_ShouldDoNothing()
        {
            // Arrange
            Piano p = new Piano();
            int oct = Piano.BASE_OCTAAF + Piano.OCTAVEN;
            string letter = "C";
            bool special = false;

            // Act
            p.Disable(oct, letter, special);

            // Assert
            Assert.IsNull(p.FindKey(oct, letter, special));
        }

        [TestMethod()]
        public void Piano_ResetAll()
        {
            // Arrange
            Piano p = new Piano();
            int oct = Piano.BASE_OCTAAF;
            string letter = "C";
            bool special = false;

            // Act
            p.Enable(oct, letter, special);
            p.ResetAll();

            // Asset
            PianoKey pk = p.FindKey(oct, letter, special);
            Assert.IsNotNull(pk);
            Assert.IsFalse(pk.Enabled);
        }
    }
}