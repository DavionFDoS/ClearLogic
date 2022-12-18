using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearLogic.Handlers;

public class MenuHandler
{
    public string ShowMenu()
    {

        Console.WriteLine("Выберите пункт меню: ");
        Console.WriteLine("1. Ввод исходных данных");
        Console.WriteLine("2. Вывод рабочей памяти");
        Console.WriteLine("3. Очистка рабочей памяти");
        Console.WriteLine("4. Ввод правил");
        Console.WriteLine("5. Вывод списка правил");
        Console.WriteLine("6. Очистка списка правил");
        Console.WriteLine("7. Прямой поиск решений (от данных к цели)");
        Console.WriteLine("8. Обратный поиск решений (от цели к данным)");
        Console.WriteLine("9. Выход");
        
        var menuPoint = Console.ReadLine()!;

        return menuPoint;
    }
}
