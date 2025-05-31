# Project Overview

## 📱 Old Phone Pad Decoder - C# Console App
This C# console application simulates the behavior of old mobile keypads, converting numeric input into corresponding text messages based on multi-press input logic. It supports basic functionality such as character selection, space handling, and backspacing.

## 🛠 Features
Converts number sequences (e.g., 2, 22, 222) to corresponding letters (A, B, C)

Supports:

* as input terminator

* as a backspace/delete

Space ( ) to finalize the current character entry

Handles invalid input cases such as missing end character #

## 🧪 Example
Input: 
```bash
4433555 555666096667775553#
```
Output: 
```bash
HELLO WORLD
```

## 🔡 Keypad Mapping
Key	Characters
2	A B C
3	D E F
4	G H I
5	J K L
6	M N O
7	P Q R S
8	T U V
9	W X Y Z

## 📂 Project Structure
OldPhoneProject/
├── OldPhonePadSolution.sln
├── OldPhonePad/
│   ├── OldPhonePad.csproj
│   └── Program.cs
└── OldPhonePad.Tests/
    ├── OldPhonePad.Tests.csproj
    └── TestCases.cs

## 🚀 How to Build and Run

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
dotnet test OldPhonePad.Tests/OldPhonePad.Tests.csproj
```

```bash
dotnet run --project OldPhonePad/OldPhonePad.csproj
```

3.  **Input your message ending with "#"**

✅ Input Format Rules
Input must end with a #

Use * to delete the last character

Use spaces to finalize a letter before entering another

# 📄 License
This project is open-source and available under the [MIT license](https://opensource.org/licenses/MIT).

# ✍️ Author
Your Name - Linn Htet Aung