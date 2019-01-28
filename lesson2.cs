using System;
using System.Linq;
 
public class Lesson2
{
    static public void Main ()
    {        
        Exercise1();
        Exercise2();
        Exercise3();
        Exercise4();
        Exercise5();
        Exercise6();
        Exercise7();
    }
    static private void Exercise1()
    {
        /*
        1. Написать метод, возвращающий минимальное из трех чисел.
        */
        Console.WriteLine ("Input a:");
        int a = int.Parse(Console.ReadLine ());
        Console.WriteLine ("Input b:");
        int b = int.Parse(Console.ReadLine ());
        Console.WriteLine ("Input c:");
        int c = int.Parse(Console.ReadLine ());
        Console.WriteLine ($"Minimum: {MinInt(a, b, c)}");        
    }
    static private int MinInt(int a, int b, int c)
    {
        if (a<b)
        {
            if (a<c)
            {
                return a;
            }
            else
            {
                return c;
            }
        }
        else
        {
            if (b<c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }
    }
    static private void Exercise2()
    {
        /*
        2. Написать метод подсчета количества цифр числа.
        */
        Console.WriteLine ("Input number:");
        double number = double.Parse(Console.ReadLine ());
        Console.WriteLine ($"Number count: {NumberCount(number)}");        
    }
    static private int NumberCount(double number)
    {
        /*
        Можно конечно заниматься делением на 10, брать остаток и тд
        */
        string numberString = number.ToString();
        numberString = numberString.Replace(",", "");
        return numberString.Length;
    }
    static private void Exercise3()
    {
        /* 3. С клавиатуры вводятся числа, пока не будет введен 0. 
        Подсчитать сумму всех нечетных положительных чисел. */
        int sum = 0;
        int number;
        do
        {
            number = int.Parse(Console.ReadLine ());
            if (checkNumber(number))
            {
                sum += number;
            }
        } while (number != 0);
        Console.WriteLine ($"Sum: {sum}");  
    }
    static private bool checkNumber(int number)
    {
        return number>0&&checkOdd(number);
    }
    static private bool checkOdd(int number)
    {
        return number%2!=0;
    }
    static private void Exercise4()
    {
        /*
        4. Реализовать метод проверки логина и пароля.
        На вход подается логин и пароль. На выходе истина,
        если прошел авторизацию, и ложь, если не прошел 
        (Логин: root, Password: GeekBrains). 
        Используя метод проверки логина и пароля, 
        написать программу: пользователь вводит логин и пароль, 
        программа пропускает его дальше или не пропускает. 
        С помощью цикла do while ограничить ввод пароля тремя попытками.
        */
        int try_count = 0;
        bool result = false;
        do 
        {
            Console.WriteLine ("Input login:");
            string login = Console.ReadLine ();
            Console.WriteLine ("Input password:");
            string password = Console.ReadLine ();
            result = pswdCheck(login, password);
            try_count++;
        } while (!result&&try_count<3);
        if (try_count>=3)
        {
            Console.WriteLine ("You ran out of try");
            return;
        }
        else
        {
            Console.WriteLine ("Password OK");
        }
        
    }
    static private bool pswdCheck(string login, string password )
    {
        string valid_login = "root";
        string valid_password = "GeekBrains";
        return login.Equals(valid_login)&&password.Equals(valid_password);
    }
    static private void Exercise5()
    {
        /*
        5. а) Написать программу, которая запрашивает массу и рост
        человека, вычисляет его индекс массы и сообщает, нужно ли
        человеку похудеть, набрать вес или все в норме;
        б) *Рассчитать, на сколько кг похудеть или сколько
        кг набрать для нормализации веса.
         */
        Console.Write("Input weight:");
        double weight = double.Parse(Console.ReadLine());
        Console.Write("Input height:");
        double height = double.Parse(Console.ReadLine());
        double imt = IMT(weight, height);
        Console.WriteLine($"Your index is {imt}");
        Console.WriteLine(getDescription(imt, height));
    }
    static private double IMT(double weight, double height)
    {
        return weight/(height*height);
    }    
    static private string getDescription(double imt, double height)
    {
        string description = string.Empty;
        string add_description = string.Empty;
        if (imt < 16)
        {
            description = "Выраженный дефицит массы тела";            
        }
        else if (imt<=19)
        {
            description = "Недостаточная (дефицит) масса тела";
        }
        else if (imt<=25)
        {
            description = "Норма";
        }
        else if (imt<=30)
        {
            description = "Избыточная масса тела (предожирение)";
        }
        else if (imt<=35)
        {
            description = "Ожирение";
        }
        else if (imt<=40)
        {
            description = "Ожирение резкое";
        }
        else if (imt>40)
        {
            description = "Очень резкое ожирение";
        }
        if (imt<25)
        {
            add_description = $", нужно набрать {getAdvice(imt, 25, height):F2} кг";
        }
        else
        {
            add_description = $", нужно похудеть на {getAdvice(imt, 25, height):F2} кг";
        }
        return string.Concat(description, add_description);
    }
    static private string getAdvice(double imt, double need_imt, double height)
    {
        return Math.Abs((height*height)*(need_imt-imt)).ToString();
    }
    static private void Exercise6()
    {
        /*6. *Написать программу подсчета количества «Хороших»
        чисел в диапазоне от 1 до 1 000 000 000. Хорошим называется
        число, которое делится на сумму своих цифр. 
        Реализовать подсчет времени выполнения программы, 
        используя структуру DateTime.
        Результат: 
        Result: 61574509, time: 00:00:38.6287580
        ________________________________________
        Linux 18 64bits, 
        Intel(R) Core(TM) i5-4460  CPU @ 3.20GHz
        Kingston 8GiB 1333 MHz
        */                
        int number_count = 0;                 
        DateTime start=DateTime.Now;
        for (int i=1; i< 1000000000; i++)        
        {            
            if (i%NumberSum(i)==0)
            {
                number_count++;
            }
        }
        Console.WriteLine($"Result: {number_count}, time: {DateTime.Now-start}");
    }
    static private int NumberSum(int number)
    {
        int sum = 0;
        while(number != 0)
        {
            sum += number % 10;
            number /= 10;            
        }
        return sum;
    }
    static private void Exercise7()
    {
        /*7. a) Разработать рекурсивный метод, который
        выводит на экран числа от a до b (a<b);
        б) *Разработать рекурсивный метод, который 
        считает сумму чисел от a до b.*/
        Console.Write("Input a:");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Input b:");
        int b = int.Parse(Console.ReadLine());
        if (a < b)
        {
            RecursivePrint(a, b);
            Console.WriteLine($"Result{RecursiveSum(a, b)}");
        }
        else
        {
            Console.WriteLine("Spanish: 'lo siento a es menos que b' ");
        }
    }
    static private void RecursivePrint(int a, int b)
    {
        if (a <= b)
        {
            Console.WriteLine($"R {a}");            
            RecursivePrint(a+1, b);
        }
        else
        {
            return;
        }
    }
    static private int RecursiveSum(int a, int b)
    {
        if (a == b)
        {                        
            return b;
        }
        else
        {
            return RecursiveSum(a+1, b) + a;            
        }
    }
}