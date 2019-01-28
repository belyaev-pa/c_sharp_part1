using System;
 
public class Lesson1
{
    static public void Main ()
    {        
        //Exercise1();
        //Exercise2();
        //Exercise3();
        //Exercise4();
        Exercise5();
    }
    static private void Exercise1 ()
    {
        /*Написать программу «Анкета». Последовательно 
        задаются вопросы (имя, фамилия, возраст, рост, вес). 
        В результате вся информация выводится в одну строчку:
          а) используя  склеивание;
          б) используя форматированный вывод;
          в) используя вывод со знаком $. */
        Console.WriteLine ("Input your name buddy:");
        string name = Console.ReadLine ();
        Console.WriteLine ("Input your surname buddy:");
        string surname = Console.ReadLine ();
        Console.WriteLine ("Input your age buddy:");
        string age = Console.ReadLine ();
        Console.WriteLine ("Input your height buddy:");
        string height = Console.ReadLine ();
        Console.WriteLine ("Input your weight buddy:");
        string weight = Console.ReadLine ();                
        // а) используя  склеивание
        Console.WriteLine ("Hello buddy your name is " + name + "\n" + "surname is " + surname + "\n" + "age is " + age + "\n" + "height is " + height + "\n" + "weight is " + weight + "!");
        // б) используя форматированный вывод
        Console.WriteLine ("Hello buddy your name is {0}\nsurname is {1}\nage is {2}\nheight is {3}\nweight is {4}!", name, surname, age, height, weight);
        // в) используя вывод со знаком $.
        Console.WriteLine ($"Hello buddy your name is {name} \nsurname is {surname}\nage is {age}\nheight is {height}\nweight is {weight}!");
    }
    static private void Exercise2 ()
    {
        /* Ввести вес и рост человека. Рассчитать
        и вывести индекс массы тела (ИМТ) 
        по формуле I=m/(h*h); где m — масса тела в 
        килограммах, h — рост в метрах. */
        Console.Write("Input weight:");
        double weight = double.Parse(Console.ReadLine());
        Console.Write("Input height:");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("Index:" + I(weight, height));
    }
    static private double I(double weight, double height)
    {
        return weight/(height*height);
    }
    static private void Exercise3()
    {
        /* а) Написать программу, которая подсчитывает 
        расстояние между точками с координатами x1, y1 
        и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2).
        Вывести результат, используя спецификатор 
        формата .2f (с двумя знаками после запятой);
           б) *Выполнить предыдущее задание, оформив
        вычисления расстояния между точками в виде метода.*/
        Console.Write("Input x1:");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("Input y1:");
        double y1 = double.Parse(Console.ReadLine());
        Console.Write("Input x2:");
        double x2 = double.Parse(Console.ReadLine());
        Console.Write("Input y2:");
        double y2 = double.Parse(Console.ReadLine());
        Console.Write($"Distance is {DoMath(x1, y1, x2, y2):F2}\n");
    }
    static private double DoMath(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2, x1)+Math.Pow(y2, y1));
    }
    static private void Exercise4()
    {
        /* Написать программу обмена значениями двух переменных:
            а) с использованием третьей переменной;
            б) *без использования третьей переменной. */
        Console.Write("Input a:");
        int a = int.Parse(Console.ReadLine());        
        Console.Write("Input b:");
        int b = int.Parse(Console.ReadLine());
        Console.Write($"a: {a}, b: {b}");
        DoSwapA(ref a, ref b);
        Console.Write($"\nAfter DoSwapA \na: {a}, b: {b}");
        DoSwapB(ref a, ref b);
        Console.Write($"\nAfter DoSwapB \na: {a}, b: {b}\n");
    }
    static private void DoSwapA (ref int ref_a, ref int ref_b)
    {
        // usefull ref func https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref
        int t = ref_a;
        ref_a = ref_b;
        ref_b = t;
    }
    static private void DoSwapB (ref int ref_a, ref int ref_b)
    {
        ref_a = ref_a + ref_b;
        ref_b = ref_a - ref_b;
        ref_a = ref_a - ref_b;
    }
    static private void Exercise5()
    {
        /* а) Написать программу, которая выводит
              на экран ваше имя, фамилию и город проживания.
           б) *Сделать задание, только вывод организовать в центре экрана.
           в) **Сделать задание б с использованием 
              собственных методов (например, Print(string ms, int x,int y). */        
        string name = "Павел";
        string surname = "Беляев";
        string city = "Москва";
        Print(name, Console.BufferWidth/2 - 5, Console.BufferHeight/2 - 1, ConsoleColor.Red);
        Print(surname,  Console.BufferWidth/2 - 5, Console.BufferHeight/2, ConsoleColor.Yellow);
        Print(city,  Console.BufferWidth/2 - 5, Console.BufferHeight/2 + 1, ConsoleColor.Green);
    }
    static public void Print(string message, int x, int y, ConsoleColor foregroundcolor)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = foregroundcolor;
        Console.WriteLine(message);
    }
}