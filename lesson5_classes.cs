using System;
using System.IO;
using System.Text;


namespace lesson5_namespace
{

    class MyMessage
    {
        /*
                2. Разработать класс Message, содержащий следующие 
                статические методы для обработки текста:
                а) .
                б) 
                в) Найти самое длинное слово сообщения.
                г) Сформировать строку с помощью StringBuilder 
                из самых длинных слов сообщения.
                Продемонстрируйте работу программы на текстовом 
                файле с вашей программой.
                */        
        //private string[] words;

        static public void partA(string str_in, int word_len){
            /*Вывести только те слова сообщения, которые 
                содержат не более n букв*/
            string[] words = str_in.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in words){
                if (item.Length<word_len){
                    Console.WriteLine(item);
                }
            }
        }
        static public string partB(string str_in, char symbol){
            /*Удалить из сообщения все слова, которые 
                заканчиваются на заданный символ.*/
            string[] words = str_in.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            foreach (var item in words){
                if (item[item.Length-1]!=symbol){
                    result.Append(item);
                    result.Append(' ');
                }
            }
            return result.ToString();
        }
        static public string partC(string str_in){
            /* Найти самое длинное слово сообщения. */
            string[] words = str_in.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);            
            int max_length = 0;
            string result = string.Empty;
            foreach (var item in words){
                if (item.Length>max_length){
                    max_length = item.Length;
                    result = item;
                }
            }
            return result;
        }
        static public string partD(string str_in){
            /* Сформировать строку с помощью StringBuilder 
               из самых длинных слов сообщения. 
               Задание не однозначно, поэтому сформируем строку 
               из слова имеющего максимальную длинну, которая 
               соделжит  такое же количество слов, что и исходная*/            
            string[] words = str_in.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);            
            int message_word_count = words.Length;
            string max_length_word = MyMessage.partC(str_in);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < message_word_count; i++){
                result.Append(max_length_word);
                result.Append(' ');
            }
            return result.ToString();
        }
        
        
    }
}