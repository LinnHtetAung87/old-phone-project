Old Phone Pad Translator
This project provides a C# solution for translating sequences of key presses from an old-style mobile phone keypad into a readable message. It handles numeric key presses, spaces for committing characters, and the asterisk (*) for backspacing. The input sequence must always end with a hash (#).

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
