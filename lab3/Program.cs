using bll;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
theatre t = new();
ConsoleKeyInfo key = default(ConsoleKeyInfo);
void menu()
{
    Console.Clear();
    Console.WriteLine("Вибери дію:");
    Console.WriteLine("0.Вивести список вистав");
    Console.WriteLine("1.Вивести список вистав з квитками");
    Console.WriteLine("2.Додати три тестові вистави");
    Console.WriteLine("3.Додати виставу");
    Console.WriteLine("4.Видалити виставу");
    Console.WriteLine("5.Продати квиток");
    Console.WriteLine("6.Забронювати квиток");
    Console.WriteLine("7.Продати заброньований квиток");
    Console.WriteLine("8.Видалити всі вистави і квитки");
    Console.WriteLine("9.Вихід з програми");
}
void Add_play()
{
    Console.Clear();
    Console.WriteLine("Введи назву вистави");
    string name=Console.ReadLine() ?? "не ввів назву";
    Console.WriteLine("Введи назву автора");
    string autor = Console.ReadLine() ?? "не ввів автора";
    Console.WriteLine("Введи назву жанру вистави");
    string genre = Console.ReadLine() ?? "не ввів жанр";
    Console.WriteLine("Введи рік");
    int.TryParse(Console.ReadLine(), out int y);
    if (y == 0) y = 1;
    Console.WriteLine("Введи місяць");
    int.TryParse(Console.ReadLine(), out int m);
    if (m == 0) m = 1;
    Console.WriteLine("Введи день");
    int.TryParse(Console.ReadLine(), out int d);
    if (d == 0) d = 1;
    Console.WriteLine("ціну квитка першого типу");
    int.TryParse(Console.ReadLine(), out int price1);
    Console.WriteLine("Введи кількість квитків першого типу");
    int.TryParse(Console.ReadLine(), out int count1);
    Console.WriteLine("Введи ціну квитка другого типу");
    int.TryParse(Console.ReadLine(), out int price2);
    Console.WriteLine("Введи кількість квитків другого типу");
    int.TryParse(Console.ReadLine(), out int count2);
    t.PlayAdd(name, autor, genre, y, m, d, price1, count1, price2, count2);
    Console.WriteLine("Виставу додано");
    Console.ReadKey();
}
void Dell_play()
{
    Console.Clear();
    Console.WriteLine(t.get_plays());
    Console.WriteLine("Введи назву вистави,яку бажаєш видалити");
    string name = Console.ReadLine() ?? "не ввів назву";
    t.Playdell(name);
    Console.WriteLine(t.get_plays());
    Console.ReadKey();
}
void sell()
{
    Console.Clear();
    Console.WriteLine(t.get_playsandtickets());
    Console.WriteLine("продаж квитка:");
    Console.WriteLine("Введи назву вистави");
    string Pname = Console.ReadLine() ?? "не ввів назву вистави";
    Console.WriteLine("Введи ціну квитка");
    int.TryParse(Console.ReadLine(), out int price);
    Console.WriteLine("Введи назву покупця");
    string Owner = Console.ReadLine() ?? "не ввів назву вистави";
    t.selling(Pname, price, Owner);
    Console.WriteLine(t.get_playsandtickets());
    Console.ReadKey();
}
void booking()
{
    Console.Clear();
    Console.WriteLine(t.get_playsandtickets());
    Console.WriteLine("бронювання квитка:");
    Console.WriteLine("Введи назву вистави");
    string Pname = Console.ReadLine() ?? "не ввів назву вистави";
    Console.WriteLine("Введи ціну квитка");
    int.TryParse(Console.ReadLine(), out int price);
    Console.WriteLine("Введи назву бажаючого забронювати");
    string Owner = Console.ReadLine() ?? "не ввів назву вистави";
    t.booking(Pname, price, Owner);
    Console.WriteLine(t.get_playsandtickets());
    Console.ReadKey();
}
void booking_sell()
{
    Console.Clear();
    Console.WriteLine(t.get_playsandtickets());
    Console.WriteLine("продаж заброньованого квитка:");
    Console.WriteLine("Введи назву вистави");
    string Pname = Console.ReadLine() ?? "не ввів назву вистави";
    Console.WriteLine("Введи ціну квитка");
    int.TryParse(Console.ReadLine(),out int price);
    Console.WriteLine("Введи назву покупця");
    string Owner = Console.ReadLine() ?? "не ввів назву вистави";
    t.bookingsell(Pname, price, Owner);
    Console.WriteLine(t.get_playsandtickets());
    Console.ReadKey();
}
void play_list()
{
    Console.Clear();
    Console.WriteLine(t.get_plays());
    Console.ReadKey();
}
void playAndTicket_list()
{
    Console.Clear();
    Console.WriteLine(t.get_playsandtickets());
    Console.ReadKey();
}
void AddTestDate()
{
    t.add_testdata();
    Console.Clear();
    Console.WriteLine(t.get_playsandtickets());
    Console.ReadKey();
}
void dell()
{
    Console.Clear();
    t.dell_all();
    Console.WriteLine("все видалено");
    Console.WriteLine(t.get_playsandtickets());
    Console.ReadKey();
}
while (key.KeyChar != '9')
{
    menu();
    key = Console.ReadKey();
    switch (key.KeyChar)
    {
        case '0': play_list(); break;
        case '1': playAndTicket_list(); break;
        case '2': AddTestDate(); break;
        case '3': Add_play(); break;
        case '4': Dell_play(); break;
        case '5': sell(); break;
        case '6': booking(); break;
        case '7': booking_sell(); break;
        case '8': dell(); break;
        default: break;
    }
}
