using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeWithAppend
{
    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public string BelongsToTeam { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}, Team {1}\n", Name, BelongsToTeam);
        }
    }
}
