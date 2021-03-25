using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GunsOfTheOldWest.Core
{
    public class Database : IDatabase
    {
        public int Bullets { get; set; }
        public bool GameWon { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }


        public void Initalize()
        {
            Bullets = 12;
        }
    }

}
