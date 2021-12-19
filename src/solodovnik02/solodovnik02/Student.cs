using System;

namespace solodovnik02
{
    public class Student
    {
        //Поля
        private string name;

        private string surname;

        private string patronymic;

        DateTime DOB;

        DateTime DOA;

        private char groupIndex;

        private string faculty;

        private string speciality;

        private byte performance;
        //Свойства
        public DateTime GetDateOfAdmission()
        {
            return DOA;
        }

        public void SetDateOfAdmission(int year, int month, int day)
        {
            DateCheck(year, month, day);
            DOA = new DateTime(year, month, day);
        }

        public DateTime GetDateOfBrth()
        {
            return DOB;
        }
        public void SetDateOfBrth(int year, int month, int day)
        {
            DateCheck(year, month, day);
            DOB = new DateTime(year, month, day);
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

            set
            {
                name = value;
            }
        }

        public void GetInfo()
        {
            Console.WriteLine("Студент " + Name + " " + SurName + " " + Patronymic + " группы " + GIndex + " факультета " + Facul + " специальности " + Spec + ", " + GetDateOfBrth() + " даты рождения, " + GetDateOfAdmission() + " даты поступления имеет успеваемость " + Perf + "%");
        }

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
