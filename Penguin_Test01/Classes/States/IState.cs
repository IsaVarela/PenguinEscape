using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penguin_Test01.Classes.Entities; 

namespace Penguin_Test01.Classes.States
{
    public interface IState
    {
        void Attack(Penguin penguin, Orca enemy);
    }
}
