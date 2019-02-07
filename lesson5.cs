using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace lesson5_namespace
{
    public class Lesson2
    {
        static public void Main ()
        {        
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
            
        }
        static private void Exercise1()
        {
            /* 1. Создать программу, которая будет проверять корректность 
            ввода логина. Корректным логином будет строка от 2 до 10 
            символов, содержащая только буквы латинского алфавита или цифры, 
            при этом цифра не может быть первой:
            а) без использования регулярных выражений;
            метод А реализован не будет, так как он не интересный
            б) с использованием регулярных выражений.*/
            Console.WriteLine ("Input login:");            
            string login = Console.ReadLine();
            if (LoginCheck(login)){
                Console.WriteLine ($"provided login is good");
            }else{
                Console.WriteLine ($"provided login is not good");
            }
            
        }        
        static private bool LoginCheck(string login){    
            string pattern = @"^[a-z]{1}([a-z]|\d){1,9}$";
            Regex check_reg = new Regex(pattern);
            return check_reg.IsMatch(login);
        }
        static private void Exercise2()
        {
            /*
            2. Разработать класс Message, содержащий следующие 
            статические методы для обработки текста:
            а) Вывести только те слова сообщения, которые 
            содержат не более n букв.
            б) Удалить из сообщения все слова, которые 
            заканчиваются на заданный символ.
            в) Найти самое длинное слово сообщения.
            г) Сформировать строку с помощью StringBuilder 
            из самых длинных слов сообщения.
            Продемонстрируйте работу программы на текстовом 
            файле с вашей программой.
            */
            Console.WriteLine ("Input n:");
            int a = int.Parse(Console.ReadLine ());
            Console.WriteLine ("Input message:");
            string m = Console.ReadLine();
            MyMessage.partA(m, a);
            Console.WriteLine ("Input symbol:");
            char b = char.Parse(Console.ReadLine ());                
            Console.WriteLine ($"Result for del: {MyMessage.partB(m, b)}");                                
            Console.WriteLine ($"the most long word: {MyMessage.partC(m)}");                                
            Console.WriteLine ($"New string: {MyMessage.partD(m)}");
        }
        static private void Exercise3()
        {
            /*
            *Для двух строк написать метод, определяющий, 
            является ли одна строка перестановкой другой.
            Например:
            badc являются перестановкой abcd.
            */
            Console.WriteLine ("Input string 1:");
            string s1 = Console.ReadLine ();
            Console.WriteLine ("Input string 2:");
            string s2 = Console.ReadLine ();         
            Console.WriteLine ($"Result: {CompareStr(s1, s2)}");        
        }
        static private bool CompareStr(string s1, string s2)
        {
            if (s1.Length==s2.Length){
                char[] sch1 = s1.ToLower().ToCharArray();
                char[] sch2 = s2.ToLower().ToCharArray();
                var different = sch1.Except(sch2).ToList();
                if (different.Count == 0){
                    return true;
                }
            }
            return false;                
        }
        static private void Exercise4()
        {
            /*
            4. Задача ЕГЭ.
            *На вход программе подаются сведения о сдаче экзаменов 
            учениками 9-х классов некоторой среднейшколы. В первой 
            строке сообщается количество учеников N, которое 
            не меньше 10, но не превосходит 100, каждая из следующих 
            N строк имеет следующий формат:
            <Фамилия> <Имя> <оценки>,
            где <Фамилия> — строка, состоящая не более чем 
            из 20 символов, <Имя> — строка, состоящая не
            более чем из 15 символов, <оценки> — через пробел 
            три целых числа, соответствующие оценкам по пятибалльной 
            системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> 
            разделены одним пробелом.
            Пример входной строки:
            Иванов Петр 4 5 3
            Требуется написать как можно более эффективную программу, 
            которая будет выводить на экран фамилии и имена трёх 
            худших по среднему баллу учеников. Если среди остальных 
            есть ученики, набравшие тот же средний балл, что и один 
            из трёх худших, следует вывести и их фамилии и имена.
            */
            string[] file_strings = File.ReadAllLines(@"/home/pavel/t/l5ege.txt");
            int string_count = int.Parse(file_strings[0]);
            double worst_grade1 = 16.0;
            double worst_grade2 = 16.0;
            double worst_grade3 = 16.0;
            double tmp = 0;
            string name = string.Empty;
            Dictionary<string, double> pupils = new Dictionary<string, double>(string_count);
            for (int i = 1; i<string_count+1; i++){
                string[] string_parts = file_strings[i].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                tmp = (double.Parse(string_parts[2])+double.Parse(string_parts[3])+double.Parse(string_parts[4]))/3.0;
                name = string_parts[0]+' '+string_parts[1];
                pupils.Add(name, tmp);
                Console.WriteLine($"{name}, {tmp}");
                if (tmp<worst_grade1){
                    worst_grade1 = tmp;
                } else if (tmp<worst_grade2){
                    worst_grade2 = tmp;
                } else if (tmp<worst_grade3){
                    worst_grade3 = tmp;
                }
            }
            foreach (var item in pupils)
            {
                if (item.Value==worst_grade1||item.Value==worst_grade2||item.Value==worst_grade3){
                    Console.WriteLine(item.Key);
                }                
            }
        }
    }
}