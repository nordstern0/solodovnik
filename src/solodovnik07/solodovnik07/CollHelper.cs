using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Text;

namespace solodovnik07
{
    //Класс для взаимодействия с коллекцией
    public class CollHelper
    {
        public void WriteToFile(string filename, Collection array)
        {
            string[] lines;
            lines = new string[array.Size()];
            int i = 0;
            StreamWriter sw = new(filename, false, System.Text.Encoding.Default);
            foreach (Student stud in array)
            {
                lines[i] = stud.ToString();
                i++;
            }
            for (i = 0; i < lines.Length; i++)
            {
                sw.WriteLine(lines[i]);
            }
            sw.Close();
        }
        public void ReadFromFile(string filename, Collection array)
        {
            string[] ReadDataArr;
            string[] BirthTimeDate;
            string[] AdmTimeDate;

            StreamReader sr = new(filename, System.Text.Encoding.Default);
            string ReadDataLine;
            while ((ReadDataLine = sr.ReadLine()) != null)
            {
                ReadDataArr = ReadDataLine.Split(" ");
                BirthTimeDate = ReadDataArr[6].Split("-");
                AdmTimeDate = ReadDataArr[7].Split("-");

                Student new_student = new(ReadDataArr[0], ReadDataArr[1], ReadDataArr[2], Convert.ToChar(ReadDataArr[3]), ReadDataArr[4], ReadDataArr[5], new DateTime(Convert.ToInt32(BirthTimeDate[2]), Convert.ToInt32(BirthTimeDate[1]), Convert.ToInt32(BirthTimeDate[0])), new DateTime(Convert.ToInt32(AdmTimeDate[2]), Convert.ToInt32(AdmTimeDate[1]), Convert.ToInt32(AdmTimeDate[0])), Convert.ToByte(ReadDataArr[8]));
                array.AddStudent(new_student);
            }
            sr.Close();
        }
        public void PrintStudyInfo(Collection array, int index)
        {
            StringBuilder info = new("| Факультет: ");
            info.Append(array.GetStudentObj(index).Facul);
            info.Append("| Специальность: ");
            info.Append(array.GetStudentObj(index).Spec);
            info.Append("| Год поступления: ");
            info.Append(array.GetStudentObj(index).GetDateOfAdmission().Year);
            info.Append("| Индекс группы: ");
            info.Append(array.GetStudentObj(index).GIndex);
            Console.WriteLine(info.ToString());
        }
        public void GetStudentAge(Collection array, int index)
        {
            var today = DateTime.Today;
            var age = today.Year - array.GetStudentObj(index).GetDateOfBrth().Year;
            if (array.GetStudentObj(index).GetDateOfBrth().Date > today.AddYears(-age)) age--;
            Console.WriteLine("Возраст студента: " + age);
        }
        public void PrintStudentsByGroup(Collection array, char group)
        {
            array.Reset();
            Console.WriteLine("------------------------------------------------------------------");
            var query = from Student stud in array
                        where stud.GIndex == @group
                        select stud;
            foreach (Student s in query)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("------------------------------------------------------------------");
        }
        public void PrintStudentsByFaculty(Collection array, string f)
        {
            array.Reset();
            Console.WriteLine("------------------------------------------------------------------");
            var query = from Student stud in array
                        where stud.Facul == f
                        select stud;
            foreach (Student s in query)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("------------------------------------------------------------------");
        }
        public void PrintStudentsBySpeciality(Collection array, string sp)
        {
            array.Reset();
            Console.WriteLine("------------------------------------------------------------------");
            var query = from Student stud in array
                        where stud.Spec == sp
                        select stud;
            foreach (Student s in query)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("------------------------------------------------------------------");
        }
        public void RemoveStudentsByGroup(Collection array, char group)
        {
            for (int i = 0; i < array.Size(); i++)
            {
                if (array[i].GIndex == group)
                {
                    array.RemoveElement(i);
                }
            }
        }
        public void RemoveStudentsByFaculty(Collection array, string f)
        {
            for (int i = 0; i < array.Size(); i++)
            {
                if (array[i].Facul == f)
                {
                    array.RemoveElement(i);
                }
            }
        }
        public void RemoveStudentsBySpeciality(Collection array, string sp)
        {
            for (int i = 0; i < array.Size(); i++)
            {
                if (array[i].Spec == sp)
                {
                    array.RemoveElement(i);
                }
            }
        }
        public float AverageAge(Student.Compare comp, string line, Collection array)
        {
            array.Reset();
            float total = 0;
            int count = 0;
            IEnumerable<int> query =
                from Student stud in array
                where comp(stud, line)
                select stud.Age;

            foreach (var age in query)
            {
                total += age;
                count++;
            }
            return total / count;
        }

        public float AveragePerformance(Student.Compare comp, string line, Collection array)
        {
            array.Reset();
            float total = 0;
            int count = 0;
            IEnumerable<byte> query =
                from Student stud in array
                where comp(stud, line)
                select stud.Perf;

            foreach (var mark in query)
            {
                total += mark;
                count++;
            }
            return total / count;
        }
    }
}
