using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public delegate double Fun(double a, double x);

class Student
{
    public string _name;
    public string _second_name;
    public string _univercity;
    public string _faculty;
    public string _department;
    public int _age;
    public int _course; 
    public int _group;
    public string _city;


    public Student(string name, string second_name, string univercity, string faculty, 
    string department,int age, int course, int group, string city)
    {
        _name = name;
        _second_name = second_name;
        _univercity = univercity;
        _faculty = faculty;
        _department = department;
        _course = course;
        _age = age;
        _group = group;
        _city = city;
    }
}

public class Lesson2
{
    static public void Main ()
    {        
        Exercise1();
        Exercise2();
        Exercise3();        
    }
    #region Exercise1      
    static private void Exercise1()
    {
        /*
        1. Изменить программу вывода функции так, 
        чтобы можно было передавать функции типа 
        double (double,double). Продемонстрировать 
        работу на функции с функцией a*x^2 и функцией a*sin(x).
        */                
        Console.WriteLine("Таблица функции MyFunc:");                
        Table(MyFuncAX2, 5, -2, 2); 
        Console.WriteLine("Таблица функции a*Sin(x):");
        Table(MyFuncASinX, 5, -2, 2);              
    }
    public static void Table(Fun F, double a, double x, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }
    // Создаем метод для передачи его в качестве параметра в Table
    public static double MyFuncAX2(double a, double x)
    {
        return a * x * x;
    }
    public static double MyFuncASinX(double a, double x)
    {
        return a * Math.Sin(x);
    }
    #endregion
    #region Exercise2
    static private void Exercise2()
    {
        /*
        2. Модифицировать программу нахождения минимума функции 
        так, чтобы можно было передавать функцию в виде делегата.

        а) Сделайте меню с различными функциями и предоставьте 
        пользователю выбор, для какой функции и на каком отрезке 
        находить минимум.
        б) Используйте массив (или список) делегатов, 
        в котором хранятся различные функции.
        #! задание не понятно
        в) *Переделайте функцию Load, чтобы она возвращала массив 
        считанных значений. Пусть она возвращает минимум через параметр.
        */                
        string my_file = @"/home/pavel/t/data.bin";
        Console.WriteLine("Выберите функцию(введите номер):\n 1) a*x*x\n 2) a*sin(x)");
        string selection = Console.ReadLine();
        Console.WriteLine("Введите отрезок расчета сначала a, затем b, и потом шаг");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        switch (selection)
        {
            case "1":
                SaveFunc(MyFuncAX2, my_file, a, b, h);
                break;
            case "2":
                SaveFunc(MyFuncASinX,my_file, a, b, h);
                break;
            default:
                Console.WriteLine("Вы ввели неизвестную команду");
                break;
        }        
        Console.WriteLine(Load(my_file));
        foreach (double item in LoadReworked(my_file))
        {
            Console.WriteLine(item);
        }
        Console.ReadKey();
    }    
    public static void SaveFunc(Fun F ,string fileName, double a, double b, double h)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        double x = a;
        while (x<=b)
        {
            bw.Write(F(2, x));
            x += h;// x=x+h;
        }
        bw.Close();
        fs.Close();
    }
    public static double Load(string fileName)
    {
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);
        double min = double.MaxValue;
        double d;
        for(int i=0;i<fs.Length/sizeof(double);i++)
        {
                    // Считываем значение и переходим к следующему
            d = bw.ReadDouble();
            if (d < min) min = d;
        }
        bw.Close();
        fs.Close();
        return min;
    }
    public static List<double> LoadReworked(string fileName)
    {
        List<double> result = new List<double>();
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);        
        for(int i=0;i<fs.Length/sizeof(double);i++)
        {                    
            result.Add(bw.ReadDouble());            
        }
        bw.Close();
        fs.Close();
        return result;
    }
    #endregion
    #region Exercise3      
    static private void Exercise3()
    {
        /*
        3. Переделать программу «Пример использования 
        коллекций» для решения следующих задач:

        а) Подсчитать количество студентов учащихся 
        на 5 и 6 курсах;
        б) подсчитать сколько студентов в возрасте от 
        18 до 20 лет на каком курсе учатся (частотный массив);
        в) отсортировать список по возрасту студента;
        г) *отсортировать список по курсу и возрасту студента;
        д) разработать единый метод подсчета 
        количества студентов по различным параметрам
        выбора с помощью делегата и методов предикатов.
        */                
        int bakalavr = 0;
        int magistr = 0;
        int students_5_6 = 0;
        Dictionary<int, int> chastot_arr = new Dictionary<int, int>();
        Dictionary<string, int> student_dict = new Dictionary<string, int>();
        // Создадим необобщенный список
        ArrayList list = new ArrayList();
        List<Student> custom_list = new List<Student>();
        // Запомним время в начале обработки данных
        DateTime dt = DateTime.Now;
        StreamReader sr = new StreamReader(@"/home/pavel/t/students_1.csv");
        while(!sr.EndOfStream)
        {
            try {
                string[] s = sr.ReadLine().Split(';');
        // Console.WriteLine("{0}", s[0], s[1], s[2], s[3], s[4]);
                list.Add(s[1]+" "+s[0]);// Добавляем склееные имя и фамилию
                student_dict.Add(s[1]+" "+s[0], int.Parse(s[6]));
                custom_list.Add(new Student(s[0], 
                                    s[1], 
                                    s[2], 
                                    s[3], 
                                    s[4], 
                                    int.Parse(s[5]), 
                                    int.Parse(s[6]), 
                                    int.Parse(s[7]),
                                    s[8]));
                if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                if (int.Parse(s[6])>4) students_5_6++;
                if (!chastot_arr.ContainsKey(int.Parse(s[6]))){ 
                    chastot_arr.Add(int.Parse(s[6]), 1); 
                }
                else{
                    chastot_arr[int.Parse(s[6])]++;
                }
            }
            catch
            {
            }
        }
        sr.Close();
        list.Sort();  
        //student_dict.OrderBy(pair => pair.Value);
        Console.WriteLine("Всего студентов:{0}", list.Count);
        Console.WriteLine("Магистров:{0}", magistr);
        Console.WriteLine("Бакалавров:{0}", bakalavr);
        Console.WriteLine($"Задание А кол-во студентов на 5-6 курсах:{students_5_6}");
        foreach (var item in chastot_arr){
             Console.WriteLine($"На курсе № {item.Key} учится {item.Value}");
        }
        //foreach (var v in student_dict.OrderBy(pair => pair.Value)) Console.WriteLine($"{v.Key} - {v.Value}");
        foreach (var obj in custom_list.OrderBy(x => x._course).ThenBy(x => x._age)){
            Console.WriteLine($"{obj._name} - {obj._second_name} - {obj._course} - {obj._age}");
        }
        // Вычислим время обработки данных
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();
             
    }
    
    
    #endregion
}