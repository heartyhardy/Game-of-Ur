namespace GoUR_FP
{
    class Players
    {
        private readonly int playerFaction;
        private readonly int opponentFaction;
        private readonly int opponentType;
        private int playerScore;
        private int opponentScore;
        private const int TRACK_LENGTH = 14;

        public int PlayerFaction
        {
            get
            {
                return playerFaction;
            }
        }

        public int OpponentFaction
        {
            get
            {
                return opponentFaction;
            }
        }

        public int OpponentType
        {
            get
            {
                return opponentType;
            }
        }

        public static int TrackLength
        {
            get
            {
                return TRACK_LENGTH;
            }
        }

        public int PlayerScore
        {
            get
            {
                return playerScore;
            }

            set
            {
                playerScore = value;
            }
        }

        public int OpponentScore
        {
            get
            {
                return opponentScore;
            }

            set
            {
                opponentScore = value;
            }
        }

        public Players(int playerFaction, int opponentFaction,int opponentType)
        {
            this.playerFaction = playerFaction;
            this.opponentFaction = opponentFaction;
            this.opponentType = opponentType;
            playerScore = 0;
            opponentScore = 0;
        }
    }
}
