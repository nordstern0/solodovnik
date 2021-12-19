using System;

namespace solodovnik02
{
    public class Program
    {
        static void Main(string[] args)
        {
            var st1 = new Student("Zhmishenko", "Valerii", "Albertovich", 'A', "CIT", "Computer Logic", new DateTime(1999, 9, 27), new DateTime(2017, 6, 16), 25);
            var st2 = new Student("Vestov", "Denis", "Petrov", 'B', "CIT", "Computer Logic", new DateTime(1998, 10, 16), new DateTime(2018, 8, 21), 57);
            Collection arr = new(st1);
            arr.AddStudent(st2);
            arr.Print();

            Console.WriteLine("Доступ к элементу-----------------------------------------------");
            var st3 = new Student("Lindemann", "Till", "Petrovich", 'D', "CIT", "Computer Logic", new DateTime(2001, 8, 23), new DateTime(2020, 7, 20), 99);
            arr.AddStudent(st3);
            arr.GetStudent(2);

            Console.WriteLine("Удаление-----------------------------------------------");
            arr.RemoveElement(1);
            arr.Print();

            Console.WriteLine("Вставка-----------------------------------------------");
            arr.InsertStudent(0, st2);
            arr.Print();
            Console.WriteLine("Количество элементов в контейнере: " + arr.Size());

            foreach (Student stud in arr)
            {
                stud.GetInfo();
            }

            Console.WriteLine("Очистка-----------------------------------------------");
            arr.RemoveAll();
            if (arr.Size() == 0)
            {
                Console.WriteLine("Контейнер пуст");
            }
        }
    }
}
