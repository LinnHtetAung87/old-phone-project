using NUnit.Framework;
using OldPhonePad;

namespace OldPhonePad.Tests
{
    [TestFixture]
    public class OldPhonePadTests
    {
        [Test]
        public void OldPhonePad_BasicInput_ReturnsCorrectMessage()
        {
            string input = "4433555 555666#";
            string expectedOutput = "HELLO";
            string actualOutput = Program.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OldPhonePad_MultipleSpaces_HandlesCorrectly()
        {
            string input = "444 44 444#";
            string expectedOutput = "IHI";
            string actualOutput = Program.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OldPhonePad_WithBackspace_RemovesLastCharacter()
        {
            string input = "9996667773322*2#";
            string expectedOutput = "YOREA";
            string actualOutput = Program.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OldPhonePad_BackspaceOnEmptyMessage_DoesNothing()
        {
            Assert.AreEqual("", Program.OldPhonePad("*#"));
            Assert.AreEqual("", Program.OldPhonePad("**#"));
        }

        [Test]
        public void OldPhonePad_SingleDigitPress_ReturnsFirstLetter()
        {
            Assert.AreEqual("A", Program.OldPhonePad("2#"));
            Assert.AreEqual("P", Program.OldPhonePad("7#"));
        }

        [Test]
        public void OldPhonePad_MaxPresses_WrapsAroundCorrectly()
        {
            Assert.AreEqual("P", Program.OldPhonePad("77777#"));
            Assert.AreEqual("A", Program.OldPhonePad("2222#"));
        }

        [Test]
        public void OldPhonePad_MixedOperations_ReturnsAccurateResult()
        {
            // Original complex string: "46666633 333333999999222222*222#"
            // Traced output: GNEFXC
            Assert.AreEqual("GNEFXC", Program.OldPhonePad("46666633 333333999999222222*222#"));

            // Example from README that is correct:
            Assert.AreEqual("L", Program.OldPhonePad("5556*#"));
            Assert.AreEqual("E", Program.OldPhonePad("33#"));
            Assert.AreEqual("B", Program.OldPhonePad("227*#"));
            Assert.AreEqual("TURING", Program.OldPhonePad("8 88777444666*664#"));
        }

        [Test]
        public void OldPhonePad_EmptyInput_ReturnsEmptyString()
        {
            Assert.AreEqual("", Program.OldPhonePad("#"));
        }

        [Test]
        public void OldPhonePad_ConsecutiveDifferentDigitsNoSpace_CommitsAutomatically()
        {
            Assert.AreEqual("AD", Program.OldPhonePad("23#"));
            // Corrected expectation for this input, as 555555 should yield 'L' (6 presses of 5 -> L)
            Assert.AreEqual("HELO", Program.OldPhonePad("4433555555666#"));
        }

        [Test]
        public void OldPhonePad_UnrecognizedCharacters_AreIgnored()
        {
            string input = "444!@#$44 444%^&#";
            string expectedOutput = "I";
            string actualOutput = Program.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OldPhonePad_LeadingTrailingSpaces_HandledCorrectly()
        {
            Assert.AreEqual("A", Program.OldPhonePad(" 2#"));
            Assert.AreEqual("A", Program.OldPhonePad("2 #"));
            Assert.AreEqual("A", Program.OldPhonePad(" 2 #"));
        }
    }
}
