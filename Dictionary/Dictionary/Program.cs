string filePath = "dictionary.txt";
var dictionary = new Dictionary<string, string>();


static void LoadDictionary(Dictionary<string, string> dictionary, string filePath)
{
    if (!File.Exists(filePath))
    {
        using (File.Create(filePath)) { }
        return;
    }
    dictionary.Clear();
    using (StreamReader stream = new StreamReader(filePath))
    {
        string line;
        while ((line = stream.ReadLine()) != null)
        {
            if (!line.Contains("|"))
                continue;

            dictionary.Add(line.Split("|")[0], line.Split("|")[1]);
        }
    }
}

static void SaveDictionary(Dictionary<string, string> dictionary, string filePath)
{
    using (StreamWriter stream = new StreamWriter(filePath))
    {
        foreach (KeyValuePair<string, string> entry in dictionary)
        {
            stream.WriteLine($"{entry.Key}|{entry.Value}");
        }
    }
}

static bool AddInDictionary(string userData, Dictionary<string, string> dictionary, string filePath)
{
    Console.Write($"Введите перевод слова {userData}: ");
    string userTranslate = Console.ReadLine().Trim().ToLower();

    if (String.IsNullOrWhiteSpace(userTranslate))
    {
        Console.WriteLine("Ошибка! Вы ввели пустое значение перевода.");
        return false;
    }
    dictionary[userData] = userTranslate;
    dictionary[userTranslate] = userData;
    return true;
}

while (true)
{
    LoadDictionary(dictionary, filePath);
    Console.Write("Введите слово для перевода, для выхода введите пустую строку: ");
    string userData = Console.ReadLine().ToLower();

    if (String.IsNullOrWhiteSpace(userData))
    {
        break;
    }

    if (!dictionary.ContainsKey(userData))
    {
        Console.WriteLine("Перевод не найден. Введите [1] для добавления перевода в словарь!");
        string userApprove = Console.ReadLine();
        if (userApprove == "1")
        {
            if (AddInDictionary(userData, dictionary, filePath))
            {
                SaveDictionary(dictionary, filePath);
            }
        }
        
    }
    else
    {
        Console.WriteLine(dictionary[userData]);
    }
}
