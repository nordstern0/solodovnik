using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace solodovnik07
{
    class Program
    {
        //Основной код программы
        static void Main(string[] args)
        {
            var st1 = new Student("Valrii", "Zhmishenko", "Albertovich", 'A', "CIT", "Comp_Logic", new DateTime(2000, 11, 19), new DateTime(2017, 7, 23), 88);
            var st2 = new Student("Collov", "Ivan", "Reichovich", 'B', "CIT", "Comp_Logic", new DateTime(2002, 10, 16), new DateTime(2020, 8, 21), 57);
            Collection arr = new(st1);
            arr.AddStudent(st2);
            arr.Print();

            Console.WriteLine("Доступ к элементу-----------------------------------------------");
            var st3 = new Student("Dmitriy", "Vaysberg", "Sidorovich", 'B', "CIT", "AI", new DateTime(2001, 8, 23), new DateTime(2020, 7, 20), 99);
            arr.AddStudent(st3);
            arr.GetStudent(2);

            Console.WriteLine("Удаление-----------------------------------------------");
            arr.RemoveElement(1);
            arr.Print();

            Console.WriteLine("Вставка-----------------------------------------------");
            arr.InsertStudent(0, st2);
            arr.Print();
            Console.WriteLine("Количество элементов в контейнере: " + arr.Size());

            CollHelper helper = new();
            float avga = helper.AverageAge(Student.CompareFaculty, "CIT", arr);
            Console.WriteLine("Средний возраст: " + avga);

            avga = helper.AveragePerformance(Student.CompareFaculty, "CIT", arr);
            Console.WriteLine("Средняя успеваемость: " + avga);

            Console.WriteLine("Студенты группы Б: ");
            helper.PrintStudentsByGroup(arr, 'B');

            Console.WriteLine("Время доступа-----------------------------------------------");
            Stopwatch time1 = new();
            Stopwatch time2 = new();
            time1.Start();
            Student exp1 = arr[0];
            time1.Stop();

            time2.Start();
            Student exp2 = arr.GetStudent(0);
            time2.Stop();

            Console.WriteLine("Индексирование \t" + time1.Elapsed.ToString());

            Console.WriteLine("LINQ \t" + time2.Elapsed.ToString());
        }
    }
}
