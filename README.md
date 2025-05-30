# Old Phone Pad Translator

## Project Overview

This project implements a simple C# console application that simulates the text input experience of an old-style mobile phone keypad. Users enter a sequence of key presses, and the application translates these presses into a readable English message.

The application adheres to the following rules:
* **Numeric Keys (2-9):** Each digit corresponds to a set of letters (e.g., '2' for A, B, C). Repeated presses of the same digit cycle through its assigned letters.
* **Space (' '):** A space character acts as a delimiter, committing the currently buffered key presses and starting a new character.
* **Asterisk ('*'):** The asterisk acts as a backspace, deleting the last character from the translated message.
* **Hash ('#'):** The hash character signifies the end of the input sequence. All input after '#' is ignored.
* **Other Characters:** Any characters not explicitly defined (digits, space, asterisk, hash) are ignored.

## Features

* Translates numeric key sequences (2-9) to corresponding letters.
* Supports repeated key presses for cycling through letters.
* Handles space character for word separation/character commitment.
* Implements backspace functionality (`*`).
* Processes input until a '#' character is encountered.

Project Structure
OldPhonePad/
├── OldPhonePad.sln
├── OldPhonePad/
│   ├── Program.cs
│   └── OldPhonePad.csproj
├── OldPhonePad.Tests/
│   ├── TestCases.cs
│   └── OldPhonePad.Tests.csproj
└── README.md

## How to Build and Run

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or newer recommended)

### Building the Project

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/LinnHtetAung87/old-phone-project.git
    cd old-phone-project
    ```

2.  **Restore NuGet packages and build the solution:**
    ```bash
    dotnet build
    ```

### Running the Console Application

To run the main console application:
```bash
dotnet run --project old-phone-project/old-phone-project.csproj
