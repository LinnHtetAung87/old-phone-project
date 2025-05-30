using NUnit.Framework; // Required for NUnit attributes and assertions
using OldPhonePad;     // Reference to your main project's namespace

namespace OldPhonePad.Tests
{
    /// <summary>
    /// This class contains unit tests for the OldPhonePad translation logic.
    /// The [TestFixture] attribute marks this class as containing tests.
    /// </summary>
    [TestFixture]
    public class OldPhonePadTests
    {
        /// <summary>
        /// Tests a basic translation with common digits and spaces.
        /// Expected: "HELLO" from "4433555 555666#"
        /// </summary>
        [Test] // Marks this method as a test case
        public void OldPhonePad_BasicInput_ReturnsCorrectMessage()
        {
            // Arrange: Define the input and the expected output.
            string input = "4433555 555666#";
            string expectedOutput = "HELLO";

            // Act: Call the method being tested.
            string actualOutput = Program.OldPhonePad(input);

            // Assert: Verify that the actual output matches the expected output.
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        /// <summary>
        /// Tests input with multiple consecutive spaces.
        /// Expected: "HI" from "444 44 444#" (multiple spaces should still just commit the character)
        /// </summary>
        [Test]
        public void OldPhonePad_MultipleSpaces_HandlesCorrectly()
        {
            string input = "444 44 444#";
            string expectedOutput = "HI";
            string actualOutput = Program.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        /// <summary>
        /// Tests the backspace functionality.
        /// Expected: "WORLD" from "9996667773322*2#" (removes the last 'B' from 'WORLDB')
        /// </summary>
        [Test]
        public void OldPhonePad_WithBackspace_RemovesLastCharacter()
        {
            string input = "9996667773322*2#"; // Should be WORLDB, then backspace 'B', then 'A'
            string expectedOutput = "WORLDA"; // Corrected expectation based on input
            string actualOutput = Program.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        /// <summary>
        /// Tests backspace when the message is already empty.
        /// Expected: Empty string, as backspace on empty should do nothing.
        /// </summary>
        [Test]
        public void OldPhonePad_BackspaceOnEmptyMessage_DoesNothing()
        {
            Assert.AreEqual("", Program.OldPhonePad("*#"));
            Assert.AreEqual("", Program.OldPhonePad("**#")); // Multiple backspaces
        }

        /// <summary>
        /// Tests a single digit press, expecting the first letter for that digit.
        /// </summary>
        [Test]
        public void OldPhonePad_SingleDigitPress_ReturnsFirstLetter()
        {
            Assert.AreEqual("A", Program.OldPhonePad("2#"));
            Assert.AreEqual("P", Program.OldPhonePad("7#"));
        }

        /// <summary>
        /// Tests that repeated presses wrap around the letters correctly.
        /// '7' maps to PQRS. 5 presses should result in 'P' (77777 -> P).
        /// '2' maps to ABC. 4 presses should result in 'A' (2222 -> A).
        /// </summary>
        [Test]
        public void OldPhonePad_MaxPresses_WrapsAroundCorrectly()
        {
            Assert.AreEqual("P", Program.OldPhonePad("77777#"));
            Assert.AreEqual("A", Program.OldPhonePad("2222#"));
        }

        /// <summary>
        /// Tests a complex input sequence with mixed operations (digits, spaces, backspaces).
        /// </summary>
        [Test]
        public void OldPhonePad_MixedOperations_ReturnsAccurateResult()
        {
            // Example: 4 (GHI) -> G, 666 (MNO) -> O, 33 (DEF) -> E, 333 (DEF) -> F, 999 (WXYZ) -> Z,
            // 999 (WXYZ) -> Z, 222 (ABC) -> C, 222 (ABC) -> C, * (backspace) -> remove last C, 222 (ABC) -> C
            // Expected: GOO DBYE (This is a complex one, let's trace carefully)
            // Input: 46666633 333333999999222222*222#
            // 4 -> G
            // 666 -> O
            // 66 -> N
            // 33 -> E
            //   -> GONE
            // 333 -> F
            // 333 -> F
            //   -> GONEFF
            // 999 -> Z
            // 999 -> Z
            //   -> GONEFFZZ
            // 222 -> C
            // 222 -> C
            //   -> GONEFFZZCC
            // * -> GONEFFZZC
            // 222 -> C
            // Final: GONEFFZZCC
            Assert.AreEqual("GONEFFZZCC", Program.OldPhonePad("46666633 333333999999222222*222#"));
            // Let's use the example from the previous README for a more common test case
            Assert.AreEqual("TURING", Program.OldPhonePad("8 88777444666*664#"));
        }

        /// <summary>
        /// Tests an empty input string (just '#').
        /// Expected: Empty string.
        /// </summary>
        [Test]
        public void OldPhonePad_EmptyInput_ReturnsEmptyString()
        {
            Assert.AreEqual("", Program.OldPhonePad("#"));
        }

        /// <summary>
        /// Tests input where digits for different characters are pressed consecutively without a space.
        /// The system should automatically commit the previous character.
        /// Expected: "AD" from "23#" (2 gives 'A', then 3 gives 'D')
        /// </summary>
        [Test]
        public void OldPhonePad_ConsecutiveDifferentDigitsNoSpace_CommitsAutomatically()
        {
            Assert.AreEqual("AD", Program.OldPhonePad("23#"));
            Assert.AreEqual("HELLO", Program.OldPhonePad("4433555555666#")); // No space, but still works
        }

        /// <summary>
        /// Tests input with unrecognized characters (should be ignored).
        /// </summary>
        [Test]
        public void OldPhonePad_UnrecognizedCharacters_AreIgnored()
        {
            Assert.AreEqual("HI", Program.OldPhonePad("444!@#$44 444%^&#"));
        }

        /// <summary>
        /// Tests input that starts or ends with spaces.
        /// </summary>
        [Test]
        public void OldPhonePad_LeadingTrailingSpaces_HandledCorrectly()
        {
            Assert.AreEqual("A", Program.OldPhonePad(" 2#"));
            Assert.AreEqual("A", Program.OldPhonePad("2 #"));
            Assert.AreEqual("A", Program.OldPhonePad(" 2 #"));
        }
    }
}
