using System;
using System.IO;


struct User
{
    private string _login;
    private string _password;
    public User(string l, string p)
    {                    
        _login = l;
        _password = p;        
    }
    public string Login
    {
        /// <summary>
        /// Доступ к логину на чтение
        /// </summary>
        get 
        { 
            return _login;
        }        
    }
    public string Password
    {
        /// <summary>
        /// Доступ к паролю на чтение
        /// </summary>
        get 
        { 
            return _password;
        }        
    }
}

namespace lesson4_namespace
{
    public class Lesson2
    {
        static public void Main ()
        {        
            //Exercise1();
            //Exercise2();
            //Exercise3();
            Exercise4();            
        }
        #region Exercise1                
        static private void Exercise1()
        {
            /*
            1. Дан целочисленный массив из 20 элементов. 
            Элементы массива могут принимать целые значения 
            от –10 000 до 10 000 включительно. Написать 
            программу, позволяющую найти и вывести количество 
            пар элементов массива, в которых хотя бы одно 
            число делится на 3. В данной задаче под парой 
            подразумевается два подряд идущих элемента массива. 
            Например, для массива из пяти элементов: 
            6; 2; 9; –3; 6 – ответ: 4.
            */
            int[] a = new int[20];
            FillArrayRandom(ref a, -10000, 10000);
            Console.WriteLine ($"Pairs count size: {CountPairs(a, 3)}");
        }
        static private void FillArrayRandom(ref int[] a, int min, int max)
        {            
            Random rnd = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(min,max);
            }
        }
        static private int CountPairs(int[] a, int b)
        {            
            int count = 0;
            for (int i = 0; i < a.Length-1; i++)
            {
                if (a[i]%b==0||a[i+1]%b==0)
                {
                    count ++;
                }                
            }
            return count;
        }
        #endregion

        #region Exercise2
        static private void Exercise2()
        {
            /*
            2. а) Дописать класс для работы с одномерным массивом. 
            Реализовать конструктор, создающий массив заданной 
            размерности и заполняющий массив числами от начального 
            значения с заданным шагом. Создать свойство Sum, которые 
            возвращают сумму элементов массива, метод Inverse, 
            меняющий знаки у всех элементов массива, метод Multi, 
            умножающий каждый элемент массива на определенное число, 
            свойство MaxCount, возвращающее количество максимальных 
            элементов. В Main продемонстрировать работу класса.

            б)Добавить конструктор и методы, которые загружают 
            данные из файла и записывают данные в файл.
            */
            MyArray a = new MyArray("random", 25, 0, 10);
            Console.WriteLine(a.ToString());
            MyArray b = new MyArray("custom", 10, 1, 3);
            Console.WriteLine(b.ToString());
            MyArray c = new MyArray("file", 0, 0, 0);
            Console.WriteLine(c.ToString());
            c.ToFile();
            Console.WriteLine($"MAX_COUNT: {a.MaxCount()}");
            a.Inverse();
            Console.WriteLine(a.ToString());
            a.Multi(3);
            Console.WriteLine(a.ToString());
            Console.WriteLine($"SUM: {a.Sum()}");
        }
        #endregion

        #region Exercise3
        static private void Exercise3()
        {
            /*
            3. Решить задачу с логинами из предыдущего урока, 
            только логины и пароли считать из файла в массив. 
            Создайте структуру Account, содержащую Login и Password.
            */                                    
            string[] file_strings = File.ReadAllLines(@"/home/pavel/t/login.txt");                                     
            User current_user = new User(file_strings[0], file_strings[1]);            
            if(pswdCheck(current_user.Login, current_user.Password))
            {                
                Console.WriteLine ($"{current_user.Login} {current_user.Password} Password OK");
            }
            else
            {                
                Console.WriteLine ($"{current_user.Login} {current_user.Password} Password not OK");
                return;
            }
        }
        static private bool pswdCheck(string login, string password )
        {
            string valid_login = "root";
            string valid_password = "GeekBrains";
            return login.Equals(valid_login)&&password.Equals(valid_password);
        }
        #endregion

        #region Exercise4
        static private void Exercise4()
        {
            /*
            4. *а) Реализовать класс для работы с двумерным массивом. 
            Реализовать конструктор, заполняющий массив случайными 
            числами. Создать методы, которые возвращают сумму всех 
            элементов массива, сумму всех элементов массива больше 
            заданного, свойство, возвращающее минимальный элемент 
            массива, свойство, возвращающее максимальный элемент 
            массива, метод, возвращающий номер максимального элемента 
            массива (через параметры, используя модификатор ref или out)

            *б) Добавить конструктор и методы, которые загружают 
            данные из файла и записывают данные в файл.
            Дополнительные задачи
            в) Обработать возможные исключительные ситуации при работе с файлами.
            */                                    
            MyArray2 a = new MyArray2(10, 15, 0, 10);
            Console.WriteLine(a.ToString());
            Console.WriteLine($"SUM: {MyArray2.Sum(ref a)}");
            Console.WriteLine($"SUM more than 5: {MyArray2.Sum(ref a, 5)}");
            Console.WriteLine($"Min: {a.Min}");
            Console.WriteLine($"Max: {a.Max}");
            Console.WriteLine($"Max: {a.MaxX()}");
            MyArray2 b = new MyArray2(true);
            b.ToFile();
        }
        #endregion
    }
}