Console.Write( "Введите название товара: " );
string title = Console.ReadLine();

Console.Write( $"Введите необходимое количество товара {title}: " );
string amountTemplate = Console.ReadLine();
int amount = CheckAmount( amountTemplate );

Console.Write( "Введите Ваше имя: " );
string name = Console.ReadLine();

Console.Write( $"{name}, введите адрес доставки: " );
string address = Console.ReadLine();

bool approve = ApproveOrder( title, amount, name, address );
if ( approve )
{
    DateTime orderDay = CheckDays();
    Console.WriteLine( $"{name}! Ваш заказ {title} в количестве {amount} оформлен! Ожидайте доставку по адресу {address} к {orderDay.ToLongDateString()}." );
}

static int CheckAmount( string amount )
{
    while ( ( int.TryParse( amount, out int amo ) == false ) & ( amo <= 0 ) )
    {
        Console.WriteLine( $"Введите корректное количество товара: " );
        amount = Console.ReadLine();
    }
    int.TryParse( amount, out int amo2 );
    return amo2;
}

static DateTime CheckDays()
{
    DateTime nowDay = DateTime.Today;
    return nowDay.AddDays( 3 );
}

static bool ApproveOrder( string title, int amount, string name, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {amount} {title} на адрес {address}, все верно?" );
    Console.Write( "Введите 'Да' для подтверждения заказа, и 'Нет' для его отмены: " );
    string userData = Console.ReadLine();
    if ( ( userData == "Да" ) | ( userData == "да" ) | ( userData == "'Да'" ) | ( userData == "'да'" ) )
    {
        return true;
    }
    else
    {
        Console.WriteLine( $"Ваш ответ {userData} был распознан, как 'Нет'." );
        Console.Write( "Подтвердите отмену заказа, введя слово 'ОТМЕНА': " );
        userData = Console.ReadLine();
        if ( ( userData == "ОТМЕНА" ) | ( userData == "'ОТМЕНА'" ) | ( userData == "отмена" ) | ( userData == "'отмена'" ) )
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}