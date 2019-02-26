using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
 
[Serializable]
public class Student
{
    public string name;
    public string second_name;
    public string univercity;
    public string faculty;
    public string department;
    public int age;
    public int course; 
    public int group;
    public string city;


    public Student(string name, string second_name, string univercity, string faculty, 
    string department,int age, int course, int group, string city)
    {
        this.name = name;
        this.second_name = second_name;
        this.univercity = univercity;
        this.faculty = faculty;
        this.department = department;
        this.course = course;
        this.age = age;
        this.group = group;
        this.city = city;
    }
    public Student()
    {
    }

}

public class Lesson8
{
    static public void Main ()
    {        
        // Exercise1();
        // Exercise2();
        // Exercise3();
        // Exercise4();
        Exercise5();        
    }
    static private void Exercise5()
    {
        /*
        5. **Написать программу-преобразователь из CSV в 
        XML-файл с информацией о студентах (6 урок).
        */
        List<Student> student_list = new List<Student>();
        StreamReader sr = new StreamReader(@"/home/pavel/t/students_1.csv");        
        while(!sr.EndOfStream)
        {
            try {
                string[] s = sr.ReadLine().Split(';');        
                student_list.Add(new Student(s[0], 
                                             s[1], 
                                             s[2], 
                                             s[3], 
                                             s[4], 
                                             int.Parse(s[5]), 
                                             int.Parse(s[6]), 
                                             int.Parse(s[7]),
                                             s[8]));                
            }
            catch
            {
            }
        }
        SaveAsXmlFormat(student_list, @"/home/pavel/t/students_1.xml");
        
    }
    static void SaveAsXmlFormat(List<Student> obj_list, string fileName)
        {        
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);        
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Student));
            foreach (var obj in obj_list)
            {                
                xmlFormat.Serialize(fStream, obj);
            }
            fStream.Close();
        }

}