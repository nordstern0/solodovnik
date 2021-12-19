using System;
using System.IO;
using System.Threading.Tasks;

namespace solodovnik03
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var st1 = new Student("Valerii", "Zhmisheno", "Albertovich", 'A', "CIT", "Comp_Logic", new DateTime(2000, 11, 19), new DateTime(2017, 7, 23), 88);
            var st2 = new Student("Vaitalii", "Tsal", "Solyanovich", 'B', "CIT", "Comp_Logic", new DateTime(2002, 10, 16), new DateTime(2020, 8, 21), 57);
            Collection arr = new(st1);
            arr.AddStudent(st2);
            arr.Print();

            Console.WriteLine("Доступ к элементу-----------------------------------------------");
            var st3 = new Student("Oleg", "Mongol", "Tatarovich", 'D', "CIT", "Comp_Logic", new DateTime(2001, 8, 23), new DateTime(2020, 7, 20), 99);
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

            Collection TestArr = new();
            CollHelper helper = new();
            helper.WriteToFile("s_data.txt", arr);
            helper.ReadFromFile("s_data.txt", TestArr);
            Console.WriteLine("Прочитанный массив-----------------------------------------------");
            TestArr.Print();
        }
    }
}
