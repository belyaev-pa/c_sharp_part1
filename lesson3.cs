using System;


struct Complex
{
    public double im;
    public double re;
    //  в C# в структурах могут храниться также действия над данными
    public Complex Plus(Complex x)
    {
        Complex y;
        y.im = im + x.im;
        y.re = re + x.re;
        return y;
    }
    public Complex Minus(Complex x)
    {
        Complex y;
        y.im = im - x.im;
        y.re = re - x.re;
        return y;
    }
    //  Пример произведения двух комплексных чисел
    public Complex Multi(Complex x)
    {
        Complex y;
        y.im = re * x.im + im * x.re;
        y.re = re * x.re - im * x.im;
        return y;
    }
    public override string ToString()
    {
        if (im<0)
        {
            return re + "-" + Math.Abs(im) + "i";
        }
        else
        {
            return re + "+" + im + "i";
        }
    }
}
class ComplexClass
{
    // Поля приватные.
    public double im;
    // По умолчанию элементы приватные, поэтому private можно не писать.
    public double re;

    // Конструктор без параметров.
    public ComplexClass()
    {
        im = 0;
        re = 0;
    }

    // Конструктор, в котором задаем поля.    
    // Специально создадим параметр re, совпадающий с именем поля в классе.
    public ComplexClass(double _im, double re)
    {
   // Здесь имена не совпадают, и компилятор легко понимает, что чем является.              
        im = _im;
        // Чтобы показать, что к полю нашего класса присваивается параметр,
        // используется ключевое слово this
        // Поле параметр
        this.re = re;
    }
    public ComplexClass Plus(ComplexClass x2)
    {
        ComplexClass x3 = new ComplexClass();
        x3.im = x2.im + im;
        x3.re = x2.re + re;
        return x3;
    }
    public ComplexClass Minus(ComplexClass x)
    {
        ComplexClass y = new ComplexClass();
        y.im = im - x.im;
        y.re = re - x.re;
        return y;
    }
    public ComplexClass Multiply(ComplexClass x)
    {
        ComplexClass y = new ComplexClass();
        y.im = re * x.im + im * x.re;
        y.re = re * x.re - im * x.im;
        return y;
    }
    // Свойства - это механизм доступа к данным класса.
    public double Im
    {
        get { return im; }
        set
        {
            // Для примера ограничимся только положительными числами.
            if (value >= 0) im = value;
        }
    }
    // Специальный метод, который возвращает строковое представление данных.
    public override string ToString()
    {
        if (im<0)
        {
            return re + "-" + Math.Abs(im) + "i";
        }
        else
        {
            return re + "+" + im + "i";
        }
    }
}



public class Fraction
{
    private int _num, _denom;

    public int Num
    {
        /// <summary>
        /// Доступ к числителю
        /// </summary>
        get 
        { 
            return _num;
        }
        set
        {
            _num = value;
        }
    }
    public Fraction()
    {
        /// <summary>
        /// Конструктор без параметров
        /// создает нулевую дробь, со знаменателем 1
        /// </summary>
        _num = 0;
        _denom = 1;
    }
    public Fraction(int a, int b)
    {            
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        _denom = b;
        _num = a;
        ZeroDenominatorCheck();
        Reduction();
    }
    public override string ToString()
    {
        return _num + " / " + _denom;
    }
    public int Denom
    {
        /// <summary>
        /// Доступ к знаменателю
        /// </summary>
        get
        {
            return _denom;
        }
        set
        {        
            if (value != 0)
            {
                _denom = value;
            }
            else
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю");
            }
        }
    }
    public double Decimal
    {
        /// <summary>
        /// Получение десятичной записи дроби
        /// </summary>
        get
        {                      
            return (double)_num/(double)_denom;  ;
        }
    }

    public Fraction Plus(Fraction member)
    {
        /// <summary>
        /// Функция суммирования
        /// </summary>
        Fraction result = new Fraction();
        result.Num = (_num*member.Denom) + (member.Num*_denom);
        result.Denom = member.Denom * _denom;
        result.ZeroDenominatorCheck();
        result.Reduction();
        return result;
    }
    public Fraction Minus(Fraction member)
    {
        /// <summary>
        /// Функция вычитания
        /// </summary>
        Fraction result = new Fraction();        
        result.Num = (_num*member.Denom) - (member.Num*_denom);        
        result.Denom = member.Denom * _denom;
        result.ZeroDenominatorCheck();
        result.Reduction();
        return result;
    }
    public Fraction Multiply(Fraction member)
    {
        /// <summary>
        /// Функция умножения
        /// </summary>
        Fraction result = new Fraction();
        result.Num = member.Num * _num;
        result.Denom = member.Denom * _denom;
        result.ZeroDenominatorCheck();
        result.Reduction();
        return result;
    }
    public Fraction Divide(Fraction member)
    {
        /// <summary>
        /// Функция деления
        /// </summary>
        Fraction result = new Fraction();
        result.Num = member.Num * _denom;
        result.Denom = member.Denom * _num;
        result.ZeroDenominatorCheck();
        result.Reduction();
        return result;
    }             
    public void Reduction()
    {
        /// <summary>
        /// Функция сокращения дроби
        /// ищем НОД, сокращаем и проверяем дробь на знак
        /// </summary>
        int nod = NODFind(_num, _denom);        
        BothNegative();
        _num /= nod;
        _denom /= nod;
    }
    private void BothNegative ()
    {
        /// <summary>
        /// Если числитель и знаменатель мешьне нуля, 
        /// делаем дробь положительной
        /// </summary>
        if (_num<0&&_denom<0)
        {
            _num = Math.Abs(_num);
            _denom = Math.Abs(_denom);
        }
    }
    static private int NODFind(int a, int b)
    {        
        /// <summary>
        /// Функция поиска НОД
        /// </summary>
        a = Math.Abs(a);
        b = Math.Abs(b);
        while ((a!=0)&&(b!=0))        
        {
            if (a>b)
            {
                a = a%b;
            }
            else
            {
                b = b%a;
            }
        }
        return (a+b);
    }
    private void ZeroDenominatorCheck()
    {
        /// <summary>
        /// Проверка отрицательного числителя        
        /// </summary>
        if (_denom == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен нулю");
        }
    }

}
	


