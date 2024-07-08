Console.Write( "Введите название товара: " );
string label = Console.ReadLine();

Console.Write( $"Введите необходимое количество товара {label}: " );
string tempQuantity = Console.ReadLine();
int amount = CheckAmount( tempQuantity );

Console.Write( "Введите Ваше имя: " );
string name = Console.ReadLine();

Console.Write( $"{name}, введите адрес доставки: " );
string address = Console.ReadLine();

bool approve = ApproveOrder( label, amount, name, address );
if ( approve )
{
    DateTime orderDay = AddThreeDays();
    Console.WriteLine( $"{name}! Ваш заказ {label} в количестве {amount} оформлен! Ожидайте доставку по адресу {address} к {orderDay.ToLongDateString()}." );
}

static int CheckAmount( string amount )
{
    while ( ( int.TryParse( amount, out int amountTemplate ) == false ) && ( amountTemplate <= 0 ) )
    {
        Console.WriteLine( $"Введите корректное количество товара: " );
        amount = Console.ReadLine();
    }
    int.TryParse( amount, out int amountCorrect );
    return amountCorrect;
}

static DateTime AddThreeDays()
{
    DateTime nowDay = DateTime.Today;
    return nowDay.AddDays( 3 );
}

static bool ApproveOrder( string title, int amount, string name, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {amount} {title} на адрес {address}, все верно?" );
    Console.Write( "Введите 'Да' для подтверждения заказа, и 'Нет' для его отмены: " );
    string userData = Console.ReadLine().ToLower();
    if ( ( userData == "да" ) || ( userData == "'да'" ) )
    {
        return true;
    }
    else
    {
        Console.WriteLine( $"Ваш ответ {userData} был распознан, как 'Нет'." );
        Console.Write( "Подтвердите отмену заказа, введя слово 'ОТМЕНА': " );
        userData = Console.ReadLine().ToLower();
        if ( ( userData == "отмена" ) || ( userData == "'отмена'" ) )
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}