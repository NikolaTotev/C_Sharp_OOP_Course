using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionClassSpecialization
{
    using System;
    using System.Collections.ObjectModel;

    public class AnimalFarm : Collection<Animal>
    {

        protected override void InsertItem(int i, Animal a)
        {
            base.InsertItem(i, a);
            Console.WriteLine("**InsertItem: {0}, {1}", i, a);
        }

        protected override void SetItem(int i, Animal a)
        {
            base.SetItem(i, a);
            Console.WriteLine("**SetItem: {0}, {1}", i, a);
        }

        protected override void RemoveItem(int i)
        {
            base.RemoveItem(i);
            Console.WriteLine("**RemoveItem: {0}", i);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            Console.WriteLine("**ClearItems");
        }

    }
    public enum AnimalGroup { Mammal, Bird, Fish };
    public enum Sex { Male, Female };

    public class Animal : IComparable<Animal>
    {
        private string name;
        private AnimalGroup? group;
        private Sex sex;

        public Animal(string name) :
            this(name, AnimalGroup.Mammal, Sex.Male)
        {
        }

        public Animal(string name, Sex sex) :
            this(name, AnimalGroup.Mammal, sex)
        {
        }

        public Animal(string name, AnimalGroup group, Sex sex)
        {
            this.name = name;
            this.group = group;
            this.sex = sex;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public AnimalGroup? Group
        {
            get
            {
                return group;
            }
        }

        public Sex Sex
        {
            get
            {
                return sex;
            }
        }

        public override string ToString()
        {
            return "Animal: " + name;
        }

        public int CompareTo(Animal other)
        {
            return this.name.CompareTo(other.name);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            else if (this.GetType() != obj.GetType())
                return false;
            else if (ReferenceEquals(this, obj))
                return true;
            else if (this.name == ((Animal)obj).name)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

    }
    public class App
    {

        public static void Main()
        {

            AnimalFarm af = new AnimalFarm();

            // Populating the farm with Add
            af.Add(new Animal("elephant"));
            af.Add(new Animal("giraffe"));
            af.Add(new Animal("tiger"));
            ReportList("Adding elephant, giraffe, and tiger with Add(...)", af);

            // Additional population with Insert
            af.Insert(0, new Animal("dog"));
            af.Insert(0, new Animal("cat"));
            ReportList("Inserting dog and cat at index 0 with Insert(0, ...)", af);

            // Mutate the animal farm:
            af[1] = new Animal("herring", AnimalGroup.Fish, Sex.Male);
            ReportList("After af[1] = herring", af);

            // Remove tiger
            af.Remove(new Animal("tiger"));
            ReportList("Removing tiger with Remove(...)", af);

            // Remove animal at index 2
            af.RemoveAt(2);
            ReportList("Removing animal at index 2, with RemoveAt(2)", af);

            // Clear the farm
            af.Clear();
            ReportList("Clear the farm with Clear()", af);
        }

        public static void ReportList<T>(string explanation, Collection<T> list)
        {
            Console.WriteLine(explanation);
            foreach (T el in list)
                Console.WriteLine("{0, 3}", el);
            Console.WriteLine(); Console.WriteLine();
        }
    }
}
