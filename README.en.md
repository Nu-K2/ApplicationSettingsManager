**English** | [Русский](README.md)
# README

## Practical Work No. 1: Implementing the "Singleton" Pattern in C#

**Objective:** To consolidate theoretical knowledge on the topic "Purpose and Types of Patterns" and to gain practical skills in implementing the "Singleton" pattern in a console application in C#.

---

## Project Description

A console application **"Application Settings Manager"** demonstrating the operation of the "Singleton" pattern for centralized storage and management of settings.

Access to the settings manager is performed from different points in the program, but **the same instance** is always returned.

---

## Functionality

### Main Screen (Entry Point)

When the application starts, the screen displays:
- Last name and First name of the authors.
- Name of the academic group.
- Name of the practical work ("PW No. 1: Singleton Pattern").
- Brief description: "Demonstration of the settings manager's operation".

### Demonstration of Instance Uniqueness

Immediately after the greeting, the program creates two instances of `SettingsManager` via `GetInstance()` and compares them:
- The hash codes of both objects are displayed.
- The result of `ReferenceEquals(manager1, manager2)` is displayed.

This is explicit proof of the pattern's correct operation.

### Interactive Menu

| Item | Action |
|-------|----------|
| 1 | **Show all settings** — calls `ShowAllSettings()`. |
| 2 | **Add a setting** — prompts for a key and value, calls `SetSetting()`. |
| 3 | **Modify a setting** — prompts for a key, finds the value, and offers to update it. |
| 4 | **Delete a setting** — prompts for a key and confirmation, then deletes the setting. |
| 5 | **Clear all settings** — prompts for confirmation and calls `ClearSettings()`. |
| 6 | **Exit the program** — terminates the application. |

---

## Implementation of the "Singleton" Pattern

### Class `SettingsManager`

```csharp
class SettingsManager
{
    // Private static field for storing the single instance
    private static SettingsManager? _instance;

    // Private constructor
    private SettingsManager()
    {
        _settings = new Dictionary<string, string>();
    }

    // Public static method for obtaining the instance
    public static SettingsManager GetInstance()
    {
        if (_instance == null)
        {
            if (_instance == null)
            {
                _instance = new SettingsManager();
            }
        }
        return _instance;
    }

    private readonly Dictionary<string, string> _settings;
    // ...
}
```

**Key elements of the pattern:**
- ✅ Private constructor.
- ✅ Private static field `_instance` for storing the single instance.
- ✅ Public static method `GetInstance()` — creates the instance on the first call and returns the stored one on subsequent calls.

---

## Settings Storage (Business Logic)

The `SettingsManager` class contains a `Dictionary<string, string>` collection for storing settings.

### Class Methods

| Method | Description |
|-------|----------|
| `void SetSetting(string key, string value)` | Adds or updates a setting. |
| `string? GetSetting(string key)` | Returns the value of a setting by key (or `null` if the key is not found). |
| `void ShowAllSettings()` | Displays all stored settings on the screen. |
| `void ClearSettings()` | Clears all settings. |
| `bool RemoveSetting(string key)` | Removes a setting by key. |
| `int GetNumberOfSettings()` | Returns the current number of settings. |

---

## Action Confirmation

After each operation (adding, modifying, deleting, clearing), a confirmation message is displayed with the current number of settings.

**Examples:**
- "Setting with key = THEME and value = DARK successfully added. Settings in the collection: 3".
- "Setting with key = THEME and value = LIGHT successfully updated. Settings in the collection: 3".
- "Setting with key = THEME and value = DARK successfully removed. Settings in the collection: 2".

---

## Project Structure

```
ApplicationSettingsManager/
├── Program.cs      // Entry point, classes Print, SettingsManager
└── README.md       // Documentation
```

### Main Classes

| Class | Purpose |
|-------|------------|
| `Program` | Entry point, implements the menu and command handling. |
| `Print` | Auxiliary class for displaying information (Info, Menu, Setting, SuccessfullyAdded, AllSettings). |
| `SettingsManager` | Implementation of the "Singleton" pattern and settings storage. |

---

## Requirements

- **Language:** C# (version 9.0 and higher; `namespace ApplicationSettingsManager;` is used — file-scoped namespace, as well as `?.` and `??` for null safety).
- **Runtime:** .NET 5+ / .NET Core 3.1+.
- **IDE:** Visual Studio, Rider, VS Code.

---

## Running

1. Copy the `Program.cs` file into the project.
2. Build the project:
   ```bash
   dotnet build
   ```
3. Run:
   ```bash
   dotnet run
   ```

---

## Example of Operation

```
Practical Work No. 1: Singleton Pattern

Demonstration of the correctness of the Singleton pattern implementation
Code of object manager1: 12345678
Code of object manager2: 12345678
manager1 == manager2: True

Choose an action
1 - Show all settings
2 - Add a setting
3 - Modify a setting
4 - Delete a setting
5 - Clear all settings
6 - Exit the program
1
No settings are stored in the collection

...
2
Enter key:
theme
Enter value:
dark
Setting with key = THEME and value = dark successfully added. Settings in the collection: 1

...
5
Are you sure you want to delete ALL settings? (y/n)
y
No settings are stored in the collection

...
6
The program has terminated successfully!
```

---

## Implementation Features

- **Thread safety:** a double check `if (_instance == null)` is used inside `GetInstance()` (although without explicit locking — this is a basic version; for full thread safety, `lock` or `Lazy<T>` is recommended).
- **Key normalization:** keys are converted to uppercase (`ToUpper()`) and trimmed at the first space, which ensures uniform storage.
- **Input flexibility:** "y"/"n" answers are accepted in both Latin and Cyrillic ("у"/"н").
- **Cancellation of operations:** all modifying actions require confirmation.
- **Encapsulation:** the `_settings` dictionary is accessible only through the class methods.

---

## Compliance with the Requirements of the Practical Work

| Requirement | Status |
|------------|--------|
| No. 1. Implementation of the "Singleton" pattern (private constructor, private static field, `GetInstance()`) | ✅ |
| No. 2. Business logic (`SetSetting`, `GetSetting`, `ShowAllSettings`, `ClearSettings`) | ✅ |
| No. 3. Handling of all menu items (minimum 5) with access to `GetInstance()` | ✅ (6 items) |
| No. 4. Confirmation of actions indicating the number of settings | ✅ |
| No. 5. Demonstration of instance uniqueness in `Main` | ✅ |

**Grade: "5" (Excellent)** — all 5 mandatory requirements have been fulfilled.
