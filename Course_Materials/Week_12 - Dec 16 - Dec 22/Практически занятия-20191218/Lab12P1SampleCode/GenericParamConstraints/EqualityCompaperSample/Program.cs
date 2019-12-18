using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityCompaperSample
{
    class Program
    {
        static void Main(string[] args)
        {
            BoxEqDimensions bxd = new BoxEqDimensions();
            BoxEqVolume bxv = new BoxEqVolume();
            BoxEqGuid bxg = new BoxEqGuid();
            EqualityComparer<Box> bxDef =  EqualityComparer<Box>.Default;

            Dictionary<Box, string> boxesByDim = new Dictionary<Box, string>(bxd);
            Dictionary<Box, string> boxesByVol = new Dictionary<Box, string>(bxv);
            Dictionary<Box, string> boxesByGuid = new Dictionary<Box, string>(bxg);
            // Use the default implementation of GetHashCode() in Box
            Dictionary<Box, string> boxesByDefault = new Dictionary<Box, string>(bxDef);
            try
            {
                Box redBox = new Box(8, 8, 4);
                Box blueBox = new Box(6, 8, 4);
                Box greenBox = new Box(4, 8, 8);

                Console.WriteLine("Adding boxes by Dimension");
                Console.WriteLine(bxd.GetHashCode(redBox));
                boxesByDim.Add(redBox, "red");
                boxesByDim.Add(blueBox, "blue");
                boxesByDim.Add(greenBox, "green");

                PrintBoxCollection(boxesByDim, bxd);

                Console.WriteLine("\nAdding boxes by Volume"); 
                boxesByVol.Add(redBox, "red");
                boxesByVol.Add(blueBox, "blue");
                // cannot be added, greenBox has the same hashCode as redBox
                //boxesByVol.Add(greenBox, "green");

                PrintBoxCollection(boxesByVol, bxv);

                Console.WriteLine("\nAdding boxes by Guid");
                Console.WriteLine(bxg.GetHashCode(redBox));
                boxesByGuid.Add(redBox, "red");        
                boxesByGuid.Add(blueBox, "blue");               
                boxesByGuid.Add(greenBox, "green");

                PrintBoxCollection(boxesByGuid, bxg);

                Console.WriteLine("\nAdding boxes by Default");
                // Both return the same hashcode
                Console.WriteLine(bxDef.GetHashCode(redBox));
                Console.WriteLine(redBox.GetHashCode());
                boxesByDefault.Add(redBox, "red");
                boxesByDefault.Add(blueBox, "blue");
                boxesByDefault.Add(greenBox, "green");
                PrintBoxCollection(boxesByDefault, bxDef);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
        private static void PrintBoxCollection(Dictionary<Box, string> boxes, EqualityComparer<Box> ec)
        {
            foreach (KeyValuePair<Box, string> kvp in boxes)
            {
                Console.WriteLine("{0} x {1} x {2} - {3}- {4}", kvp.Key.Height.ToString(),
                                                           kvp.Key.Length.ToString(),
                                                           kvp.Key.Width.ToString(), kvp.Value,
                                                           ec.GetHashCode(kvp.Key));
            }
        }
    }

    public class BoxEqDimensions : EqualityComparer<Box>
    { //  Box(8, 8, 4) and  Box(4, 8, 8) have same hashcode but not equal
        public override int GetHashCode(Box bx)
        {
            if (bx == null) return int.MaxValue.GetHashCode();
            int hCode = bx.Height ^ bx.Length ^ bx.Width;
            return hCode.GetHashCode();
        }

        public override bool Equals(Box b1, Box b2)
        {
            if (b1 == null && b2 == null) return true;
            if (b1 == null || b2 == null) return false;
            return EqualityComparer<Box>.Default.Equals(b1, b2);
        }
    }

    public class BoxEqGuid : EqualityComparer<Box>
    {
        public override int GetHashCode(Box bx)
        {
            if (bx == null) return int.MaxValue.GetHashCode();
            return bx.ID.GetHashCode();
        }

        public override bool Equals(Box b1, Box b2)
        {
            if (b1 == null && b2 == null) return true;
            if (b1 == null || b2 == null) return false;
            return b1.ID== b2.ID;
        }
    }

    public class BoxEqVolume : EqualityComparer<Box>
    {   //  Box(8, 8, 4) and Box(4, 8, 8) have same hashcode but equal
        // Box(4, 8, 8) is not added to the Dicitonary
        public override int GetHashCode(Box bx)
        {   if (bx == null) return int.MaxValue.GetHashCode();
            int hCode = bx.Height ^ bx.Length ^ bx.Width;
            return hCode.GetHashCode();
        }

        public override bool Equals(Box b1, Box b2)
        {
            if (b1 == null && b2 == null) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Height * b1.Width * b1.Length ==
                b2.Height * b2.Width * b2.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class Box : IEquatable<Box>
    {
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public readonly string ID;
        public Box(int h, int l, int w)
        {
            this.Height = h;
            this.Length = l;
            this.Width = w;
            ID =  Guid.NewGuid().ToString();// struct Guid creates a random Guid
        }

        public bool Equals(Box other)
        {
            if (other == null) return false;
            return this.ID == other.ID;
        }
        public override int GetHashCode()
        {

            return this.ID.GetHashCode();
        }
        //public bool Equals(Box other)
        //{
        //    if (other == null) return false;
        //    if (this.Height == other.Height & this.Length == other.Length
        //        & this.Width == other.Width)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
