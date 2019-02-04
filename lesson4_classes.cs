using System;
using System.IO;


namespace lesson4_namespace
{

    class MyArray
    {
        int[] a;
        //  Создание массива и заполнение его одним значением el  
        public MyArray(int n, int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }
        //  Создание массива и заполнение его случайными числами от min до max
        public MyArray(string init_type, int n, int min, int max)
        {
            /// <summary>
            /// Конструктор с параметрами
            /// запоняет массив случайными числами если init_type == random
            /// запоняет массив числами от min значения 
            /// с шагом max если init_type == custom
            /// запоняет массив числами из файла если init_type == file
            /// 
            /// </summary>            
            switch (init_type)
            {                
                case "random":                                
                    a = new int[n];
                    Random rnd = new Random();
                    for (int i = 0; i < n; i++)
                    {
                        a[i] = rnd.Next(min,max);
                    }
                    break;                
                case "custom":
                    a = new int[n];
                    a[0] = min;
                    for (int i = 1; i < n; i++)
                    {
                        a[i] = a[i-1] + max;
                    }
                    break;
                case "file":
                    string[] file_strings = File.ReadAllLines(@"/home/pavel/t/data.txt");
                    a = new int[file_strings.Length];
                    bool flag = false;
                    int x = 0;
                    for(int i = 0; i < file_strings.Length; i++)
                    {
                        flag = int.TryParse(file_strings[i], out x);
                        if (flag)
                        {
                            a[i] = x;
                        }
                        else
                        {
                            a[i] = 0;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Wrong type: type random, custom, or file");
                    break;
            }        
        }
        
        public int Max
        {
            get 
            { 
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s=s+v+" ";
            return s;
        }
        public void ToFile()
        {
            string[] output_strings = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                output_strings[i] = a[i].ToString();
            }
            File.WriteAllLines(@"/home/pavel/t/out.txt", output_strings);
        }
        public int Sum()
        {
            int ssum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                ssum =+ a[i];
            }
            return ssum;
        }
        public void Inverse()
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = -a[i];
            }
        }
        public void Multi(int number)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i]*number;
            }
        }
        public int MaxCount()
        {
            int max = a[0];
            int max_count = 0;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
            }            
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == max)
                {
                    max_count++;
                }
            }
            return max_count;
        }
        
    }
    class MyArray2
    {
        public int[,] a;
        
        //  Создание массива и заполнение его случайными числами от min до max
        public MyArray2(int size_x, int size_y, int min, int max)
        {
            
            a = new int[size_x, size_y];
            Random rnd = new Random();
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                {
                    a[i, j] = rnd.Next(min,max);
                }
            }
        }
        public MyArray2(bool f)
        {
            
            string[] file_strings = File.ReadAllLines(@"/home/pavel/t/data2x2.txt");            
            bool flag = false;
            int x = 0;
            string[] numbers;
            numbers = file_strings[0].Split(',');
            a = new int[file_strings.Length, numbers.Length];
            for(int i = 0; i < file_strings.Length; i++)
            {
                numbers = file_strings[i].Split(',');
                for(int j = 0; j < numbers.Length; j++)
                {
                    flag = int.TryParse(numbers[j], out x);
                    if (flag)
                    {
                        a[i, j] = x;
                    }
                    else
                    {
                        a[i, j] = 0;
                    }
                }
            }
        }
        static public int Sum(ref MyArray2 arr)
        {
            int ssum = 0;
            for (int i = 0; i < arr.a.GetLength(0); i++)
            {
                for (int j = 0; j < arr.a.GetLength(1); j++)
                {
                    ssum += arr.a[i, j];
                }
            }
            return ssum;
        }
        static public int Sum(ref MyArray2 arr, int more_than)
        {
            int ssum = 0;
            for (int i = 0; i < arr.a.GetLength(0); i++)
            {
                for (int j = 0; j < arr.a.GetLength(1); j++)
                {
                    if (arr.a[i, j] > more_than)
                    {
                        ssum += arr.a[i, j];
                    }
                }
            }
            return ssum;
        }
        //свойство, возвращающее минимальный элемент массива, 
        public int Min
        {
            get
            {
                int min = a[0,0];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] < min)
                        {
                            min = a[i, j];
                        }
                    }
                }
                return min;
            }
        }
        //свойство, возвращающее максимальный элемент массива, 
        public int Max
        {
            get 
            {                 
                int max = a[0,0];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] > max)
                        {
                            max = a[i, j];
                        }
                    }
                }
                return max;
            }
        }
        //метод, возвращающий номер максимального элемента массива
        public string MaxX()
        {                                 
            string result = string.Empty;         
            int max = this.Max;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] == max)
                    {
                        max = a[i, j];
                        result = i.ToString()+", "+j.ToString();
                    }
                }
            }
            return result;            
        }
        //метод записи в файл
        public void ToFile()
        {
            string[] output_strings = new string[a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    output_strings[i] += a[i, j].ToString()+", ";
                }
            }
            File.WriteAllLines(@"/home/pavel/t/out.txt", output_strings);
        }
        // метод вывода 
        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s = s+a[i, j].ToString()+", ";
                }
                s = s+'\n';
            }
            return s;
        }
    }
}