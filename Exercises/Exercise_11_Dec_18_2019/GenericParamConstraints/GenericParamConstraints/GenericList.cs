using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericParamConstraints
{
    class Test
    {
        static void Main()
        {
            GenericList<Employee> g = new GenericList<Employee>();
            g.AddHead(new Employee ("a",3 ) );
            Employee e = g.FindFirstOccurrence(new string('b', 1));
            Console.WriteLine(e!=null? e.ToString() : "Employee not found");
            
        }
    }
    public class Employee
    {
        private string name;
        private int id;

        public Employee(string s, int i)
        {
            name = s;
            id = i;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public override string ToString()
        {
            return "Name: " + Name +", ID: " + ID;
        }
    }
  
    public class GenericList<T> where T : Employee { 
        private class Node
        {
            private Node next;
            private T data;

            public Node(T t)
            {
                next = null;
                data = t;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        public GenericList() //constructor
        {
            head = null;
        }

        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T FindFirstOccurrence(string s)
        {
            Node current = head;
            T t = null;

            while (current != null)
            {
                //The constraint enables access to the Name property.
                if (current.Data.Name == s)
                {
                    t = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return t;
        }
    }
}
