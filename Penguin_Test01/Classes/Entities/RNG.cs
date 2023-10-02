using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_Test01.Classes.Entities
{
    public class RNG : Random 
    {
        private static RNG instance = null;

        private RNG() : base() { }

        public static RNG GetInstance()
        {
            if (instance == null)
            {
                instance = new RNG(); 
            }
            return instance; 
        }
    }
}
