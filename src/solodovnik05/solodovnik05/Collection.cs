using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solodovnik05
{
    public class Collection : IEnumerator, IEnumerable
    {
        private List<Student> Catalog;
        private int position = -1;
        public Student this[int index]
        {
            get
            {
                return Catalog[index];
            }
            set
            {
                Catalog[index] = value;
            }
        }
        public Collection()
        {
            Catalog = new List<Student>();
        }
        public Collection(Student student)
        {
            Catalog = new List<Student>() { student };
        }
        public Collection(List<Student> studList)
        {
            Catalog = studList;
        }
        public void AddStudent(Student student)
        {
            Catalog.Add(student);
        }
        public void InsertStudent(int index, Student student)
        {
            Catalog.Insert(index, student);
        }
        public void Print()
        {
            foreach (var stud in Catalog)
            {
                stud.GetInfo();
            }
        }
        public int Size()
        {
            return Catalog.Count;
        }
        public void RemoveAll()
        {
            Catalog.Clear();
        }
        public void RemoveElement(int index)
        {
            Catalog.RemoveAt(index);
        }
        public void GetStudent(int index)
        {
            Catalog[index].GetInfo();
        }
        public Student GetStudentObj(int index)
        {
            return Catalog[index];
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            position++;
            return (position < Catalog.Count);
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get { return Catalog.ElementAt<Student>(position); }
        }
    }
}