public class Lesson3
{
    static public void Main ()
    {   
        Exercise1();  
        Exercise2();   
        Exercise3();
    }
    static private void Exercise1()
    {
        /*1. а) Дописать структуру Complex, добавив 
        метод вычитания комплексных чисел. 
        Продемонстрировать работу структуры;
        б) Дописать класс Complex, добавив методы 
        вычитания и произведения чисел. Проверить 
        работу класса; */
        Complex complex1;
        complex1.re = 1;
        complex1.im = 1;

        Complex complex2;
        complex2.re = 2;
        complex2.im = 2;

        Complex result = complex1.Minus(complex2);
        Console.WriteLine(result.ToString());  

        ComplexClass complexclass1 = new ComplexClass();
        complexclass1.re = 1;
        complexclass1.im = 1;

        ComplexClass complexclass2 = new ComplexClass();
        complexclass2.re = 2;
        complexclass2.im = 2;

        ComplexClass resultclass = complexclass1.Minus(complexclass2);
        Console.WriteLine($"Вычитание {resultclass.ToString()}");
        resultclass = complexclass1.Multiply(complexclass2);
        Console.WriteLine($"Умножение {resultclass.ToString()}");

    }
    static private void Exercise2()
    {
        /* а)  С клавиатуры вводятся числа, пока 
        не будет введён 0 (каждое число в новой строке). 
        Требуется подсчитать сумму всех нечётных 
        положительных чисел. Сами числа и сумму 
        вывести на экран, используя tryParse. */
        double sum = 0;
        double number;         
        string console_message = "Введите число (double): ";
        do
        {            
            number = GetDouble(console_message);            
            if (checkNumber(number))
            {
                Console.WriteLine ("Это хорошее число, мы его берем");        
                sum += number;
            }
            Console.WriteLine ($"СУММА: {sum}");
        } while (number != 0);
        Console.WriteLine ($"Sum: {sum}");
    }
    static double GetDouble(string message)
        {
            double x;
            string s;
            bool flag;                                      
            do
            {
                Console.WriteLine(message);
                s = Console.ReadLine();
                flag = double.TryParse(s, out x);
                if (!flag)
                {
                    Console.WriteLine("Введите число!!!");
                }
            } while (!flag);
            return x;
        }

    static private bool checkNumber(double number)
    {
        return number>0&&checkOdd(number);
    }
    static private bool checkOdd(double number)
    {   
        /// <summary>
        /// будем считать дробное число четным если его      
        /// целая часть делится на 2 без остатка
        /// </summary>
        return (int)number%2!=0;
    }
    static private void Exercise3()
    {
        /*
        *Описать класс дробей — рациональных чисел, являющихся
        отношением двух целых чисел. Предусмотреть методы:
         - сложения,
         - вычитания,
         - умножения,
         - деления дробей. 
        Написать программу, демонстрирующую все разработанные
        элементы класса.
        * Добавить свойства типа int для доступа к 
        числителю и знаменателю;
        * Добавить свойство типа double только на 
        чтение, чтобы получить десятичную дробь числа;
        ** Добавить проверку, чтобы знаменатель не 
        равнялся 0. Выбрасывать исключение 
        ArgumentException("Знаменатель не может быть равен 0");
        *** Добавить упрощение дробей.
        */
        Fraction fr1 = new Fraction(3, 2);
        Fraction fr2 = new Fraction(1, 4);
        Fraction result;
        result = fr1.Plus(fr2);
        Console.WriteLine ($"Result {fr1.ToString()} plus {fr2.ToString()} = {result.ToString()}");        
        fr1.Num = -1;
        fr1.Denom = 13;
        fr2.Num = 2;
        fr2.Denom =19;
        result = fr1.Minus(fr2);

        Console.WriteLine ($"Result {fr1.ToString()} minus {fr2.ToString()} = a = {result.Num}__{result.ToString()}");
        fr1.Num = 11;
        fr1.Denom = 12;
        fr2.Num = 7;
        fr2.Denom = 2;
        result = fr1.Multiply(fr2);
        Console.WriteLine ($"Result {fr1.ToString()} multiply {fr2.ToString()} = {result.ToString()}");
        fr1.Num = 13;
        fr1.Denom = 11;
        fr2.Num = 101;
        fr2.Denom = 17;
        result = fr1.Divide(fr2);
        Console.WriteLine ($"Result {fr1.ToString()} divide {fr2.ToString()} = {result.ToString()}");
        Console.WriteLine ($"Double result {fr1.ToString()} divide {fr2.ToString()} = {result.Decimal}");
    }
}