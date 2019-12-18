using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultKeywordProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test with a non-empty list of integers.
            GenericList<int> gll = new GenericList<int>();
            gll.AddNode(5);
            gll.AddNode(4);
            gll.AddNode(3);
            int intVal = gll.GetLast();
            // The following line displays 5.
            System.Console.WriteLine(intVal);

            // Test with an empty list of integers.
            GenericList<int> gll2 = new GenericList<int>();
            intVal = gll2.GetLast();
            // The following line displays 0.
            System.Console.WriteLine(intVal);

            // Test with a non-empty list of strings.
            GenericList<string> gll3 = new GenericList<string>();
            gll3.AddNode("five");
            gll3.AddNode("four");
            string sVal = gll3.GetLast();
            // The following line displays five.
            System.Console.WriteLine(sVal);

            // Test with an empty list of strings.
            GenericList<string> gll4 = new GenericList<string>();
            sVal = gll4.GetLast();
            // The following line displays a blank line.
            System.Console.WriteLine("String Default value: {0}", sVal??"null");

            // Test with an empty list of doubles.
            GenericList<double> gll5 = new GenericList<double>();
            double dVal = gll5.GetLast();
            // The following line displays a blank line.
            System.Console.WriteLine("Double Default value: {0}", dVal);

            // Test with an empty list of structs.
            GenericList<SomeStruct> gll6 = new GenericList<SomeStruct>();
            SomeStruct structVal = gll6.GetLast();
            // The following line displays a blank line.
            System.Console.WriteLine("SomeStruct Default value: {0}", structVal);
        }
    }
   public  struct SomeStruct
    {
        public int IntData { get; set; }
        public string StrData { get; set; }
        public SomeStruct(int iVal, string sVal)
        {
            IntData = iVal;
            StrData = sVal;               
        }
        public override string ToString()
        {
            return string.Format("IntData: {0}:StrData: {1}", IntData, StrData??"null");
        }
    }

    // T is the type of data stored in a particular instance of GenericList.
    public class GenericList<T>
    {
        private class Node
        {
            // Each node has a reference to the next node in the list.
            public Node Next;
            // Each node holds a value of type T.
            public T Data;
        }

        // The list is initially empty.
        private Node head = null;

        // Add a node at the beginning of the list with t as its data value.
        public void AddNode(T t)
        {
            Node newNode = new Node();
            newNode.Next = head;
            newNode.Data = t;
            head = newNode;
        }

        // The following method returns the data value stored in the last node in
        // the list. If the list is empty, the default value for type T is
        // returned.
        public T GetLast()
        {
            // The value of temp is returned as the value of the method. 
            // The following declaration initializes temp to the appropriate 
            // default value for type T. The default value is returned if the 
            // list is empty.
            T temp = default(T);

            Node current = head;
            while (current != null)
            {
                temp = current.Data;
                current = current.Next;
            }
            return temp;
        }
    }
}

