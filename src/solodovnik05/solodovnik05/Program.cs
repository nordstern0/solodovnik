using System;
using System.Collections.Generic;
using System.Text.Json;

namespace solodovnik05
{
    class Program
    {
        static void Main(string[] args)
        {
            var st1 = new Student("Zhmishenko", "Valerii", "Albertovich", 'A', "CIT", "Computer Logic", new DateTime(2000, 11, 19), new DateTime(2017, 7, 23), 88);
            var st2 = new Student("Vesta", "Lada", "Rossia", 'B', "CIT", "Computer Logic", new DateTime(2002, 10, 16), new DateTime(2020, 8, 21), 57);
            Collection arr = new(st1);
            arr.AddStudent(st2);
            arr.Print();

            Console.WriteLine("Доступ к элементу-----------------------------------------------");
            var st3 = new Student("Oleg", "Sidorov", "Sidorovich", 'B', "CS", "AI", new DateTime(2001, 8, 23), new DateTime(2020, 7, 20), 99);
            arr.AddStudent(st3);
            arr.GetStudent(2);

            Console.WriteLine("Удаление-----------------------------------------------");
            arr.RemoveElement(1);
            arr.Print();

            Console.WriteLine("Вставка-----------------------------------------------");
            arr.InsertStudent(0, st2);
            arr.Print();
            Console.WriteLine("Количество элементов в контейнере: " + arr.Size());

            //Collection TestArr = new();
            CollHelper helper = new();
            char index = 'B';
            string f = "CIT";
            string sp = "Comp_Logic";
            helper.PrintStudentsByGroup(arr, index);
            helper.PrintStudentsByFaculty(arr, f);
            helper.PrintStudentsBySpeciality(arr, sp);

            //helper.RemoveStudentsByFaculty(arr, "CS");
            //arr.Print();
            //Console.WriteLine("---------------------------------------------------------");
            //helper.RemoveStudentsByGroup(arr, 'B');
            //arr.Print();

            float avga = helper.AverageAge(Student.CompareFaculty, "CIT", arr);
            Console.WriteLine("Средний возраст: " + avga);

            avga = helper.AveragePerformance(Student.CompareFaculty, "CIT", arr);
            Console.WriteLine("Средняя успеваемость: " + avga);

            arr.Reset();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(arr, options);

            Console.WriteLine(jsonString);

            Collection studList2 = new Collection(JsonSerializer.Deserialize<List<Student>>(jsonString));
            studList2.Print();
        }
    }
}
