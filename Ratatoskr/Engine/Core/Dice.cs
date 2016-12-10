using System;

namespace Engine.Core
{
    [SerializableAttribute]
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

        public Dice(string dice, int rngSeed = 0)
        {
            string[] partsOfDice = dice.Split('d');
            try
            {
                _sides = int.Parse(partsOfDice[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("!! Error :: Attempted to Parse [{0}] into dice.", dice));
                Console.WriteLine(string.Format("Message: {0} \nTrace:\n{1}", e.Message, e.StackTrace));
            }
           

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
