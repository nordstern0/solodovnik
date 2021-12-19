using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System;

namespace solodovnik03
{
    public class CollHelper
    {
        public void WriteToFile(string filename, Collection array)
        {
            string[] lines;
            lines = new string[array.Size()];
            int i = 0;
            StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Default);
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

            StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default);
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
    }
}
