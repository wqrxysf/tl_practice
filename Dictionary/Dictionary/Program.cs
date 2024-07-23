using System.IO;

string filePath = "dictionary.txt";
var dictionary = new Dictionary<string, string>();

Console.WriteLine( "*** Программа Dictionary приветствует Вас! ***" );
Console.WriteLine( "** Здесь Вы можете хранить переводы любых слов. Просто начните вводить! **" );
LoadDictionary();

while ( true )
{
    Console.Write( "Введите слово для перевода/добавления перевода, для выхода из программы введите пустую строку: " );
    string userData = Console.ReadLine().ToLower().Trim();

    if ( String.IsNullOrWhiteSpace( userData ) )
    {
        SaveDictionary();
        break;
    }

    if ( !dictionary.ContainsKey( userData ) )
    {
        Console.WriteLine( "Перевод не найден. Введите [1] для добавления перевода в словарь!" );
        string userApprove = Console.ReadLine();
        if ( userApprove == "1" )
        {
            if ( AddInDictionary( userData, dictionary, filePath ) )
            {
                Console.WriteLine( "Перевод успешно добавлен!" );
            }
        }
    }
    else
    {
        Console.WriteLine( dictionary[ userData ] );
    }
}

void LoadDictionary()
{
    if ( !File.Exists( filePath ) )
    {
        using ( File.Create( filePath ) )
        {
            Console.WriteLine( "Был создан новый файл, так как по заданному пути не был найден словарь!" );
        }
        return;
    }

    dictionary.Clear();

    using ( StreamReader stream = new StreamReader( filePath ) )
    {
        string line;
        while ( ( line = stream.ReadLine() ) != null )
        {
            if ( !line.Contains( "|" ) )
            {
                continue;
            }
            dictionary.Add( line.Split( "|" )[ 0 ], line.Split( "|" )[ 1 ] );
        }
    }
}

void SaveDictionary()
{
    using ( StreamWriter stream = new StreamWriter( filePath ) )
    {
        foreach ( KeyValuePair<string, string> entry in dictionary )
        {
            stream.WriteLine( $"{entry.Key}|{entry.Value}" );
        }
    }
}

static bool AddInDictionary( string userData, Dictionary<string, string> dictionary, string filePath )
{
    Console.Write( $"Введите перевод слова {userData}: " );
    string userTranslate = Console.ReadLine().Trim().ToLower();

    if ( String.IsNullOrWhiteSpace( userTranslate ) )
    {
        Console.WriteLine( "Ошибка! Вы ввели пустое значение перевода." );
        return false;
    }
    dictionary[ userData ] = userTranslate;
    dictionary[ userTranslate ] = userData;
    return true;
}