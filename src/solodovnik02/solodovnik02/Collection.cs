using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace solodovnik02
{
    public class Collection : IEnumerator, IEnumerable
    {
        private List<Student> catalog;
        private int position = -1;
        public Collection(Student student)
        {
            catalog = new List<Student>() { student };
        }
        public void AddStudent(Student student)
        {
            catalog.Add(student);
        }
        public void InsertStudent(int index, Student student)
        {
            catalog.Insert(index, student);
        }
        public void Print()
        {
            foreach (var stud in catalog)
            {
                stud.GetInfo();
            }
        }
        public int Size()
        {
            return catalog.Count;
        }
        public void RemoveAll()
        {
            catalog.Clear();
        }
        public void RemoveElement(int index)
        {
            catalog.RemoveAt(index);
        }
        public void GetStudent(int index)
        {
            catalog[index].GetInfo();
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            position++;
            return (position < catalog.Count);
        }
        public void Reset()
        {
            position = 0;
        }
        public object Current
        {
            get { return catalog.ElementAt<Student>(position); }
        }
    }
}
