using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace solodovnik07
{
    //Класс, олицетворяющий сущность "Студент"
    public class Student
    {
        //Поля класса
        private readonly string name;

        private string surname;

        private string patronymic;

        private readonly DateTime DOB;

        private readonly DateTime DOA;

        private char groupIndex;

        private string faculty;

        private string speciality;

        private byte performance;

        //Методы и свойства
        public DateTime GetDateOfAdmission()
        {
            return DOA;
        }
        public DateTime GetDateOfBrth()
        {
            return DOB;
        }
        public byte Perf
        {
            set
            {
                if (value > 100)
                {
                    Console.WriteLine("Успеваемость не может быть выше 100 и ниже 0 процентов!");
                }
                else
                {
                    performance = value;
                }
            }
            get { return performance; }
        }
        public string Spec
        {
            get
            {
                return speciality;
            }

            set
            {
                speciality = value;
            }
        }
        public string Facul
        {
            get
            {
                return faculty;
            }

            set
            {
                faculty = value;
            }
        }
        public char GIndex
        {
            get
            {
                return groupIndex;
            }

            set
            {
                groupIndex = value;
            }
        }

        public string Patronymic
        {
            get
            {
                return patronymic;
            }

            set
            {
                patronymic = value;
            }
        }

        public string SurName
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Age
        {
            get
            {
                return (int)((DateTime.Now - DOB).TotalDays / 365.2425);
            }
        }
        public byte Semester
        {
            get
            {
                int day = (int)((DateTime.Now - DOA).TotalDays % 365.2425);
                if (day < 150)
                {
                    return 1;
                }
                else return 2;
            }
        }
        public int Сourse
        {
            get
            {
                int year = (int)((DateTime.Now - DOA).TotalDays / 365.2425) + 1;
                if (year > 6) year = 6;
                else if (year < 0)
                {
                    year = 0;
                }
                return year;
            }
        }
        public Student() { }
        public Student(string nm, string srnm, string patr, char Gin, string fcl, string spc, DateTime Birth, DateTime Adm, byte persent)
        {
            DateCheck(Birth.Year, Birth.Month, Birth.Day);
            DateCheck(Adm.Year, Adm.Month, Adm.Day);
            name = nm;
            surname = srnm;
            patronymic = patr;
            groupIndex = Gin;
            faculty = fcl;
            speciality = spc;
            DOB = Birth;
            DOA = Adm;
            performance = persent;
        }

        public delegate bool Compare(Student stud, string line);

        public static bool CompareGroup(Student stud, char line)
        {
            if (stud.GIndex == line) return true;
            else return false;
        }

        public static bool CompareSpecialty(Student stud, string line)
        {
            if (stud.Spec == line) return true;
            else return false;
        }

        public static bool CompareFaculty(Student stud, string line)
        {
            if (stud.Facul == line) return true;
            else return false;
        }
        public void PrintInfo()
        {
            Console.WriteLine("Студент " + Name + " " + SurName + " " + Patronymic + " группы " + GIndex + " факультета " + Facul + " специальности " + Spec + ", " + GetDateOfBrth().ToString("dd-MM-yyyy") + " даты рождения, " + GetDateOfAdmission().ToString("dd-MM-yyyy") + " даты поступления имеет успеваемость " + Perf + "%");
        }
        public override string ToString()
        {
            return Name + " " + SurName + " " + Patronymic + " " + GIndex.ToString() + " " + Facul + " " + Spec + " " + GetDateOfBrth().ToString("dd-MM-yyyy") + " " + GetDateOfAdmission().ToString("dd-MM-yyyy") + " " + Perf.ToString();
        }
        public static void DateCheck(int year, int month, int day)
        {
            var currentYear = DateTime.Now.Year;
            if (year > currentYear)
            {
                Console.WriteLine("Год введен некорректно!");
            }
            if (month > 12 && month <= 0)
            {
                Console.WriteLine("Месяц введен некорректно!");
            }
            if (day > 31 && day <= 0)
            {
                Console.WriteLine("День введен некорректно!");
            }
        }
    }
}
