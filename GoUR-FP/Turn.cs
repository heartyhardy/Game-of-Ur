namespace GoUR_FP
{
    class Turn
    {
        private int turnID;
        private int activeFaction;
        private int inactiveFaction;
        private bool rollUsed;

        public Turn()
        {
            turnID = 0;
            activeFaction = 2;
            inactiveFaction = 1;
            rollUsed = true;
        }

        public int ActiveFaction
        {
            get
            {
                return activeFaction;
            }
        }

        public int TurnID
        {
            get
            {
                return turnID;
            }
        }

        public bool RollUsed
        {
            get
            {
                return rollUsed;
            }

            set
            {
                rollUsed = value;
            }
        }

        public int InactiveFaction
        {
            get
            {
                return inactiveFaction;
            }
        }

        public void nextTurn(bool bonus=false)
        {
            //if(turnID==0)
            //{
            //    turnID++;
            //    activeFaction = 1;
            //    inactiveFaction = 2;
            //    rollUsed = false;
            //    return;
            //}

            if (bonus)
            {
                turnID++;                
            }
            else
            {
                turnID++;
                swapFactions();
            }

            rollUsed = false;
        }

        private void swapFactions()
        {
            activeFaction ^= inactiveFaction ^ (inactiveFaction = activeFaction);
        }
    }
}
