using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core
{
    public class Dice
    {
        private int _sides;
        private Random _rng;

        /// <summary>
        /// Creates a new instance of an n-sided die
        /// </summary>
        /// <param name="rngSeed"></param>
        /// <param name="numberOfSides"></param>
        public Dice(int numberOfSides, int rngSeed = 0)
        {
            /* The number of sides on the die
             *  Random.Next(x,y) is [x,y), meaning:
             *  the result being somewhere x >= result > y
            
             * Ex: for a 1d6,
             * _sides = 6 + 1;
             * GetRollResult() returns a value >= 1 and < 7
            */
            _sides = numberOfSides + 1;

            //Allows for an optional RNG seed be specified for the die
            if (rngSeed == 0)
            {
                _rng = new Random();
            }
            else
            {
                _rng = new Random(rngSeed);
            }
        }

        /// <summary>
        /// Rolls the n-Sided dice one time, returning the result of the roll.
        /// </summary>
        /// <returns></returns>
        public int GetRollResult()
        {
            return _rng.Next(1, _sides);
        }
    }
}
