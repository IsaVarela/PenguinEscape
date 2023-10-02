using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penguin_Test01.Classes.Entities; 

namespace Penguin_Test01.Classes.States
{
    public class FightState : IState 
    {
        #region Singleton 
        private static FightState instance = null;
        private FightState() { }

        public static FightState GetInstance()
        {
            if (instance == null)
            {
                instance = new FightState();
            }
            return instance;
        }
        #endregion

        public void Attack(Penguin penguin, Orca enemy)
        {
            // penguin is not hit, just switch the state 
            penguin.CurrentState = NormalState.GetInstance(); 
        }
    }
}
