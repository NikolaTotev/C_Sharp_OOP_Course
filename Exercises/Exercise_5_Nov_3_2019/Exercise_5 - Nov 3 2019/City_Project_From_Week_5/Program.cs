using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Subgroups; // City class is here. 

namespace City_Project_From_Week_5
{
    class Program
    {


        static void Main(string[] args)
        {
            City[] cities =
            {
                new City(){ContinentName ="Europe", CountryName="Germany", CityName="Berlin" },
                new City(){ContinentName ="Europe", CountryName="Germany", CityName="Frankfurt" },
                new City(){ContinentName ="Europe", CountryName="France", CityName="Paris" },
                new City(){ContinentName ="Europe", CountryName="France", CityName="Marseille" },
                new City(){ContinentName ="Asia", CountryName="Japan", CityName="Tokyo" },
                new City(){ContinentName ="Asia", CountryName="Korea", CityName="Seoul" }
            };

            var citiesByContinentsAndCountry = cities
                .GroupBy(city => city.CountryName) // Group cities by country.
                .GroupBy(city => city.First().ContinentName); // Group countries by continent.

            var finalGrouping = citiesByContinentsAndCountry.Select(mainGrouName => new
            {
                ContinentName = mainGrouName.Key, // Head of the outer group.
                Countries = mainGrouName.Select(subGroup => new
                {
                    CountryName = subGroup.Key,
                    Cities = subGroup.Select(item => new { item.CityName }).ToList()
                }).ToList()

            });

            foreach (var continent in finalGrouping)
            {
                Console.WriteLine("Number of countries in {0} - {1}", continent.ContinentName, continent.Countries.Count);
                Console.WriteLine("   Contries in {0}:", continent.ContinentName);
                Console.WriteLine();


                foreach (var country in continent.Countries)
                {
                    Console.WriteLine("    {0}, number of cities {1}", country.CountryName, country.Cities.Count);
                    foreach (var city in country.Cities)
                    {
                        Console.WriteLine("      {0}", city.CityName);
                    }
                }
                Console.WriteLine();

            }


        }
    }
}
