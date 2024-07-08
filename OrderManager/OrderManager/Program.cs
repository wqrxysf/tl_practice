Console.Write( "Введите название товара: " );
string label = Console.ReadLine();

Console.Write( $"Введите необходимое количество товара {label}: " );
string tempQuantity = Console.ReadLine();
int amount = ValidateAmount( tempQuantity );

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

static int ValidateAmount( string amount )
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
    Console.Write( "[1] - Подтвердить заказ" );
    Console.WriteLine( "[2] - Отменить заказ" );
    string userData = Console.ReadLine();
    while ( ( userData != "1" ) || ( userData != "2" ) )
    {
        Console.Write( "[1] - Подтвердить заказ" );
        Console.WriteLine( "[2] - Отменить заказ" );
        userData = Console.ReadLine();
    }
    if ( ( userData == "1" ) )
    {
        return true;
    }
    else
    {
        return false;
    }
}