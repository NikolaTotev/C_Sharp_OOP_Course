using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializeWithAppend
{
    public class Program
    {
        /// <summary>
        /// BinaryFormatter isn't appendable which means you'll need to reserialize 
        /// every time you need to modify the file.
        /// </summary>
        const string file = @"C:\temp\players.dat";
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; ++i)
            {
                List<Player> players = new List<Player>();
                players.Add(new Player { Name = "ACE", BelongsToTeam = "A"});
                players.Add(new Player { Name = "KING", BelongsToTeam = "K" });
                //Note: List<Player> is Serializable 
                AppendToDisk(players);// append players to file and close file
            }

            var list = ReadFromDisk<Player>();// read all multiple appends

            foreach (var item in list)
            {
                Console.Write(item);
            }

            // For a better solution try the following https://code.google.com/p/protobuf-net/wiki/GettingStarted
           
        }
        private static void AppendToDisk<T>(IEnumerable<T> collection)
        {
            var existing = ReadFromDisk<T>().ToList(); // read current file contents

            existing.AddRange(collection);// add the new collection of players to the one read from the file

            PersistToDisk(existing); // serialize all the players back to the file
        }

        private static void PersistToDisk<T>(ICollection<T> value)
        {
            if (!File.Exists(file))
            {  // file does not exist
                using (File.Create(file)) { };
            }

            var bFormatter = new BinaryFormatter();
            using (var stream = File.OpenWrite(file))
            {  // serialize
                bFormatter.Serialize(stream, value);
            }
        }

        private static ICollection<T> ReadFromDisk<T>()
        {   // deserialize the file contents
            if (!File.Exists(file)) return Enumerable.Empty<T>().ToArray();

            var bFormatter = new BinaryFormatter();
            using (var stream = File.OpenRead(file))
            {
                return (ICollection<T>)bFormatter.Deserialize(stream);
            }
        }
    }
}
