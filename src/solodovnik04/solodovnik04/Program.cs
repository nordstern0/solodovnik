using System;
using System.Threading.Tasks;

namespace solodovnik04
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var st1 = new Student("Zhmishenko", "Valerii", "Albertovich", 'A', "CIT", "Computer Logic", new DateTime(2000, 11, 19), new DateTime(2017, 7, 23), 88);
            var st2 = new Student("Zelenskii", "Vladimir", "Vladimirovich", 'B', "CIT", "Computer Logic", new DateTime(2002, 10, 16), new DateTime(2020, 8, 21), 57);
            Collection arr = new(st1);
            arr.AddStudent(st2);
            arr.Print();

            Console.WriteLine("Доступ к элементу-----------------------------------------------");
            var st3 = new Student("Vladimir", "Putin", "Molodets", 'D', "CIT", "Computer Logic", new DateTime(2001, 8, 23), new DateTime(2020, 7, 20), 99);
            arr.AddStudent(st3);
            arr.GetStudent(2);

            Console.WriteLine("Удаление-----------------------------------------------");
            arr.RemoveElement(1);
            arr.Print();

            Console.WriteLine("Вставка-----------------------------------------------");
            arr.InsertStudent(0, st2);
            arr.Print();
            Console.WriteLine("Количество элементов в контейнере: " + arr.Size());

            Console.WriteLine("Запись в файл-----------------------------------------------");

            //Collection TestArr = new();
            CollHelper helper = new();
            helper.GetStudyInfo(arr, 0);
            helper.GetStudentAge(arr, 1);
            Console.WriteLine("Студент " + arr.GetStudentObj(0).SurName + " " + arr.GetStudentObj(0).Name + " в данный момент учится на " + arr.GetStudentObj(0).Сourse + " курсе (" + arr.GetStudentObj(0).Semester + " семестр)");
            Console.WriteLine("Студент " + arr.GetStudentObj(1).SurName + " " + arr.GetStudentObj(1).Name + " в данный момент учится на " + arr.GetStudentObj(1).Сourse + " курсе (" + arr.GetStudentObj(1).Semester + " семестр)");
            //helper.WriteToFile("s_data.txt", arr);
            //helper.ReadFromFile("s_data.txt", TestArr);
            //Console.WriteLine("Прочитанный массив-----------------------------------------------");
            //TestArr.Print();
        }
    }
}
