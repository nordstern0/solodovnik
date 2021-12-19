using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Text;

namespace solodovnik04
{
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
            string ReadDataLine = "";
            string[] ReadDataArr;
            string[] BirthTimeDate;
            string[] AdmTimeDate;

            StreamReader sr = new(filename, System.Text.Encoding.Default);
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
        public void GetStudyInfo(Collection array, int index)
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
    }
}
