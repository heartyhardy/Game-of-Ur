using System;

namespace GoUR_FP
{
    class Dice
    {
        private const int DICE_COUNT= 4;
        private Random rnd;
        private int lastRoll = 0;
        private bool diceReady = true;

        public Dice()
        {
            rnd = new Random();
        }

        public static int DiceCount
        {
            get
            {
                return DICE_COUNT;
            }
        }

        public bool DiceReady
        {
            get
            {
                return diceReady;
            }

            set
            {
                diceReady = value;
            }
        }

        public int LastRoll
        {
            get
            {
                return lastRoll;
            }
        }

        public int roll()
        {
            if (!diceReady)
                throw new InvalidOperationException("Dice not ready!");
            else
            {
                lastRoll = rnd.Next(0, 5);
                diceReady = false;
                return lastRoll;
            }
        }
    }
}
