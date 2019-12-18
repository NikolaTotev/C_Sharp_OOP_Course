using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortSamples
{
    class Animal { }
    class Giraffe : Animal { }
    class Test
    {
        static void Main(string[] args)
        {   // ArraySegment are covariant
            // This assignment works- > covariance
            Animal[] animals = new Giraffe[10];
            //  but this is not supported- contravariance
           //  Giraffe[] ganimals = new Animal[10];

            // IList is invariant
            // implicit...NOT Supported (covariance)
            //IList<Animal> animalsList = new List<Giraffe>();

            // ...and explicit casting fails also ..NOT Supported (covariance)
           // IList<Animal> animalsList2 = (List<Animal>)new List<Giraffe>();

            // also ..NOT Supported (contravariance)
            //IList<Giraffe> animalsList3 =  new List<Animal>();
        }
    }
}
