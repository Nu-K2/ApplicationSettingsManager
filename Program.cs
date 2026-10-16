using System;
using System.Collections.Generic;

namespace ApplicationSettingsManager;

class Program
{
    public static void Main(string[] args)
    {
        Print.Info();
        SettingsManager manager1 = SettingsManager.GetInstance();
        SettingsManager manager2 = SettingsManager.GetInstance();

        Console.WriteLine("Демонстрация верности реализации паттерна Одиночка");
        Console.WriteLine($"Код объекта manager1: {manager1.GetHashCode()}");
        Console.WriteLine($"Код объекта manager2: {manager2.GetHashCode()}");
        Console.WriteLine($"manager1 == manager2: {ReferenceEquals(manager1, manager2)}\n");

        while (true)
        {
            Print.Menu();
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            switch (input)
            {
                case "1":
                    Print.AllSettings();
                    break;

                case "2":
                    SettingsManager set2 = SettingsManager.GetInstance();
                    Console.WriteLine("Введите ключ:");
                    string key2 = Console.ReadLine()?.Trim().ToUpper().Split(' ')[0] ?? "";
                    if (string.IsNullOrWhiteSpace(key2))
                    {
                        Console.WriteLine("Ключ не может быть пустым");
                        break;
                    }
                    Console.WriteLine("Введите значение:");
                    string value = Console.ReadLine()?.Trim() ?? "";
                    set2.SetSetting(key2, value);
                    Print.SuccessfullyAdded("добавлена", key2, value);
                    break;

                case "3":
                    SettingsManager set3 = SettingsManager.GetInstance();
                    Console.WriteLine("Введите ключ:");
                    string key3 = Console.ReadLine()?.Trim().ToUpper().Split(' ')[0] ?? "";
                    if (string.IsNullOrWhiteSpace(key3))
                    {
                        Console.WriteLine("Ключ не может быть пустым");
                        break;
                    }
                    string? val3 = set3.GetSetting(key3);
                    if (val3 != null)
                    {
                        Console.WriteLine($"В данный момент в настройке с ключом {key3} хранится значение {val3}");
                        while (true)
                        {
                            Console.WriteLine("Хотите изменить значение настройки? (y/n)");
                            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";
                            if (answer == "y" || answer == "у")
                            {
                                Console.WriteLine("Введите новое значение настройки:");
                                string value3 = Console.ReadLine()?.Trim() ?? "";
                                set3.SetSetting(key3, value3);
                                Print.SuccessfullyAdded("обновлена", key3, value3);
                                Console.WriteLine();
                                break;
                            }
                            else if (answer == "n" || answer == "н")
                            {
                                Console.WriteLine("Настройка оставлена неизменной\n");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ответ нераспознан");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Настройка для изменения не найдена");
                    }
                    break;

                case "4":
                    SettingsManager set4 = SettingsManager.GetInstance();
                    Console.WriteLine("Введите ключ:");
                    string key4 = Console.ReadLine()?.Trim().ToUpper().Split(' ')[0] ?? "";
                    if (string.IsNullOrWhiteSpace(key4))
                    {
                        Console.WriteLine("Ключ не может быть пустым");
                        break;
                    }
                    string? val4 = set4.GetSetting(key4);
                    if (val4 != null)
                    {
                        Console.WriteLine($"В данный момент в настройке с ключом {key4} хранится значение {val4}");
                        while (true)
                        {
                            Console.WriteLine("Вы уверены, что хотите удалить настройку? (y/n)");
                            string answer = Console.ReadLine()?.Trim().ToLower() ?? "";
                            if (answer == "y" || answer == "у")
                            {
                                set4.RemoveSetting(key4);
                                Print.SuccessfullyAdded("удалена", key4, val4);
                                Console.WriteLine();
                                break;
                            }
                            else if (answer == "n" || answer == "н")
                            {
                                Console.WriteLine("Настройка оставлена неизменной\n");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ответ нераспознан");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Настройка для удаления не найдена");
                    }
                    break;

                case "5":
                    SettingsManager set5 = SettingsManager.GetInstance();
                    while (true)
                    {
                        Console.WriteLine("Вы уверены, что хотите удалить ВСЕ настройки? (y/n)");
                        string answer = Console.ReadLine()?.Trim().ToLower() ?? "";
                        if (answer == "y" || answer == "у")
                        {
                            set5.ClearSettings();
                            set5.ShowAllSettings();
                            break;
                        }
                        else if (answer == "n" || answer == "н")
                        {
                            Console.WriteLine("Операция удаления отменена.\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ответ нераспознан");
                        }
                    }
                    break;

                case "6":
                    Console.WriteLine("Программа успешно завершена!");
                    return;

                default:
                    Console.WriteLine("Ошибка ввода. Команда не распознана");
                    break;
            }
        }
    }
}

class Print
{
    public static void Info()
    {
        Console.WriteLine(
            "Работу выполнили: Бедарева Софья и Сторожева Анна\n" +
            "Группа: 9ИС-435\n" +
            "Практическая работа №1: Паттерн Одиночка\n\n"
        );
    }

    public static void Menu()
    {
        Console.WriteLine(
            "Выберите действие\n" +
            "1 - Показать все настройки\n" +
            "2 - Добавить настройку\n" +
            "3 - Изменить настройку\n" +
            "4 - Удалить настройку\n" +
            "5 - Очистить все настройки\n" +
            "6 - Выход из программы\n"
        );
    }

    public static void Setting(string key)
    {
        string? set = SettingsManager.GetInstance().GetSetting(key);
        if (!string.IsNullOrWhiteSpace(set))
        {
            Console.WriteLine(set);
        }
        else
        {
            Console.WriteLine($"Настройка с ключом {key} не найдена в коллекции");
        }
    }

    public static void SuccessfullyAdded(string action, string key, string value)
    {
        SettingsManager set = SettingsManager.GetInstance();
        Console.WriteLine($"Настройка с ключом = {key} и значением = {value} успешно {action}. Настроек в коллекции: {set.GetNumberOfSettings()}");
    }

    public static void AllSettings()
    {
        SettingsManager set = SettingsManager.GetInstance();
        set.ShowAllSettings();
    }
}

class SettingsManager
{
    // Реализация паттерна Одиночка (потокобезопасная версия)
    private static SettingsManager? _instance;

    private SettingsManager()
    {
        _settings = new Dictionary<string, string>();
    }

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

    // Реализация хранения настроек
    private readonly Dictionary<string, string> _settings;

    public void SetSetting(string key, string value)
    {
        _settings[key] = value;
    }

    public string? GetSetting(string key)
    {
        if (_settings.TryGetValue(key, out string? value))
            return value;
        return null;
    }

    public int GetNumberOfSettings()
    {
        return _settings.Count;
    }

    public void ShowAllSettings()
    {
        if (_settings.Count == 0)
        {
            Console.WriteLine("В коллекции не хранится никаких настроек");
            return;
        }

        Console.WriteLine("Список настроек в коллекции:");
        foreach (var item in _settings)
        {
            Console.WriteLine($"{item.Key} = {item.Value}");
        }
    }

    public void ClearSettings()
    {
        _settings.Clear();
    }

    public bool RemoveSetting(string key)
    {
        return _settings.Remove(key);
    }
}