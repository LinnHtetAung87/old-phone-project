using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input (end with #):");
        string userInput = Console.ReadLine();
        //Check UserInput '#' have or not.
        if (!userInput.EndsWith("#"))
        {
            Console.WriteLine("Error: Input must end with '#'.");
        }
        else
        {
            string output = OldPhonePad(userInput);
            Console.WriteLine("Output: " + output);
        }
    }

    // Keypad mappings for old phone pads.
    private static readonly Dictionary<char, string> phoneKeypad = new Dictionary<char, string>()
    {
        {'2', "ABC"},
        {'3', "DEF"},
        {'4', "GHI"},
        {'5', "JKL"},
        {'6', "MNO"},
        {'7', "PQRS"},
        {'8', "TUV"},
        {'9', "WXYZ"},
    };

    public static string OldPhonePad(string input)
    {
        // Using StringBuilder for efficient string manipulation.
        StringBuilder messageBuilder = new StringBuilder(input.Length);
        StringBuilder currentBuffer = new StringBuilder();

        foreach (char pressedKey in input)
        {
            //Check pressedKey '#' or '*' have.
            if (pressedKey == '#')
            {
                break;
            }
            else if (pressedKey == '*')
            {
                // Handle the backspace operation.
                ProcessBufferedKey(currentBuffer, messageBuilder);

                // Perform the actual backspace if there's anything to delete.
                if (messageBuilder.Length > 0)
                {
                    messageBuilder.Remove(messageBuilder.Length - 1, 1);
                }
            }
            else if (pressedKey == ' ')
            {
                // Currently buffered key presses
                ProcessBufferedKey(currentBuffer, messageBuilder);
            }
            else if (char.IsDigit(pressedKey))
            {
                // Check new digit or current one.
                if (currentBuffer.Length > 0 && currentBuffer[0] != pressedKey)
                {
                    ProcessBufferedKey(currentBuffer, messageBuilder);
                }
                // Add the current digit to the buffer.
                currentBuffer.Append(pressedKey);
            }
        }

        ProcessBufferedKey(currentBuffer, messageBuilder);

        return messageBuilder.ToString();
    }

    private static void ProcessBufferedKey(StringBuilder buffer, StringBuilder mainMessageBuilder)
    {
        if (buffer.Length == 0) return; // Check the buffer is empty or not.

        char keyDigit = buffer[0];
        int pressCount = buffer.Length;

        // Attempt to get the letters from the keypad.
        if (phoneKeypad.TryGetValue(keyDigit, out string? letters))
        {
            // Calculate the index of character.
            int charIndex = (pressCount - 1) % letters.Length;
            mainMessageBuilder.Append(letters[charIndex]);
        }

        buffer.Clear();
    }
}