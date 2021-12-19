using System;

namespace solodovnik04
{
    public class Student
    {
        //Поля
        private readonly string name;

        private string surname;

        private string patronymic;

        private readonly DateTime DOB;

        private readonly DateTime DOA;

        private char groupIndex;

        private string faculty;

        private string speciality;

        private byte performance;
        //Свойства
        public DateTime GetDateOfAdmission()
        {
            return DOA;
        }

        //public void SetDateOfAdmission(int year, int month, int day)
        //{
        //    DateCheck(year, month, day);
        //    DOA = new DateTime(year, month, day);
        //}

        public DateTime GetDateOfBrth()
        {
            return DOB;
        }
        //public void SetDateOfBrth(int year, int month, int day)
        //{
        //    DateCheck(year, month, day);
        //    DOB = new DateTime(year, month, day);
        //}
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

            //set
            //{
            //    name = value;
            //}
        }
        public byte Semester
        {
            get
            {
                int day = (int)((DateTime.Now - DOA).TotalDays % 365.2425); // Years
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
        public void GetInfo()
        {
            Console.WriteLine("Студент " + Name + " " + SurName + " " + Patronymic + " группы " + GIndex + " факультета " + Facul + " специальности " + Spec + ", " + GetDateOfBrth().ToString("dd-MM-yyyy") + " даты рождения, " + GetDateOfAdmission().ToString("dd-MM-yyyy") + " даты поступления имеет успеваемость " + Perf + "%");
        }
        public override string ToString()
        {
            return Name + " " + SurName + " " + Patronymic + " " + GIndex.ToString() + " " + Facul + " " + Spec + " " + GetDateOfBrth().ToString("dd-MM-yyyy") + " " + GetDateOfAdmission().ToString("dd-MM-yyyy") + " " + Perf.ToString();
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
        public void DateCheck(int year, int month, int day)
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
