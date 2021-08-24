﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Starwars
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Planet> planets = LoadData();
            #region opgave 1
            var startsWithA = from planet in planets
                              where planet.Name.StartsWith("M")
                              select planet;
            Console.WriteLine("Opg. 1 - Planets starting with 'M':\n");
            foreach (var item in startsWithA)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("");
            #endregion

            #region opgave 2
            var nameIncludesY = from planet in planets
                                where planet.Name.Contains("y") || planet.Name.Contains("Y")
                                select planet;
            Console.WriteLine("Opg. 2 - Planets including 'y':\n");
            foreach (var item in nameIncludesY)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("");
            #endregion

            #region opgave 3
            var planetLenght = from planet in planets
                               where planet.Name.Length > 9 && planet.Name.Length < 15
                               select planet;
            Console.WriteLine("Opg. 3 - Planets lengt:\n");
            foreach (var item in planetLenght)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("");
            #endregion

            #region opgave 4
            var onSecondposAndEndE = from planet in planets
                                     where planet.Name[1].ToString().Equals("a") && planet.Name[planet.Name.Length - 1].ToString().Equals("e")
                                     select planet;
            Console.WriteLine("Opg. 4 - On second pos and end on e:\n");
            foreach (var item in onSecondposAndEndE)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("");
            #endregion

            #region opgave 5
            var rotationPeriod = from planet in planets
                                 where planet.RotationPeriod > 40
                                 orderby planet.RotationPeriod
                                 select planet;
            Console.WriteLine("Opg. 5 Rotationperiod:\n");
            foreach (var item in rotationPeriod)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("");
            #endregion

            #region opgave 6
            var rotationBiggerAndLess = from planet in planets
                                        where planet.RotationPeriod > 10 && planet.RotationPeriod < 20
                                        orderby planet.Name
                                        select planet;
            Console.WriteLine("Opg. 6 Rotationsperiod bigger and less:\n");
            foreach (var item in rotationBiggerAndLess)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("");
            #endregion

            #region opgave 7
            var rotationBigger = from planet in planets
                                 where planet.RotationPeriod > 30
                                 orderby planet.Name, planet.RotationPeriod
                                 select planet;
            Console.WriteLine("Opg. 7 Rotation bigger than 30 and sort:\n");
            foreach (var item in rotationBigger)
            {
                Console.WriteLine(item.Name + " " + item.RotationPeriod);
            }
            Console.WriteLine();
            #endregion

            #region opgave 8 
            var planetRotSurf = from planet in planets
                                where (planet.RotationPeriod < 30 || planet.SurfaceWater > 50) && planet.Name.Contains("ba")
                                orderby planet.Name, planet.SurfaceWater, planet.RotationPeriod
                                select planet;
            Console.WriteLine("Opg. 8:\n");
            foreach (var item in planetRotSurf)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region opgave 9 
            var planetSurfraceW = from planet in planets
                                  where planet.SurfaceWater > 0
                                  orderby planet.SurfaceWater descending
                                  select planet;
            Console.WriteLine("Opg. 9:\n");
            foreach (var item in planetSurfraceW)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region opgave 10
            var planetDiaAndPop = from planet in planets
                                  where planet.Diameter > 0 && planet.Population > 0
                                  orderby (Math.PI * Math.Pow(planet.Diameter, 2) / planet.Population) ascending
                                  select planet;
            Console.WriteLine("Opg. 10:\n");
            foreach (var item in planetDiaAndPop)
            {
                Console.WriteLine(item.Name);
            }

            #endregion

            #region opgave 11
            var toRemove = from planet in planets
                           where planet.RotationPeriod > 0
                           select planet;

            var planetRemove = from planet in planets.Except(toRemove)
                               select planet;
            Console.WriteLine("Opg. 11:\n");
            foreach (var item in planetRemove)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region opgave 12
            var planetStartAEndsE = from planet in planets
                                    where planet.Name.StartsWith("a") || planet.Name.EndsWith("e")
                                    select planet;
            var planetTerrain = from planet in planets
                                where planet.Terrain != null && planet.Terrain.Contains("rainforests")
                                select planet;
            var union = planetStartAEndsE.Union(planetTerrain);

            Console.WriteLine("Opg. 12:\n");
            foreach (var item in union)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region opgave 13
            var planetClimateDessert = from planet in planets
                                       where planet.Terrain != null && planet.Terrain.Contains("deserts")
                                       select planet;
            Console.WriteLine("Opg. 13:\n");
            foreach (var item in planetClimateDessert)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region opgave 14 
            var planetSwamp = from planet in planets
                              where planet.Terrain != null && planet.Terrain.Contains("swamps")
                              orderby planet.RotationPeriod, planet.Name
                              select planet;
            Console.WriteLine("Opg. 14:\n");
            foreach (var item in planetSwamp)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region opgave 15
            Regex regex = new Regex(@"([aeiouy])\1");
            var planetDoublevocal = from planet in planets
                                    where regex.IsMatch(planet.Name)
                                    select planet;
            Console.WriteLine("Opg. 15:\n");
            foreach (var item in planetDoublevocal)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region opgave 16
            Regex regex1 = new Regex(@"([klrn])\1");
            var planetDoubleKonsonant = from planet in planets
                                        where regex1.IsMatch(planet.Name)
                                        select planet;
            Console.WriteLine("Opg. 16:\n");
            foreach (var item in planetDoubleKonsonant)
            {
                Console.WriteLine(item.Name);
            }
            #endregion
            Console.ReadKey();
        }




        static List<Planet> LoadData()
        {
            List<Planet> planets = new List<Planet>()
            {
                new Planet { Name="Corellia", Terrain= new List<string>{ "plains", "urban", "hills", "forests" },RotationPeriod=25,SurfaceWater=70, Diameter=11000, Population=3000000000},
                new Planet { Name="Rodia", Terrain= new List<string>{ "jungles", "oceans", "urban", "swamps" },RotationPeriod=29,SurfaceWater=60, Diameter=7549, Population=1300000000},
                new Planet { Name="Nal Hutta", Terrain= new List<string>{ "urban", "oceans", "bogs", "swamps" },RotationPeriod=87, Diameter=12150, Population=7000000000},
                new Planet { Name="Dantooine",Terrain= new List<string>{ "savannas", "oceans", "mountains", "grasslands" },RotationPeriod=25, Diameter=9830,Population=1000},
                new Planet { Name="Bestine IV",Terrain= new List<string>{ "rocky islands", "oceans" },RotationPeriod=26,SurfaceWater=98, Diameter=6400,Population=62000000},
                new Planet { Name="Ord Mantell",Terrain= new List<string>{ "plains", "seas","mesas" },RotationPeriod=26,SurfaceWater=10, Diameter=14050, Population=4000000000},
                new Planet { Name="Trandosha",Terrain= new List<string>{ "mountains", "seas","grasslands" ,"deserts"},RotationPeriod=25, Diameter=0, Population=42000000},
                new Planet { Name="Socorro", Terrain= new List<string>{ "mountains", "deserts"},RotationPeriod=20, Population=300000000},
                new Planet { Name="Mon Cala",Terrain= new List<string>{ "oceans", "reefs","islands"},RotationPeriod=21,SurfaceWater=100,Diameter=11030,Population=27000000000},
                new Planet { Name="Chandrila", Terrain= new List<string>{ "plains", "forests"},RotationPeriod=20,SurfaceWater=40,Diameter=13500,Population=1200000000},
                new Planet { Name="Sullust", Terrain= new List<string>{ "mountains", "volcanoes","rocky deserts"},RotationPeriod=20,SurfaceWater=5, Diameter=12780, Population=18500000000},
                new Planet { Name="Toydaria", Terrain= new List<string>{ "swamps", "lakes"},RotationPeriod=21, Diameter=7900, Population=11000000},
                new Planet { Name="Malastare",Terrain= new List<string>{ "swamps", "deserts","jungles","mountains"},RotationPeriod=26, Diameter=18880, Population=2000000000},
                new Planet { Name="Dathomir",Terrain= new List<string>{ "forests", "deserts","savannas"},RotationPeriod=24, Diameter=10480, Population=5200},
                new Planet { Name="Ryloth",Terrain= new List<string>{ "mountains", "valleys","deserts","tundra"},RotationPeriod=30,SurfaceWater=5,Diameter=10600, Population=1500000000 },
                new Planet { Name="Aleen Minor"},
                new Planet { Name="Vulpter",Terrain= new List<string>{ "urban", "barren"} ,RotationPeriod=22, Diameter=14900, Population=421000000},
                new Planet { Name="Troiken",Terrain= new List<string>{ "desert", "tundra","rainforests","mountains"} },
                new Planet { Name="Tund",Terrain= new List<string>{ "barren", "ash"} ,RotationPeriod=48, Diameter=12190},
                new Planet { Name="Haruun Kal",Terrain= new List<string>{ "toxic cloudsea", "plateaus","volcanoes"},RotationPeriod=25,Diameter=10120,Population=705300},
                new Planet { Name="Cerea",Terrain= new List<string>{ "verdant"},RotationPeriod=27,SurfaceWater=20,Population=450000000},
                new Planet { Name="Glee Anselm",Terrain= new List<string>{ "islands","lakes","swamps", "seas"},RotationPeriod=33,SurfaceWater=80, Diameter=15600,Population=500000000},
                new Planet { Name="Iridonia",Terrain= new List<string>{ "rocky canyons","acid pools"},RotationPeriod=29},
                new Planet { Name="Tholoth"},
                new Planet { Name="Iktotch",Terrain= new List<string>{ "rocky"},RotationPeriod=22},
                new Planet { Name="Quermia",},
                new Planet { Name="Dorin",RotationPeriod=22, Diameter=13400},
                new Planet { Name="Champala",Terrain= new List<string>{ "oceans","rainforests","plateaus"},RotationPeriod=27, Population=3500000000},
                new Planet { Name="Mirial",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Serenno",Terrain= new List<string>{ "rivers","rainforests","mountains"}},
                new Planet { Name="Concord Dawn",Terrain= new List<string>{ "jungles","forests","deserts"}},
                new Planet { Name="Zolan" },
                new Planet { Name="Ojom",Terrain= new List<string>{ "oceans","glaciers"},SurfaceWater=100, Population=500000000},
                new Planet { Name="Skako", Terrain = new List<string>{ "urban","vines"},RotationPeriod=27, Population=500000000000},
                new Planet { Name="Muunilinst",Terrain= new List<string>{ "plains","forests","hills","mountains"} ,RotationPeriod=28,SurfaceWater=25, Diameter=13800, Population=5000000000},
                new Planet { Name="Shili",Terrain= new List<string>{ "cities","savannahs","seas","plains"}},
                new Planet { Name="Kalee",Terrain= new List<string>{ "rainforests","cliffs","seas","canyons"},RotationPeriod=23, Diameter=13850, Population=4000000000},
                new Planet { Name="Umbara"},
                new Planet { Name="Tatooine",Terrain= new List<string>{ "deserts"},RotationPeriod=23,SurfaceWater=1, Diameter=10465, Population=200000 },
                new Planet { Name="Jakku",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Alderaan",Terrain= new List<string>{ "grasslands","mountains"},RotationPeriod=24,SurfaceWater=40, Diameter=12500, Population= 2000000000},
                new Planet { Name="Yavin IV", Terrain= new List<string>{ "rainforests","jungle"},RotationPeriod=24,SurfaceWater=8,Diameter=10200,Population=     1000},
                new Planet { Name="Hoth", Terrain= new List<string>{ "tundra","ice caves","mountain ranges"},RotationPeriod=23,SurfaceWater=100},
                new Planet { Name="Dagobah",Terrain= new List<string>{ "swamp","jungles"},RotationPeriod=23,SurfaceWater=8},
                new Planet { Name="Bespin",Terrain= new List<string>{ "gas giant"},RotationPeriod=12, Diameter=118000,Population=  6000000},
                new Planet { Name="Endor",Terrain= new List<string>{ "forests","mountains","lakes"},RotationPeriod=18,SurfaceWater=8, Diameter=4900, Population= 30000000},
                new Planet { Name="Naboo",Terrain= new List<string>{ "grassy hills","swamps","forests","mountains"},RotationPeriod=26,SurfaceWater=12, Diameter=12120, Population=  4500000000},
                new Planet { Name="Coruscant",Terrain= new List<string>{ "cityscape","mountains"},RotationPeriod=24,Diameter=12240,Population=1000000000000},
                new Planet { Name="Kamino",Terrain= new List<string>{ "ocean"},RotationPeriod=27,SurfaceWater=100,Diameter=19720, Population=1000000000},
                new Planet { Name="Geonosis",Terrain= new List<string>{ "rock","desert","mountain","barren"},RotationPeriod=30,SurfaceWater=5,Diameter=11370, Population=100000000000},
                new Planet { Name="Utapau",Terrain= new List<string>{ "scrublands","savanna","canyons","sinkholes"},RotationPeriod=27,SurfaceWater=0.9f,Diameter=12900,Population=  95000000},
                new Planet { Name="Mustafar",Terrain= new List<string>{ "volcanoes","lava rivers","mountains","caves"},RotationPeriod=36,  Diameter=4200, Population=20000},
                new Planet { Name="Kashyyyk",Terrain= new List<string>{ "jungle","forests","lakes","rivers"},RotationPeriod=26 ,SurfaceWater=60,Diameter=12765, Population=45000000},
                new Planet { Name="Polis Massa",Terrain= new List<string>{ "airless","asteroid"},RotationPeriod=24, Diameter=0, Population=1000000},
                new Planet { Name="Mygeeto",Terrain= new List<string>{ "glaciers","mountains","ice canyons"},RotationPeriod=12, Diameter=10088, Population=  19000000},
                new Planet { Name="Felucia",Terrain= new List<string>{ "fungus","forests"},RotationPeriod=34, Diameter=9100,Population=8500000},
                new Planet { Name="Cato Neimoidia",Terrain= new List<string>{ "mountains","fields","forests","rock arches"},RotationPeriod=25, Population=10000000},
                new Planet { Name="Saleucami",Terrain= new List<string>{ "caves", "deserts","mountains","volcanoes"},RotationPeriod=26, Population=1400000000, Diameter=14920},
                new Planet { Name="Stewjon",Terrain= new List<string>{ "grass"}},
                new Planet { Name="Eriadu",Terrain= new List<string>{ "cityscape"},RotationPeriod=24, Diameter=13490  , Population= 22000000000},
             };
            return planets;
        }
    }
}
