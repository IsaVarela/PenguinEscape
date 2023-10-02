using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penguin_Test01.Classes.Entities; 

namespace Penguin_Test01.Classes.States
{
    public class NormalState : IState
    {
        #region Singleton
        private static NormalState instance = null;

        private NormalState() { }

        public static NormalState GetInstance()
        {
            if (instance == null)
            {
                instance = new NormalState();
            }
            return instance;
        }
        #endregion

        public void Attack(Penguin penguin, Orca enemy)
        {
            penguin.LooseEnergy(enemy.Apower);  
        }
    }
}
