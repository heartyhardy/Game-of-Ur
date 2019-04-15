namespace GoUR_FP
{
    class GamePiece
    {
        private int x;
        private int y;
        private int physicalIndex;  //index of the piece in main list
        private int locationIndex; //index of the occupying square
        private int faction;
        private const int PIECES_PER_PLAYER = 7;
        private bool hasFinished;
        private NextMove nextmove;

        public GamePiece(int x, int y, int physicalIndex, int faction)
        {
            nextmove = new NextMove(false, false, -1);
            this.x = x;
            this.y = y;
            this.physicalIndex = physicalIndex;
            this.faction = faction;
            hasFinished = false;
        }

        public int GameboardX
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int GameboardY
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int PhysicalIndex
        {
            get
            {
                return physicalIndex;
            }
        }

        public int OccupyingIndex
        {
            get
            {
                return locationIndex;
            }

            set
            {
                locationIndex = value;
            }
        }

        public int Faction
        {
            get
            {
                return faction;
            }
        }

        public static int PiecesPerPlayer
        {
            get
            {
                return PIECES_PER_PLAYER;
            }
        }

        public bool HasFinished
        {
            get
            {
                return hasFinished;
            }

            set
            {
                hasFinished = value;
            }
        }

        public NextMove Nextmove
        {
            get
            {
                return nextmove;
            }

            set
            {
                nextmove = value;
            }
        }

        public struct NextMove
        {
            private bool isMovable;
            private bool isFinishable;
            private int destinationIndex;

            public bool IsMovable
            {
                get
                {
                    return isMovable;
                }
            }

            public bool IsFinishable
            {
                get
                {
                    return isFinishable;
                }
            }

            public int Destination
            {
                get
                {
                    return this.destinationIndex;
                }
            }

            public NextMove(bool isMovable=false,bool isFinishable=false, int destination=-1)
            {
                this.isMovable = isMovable;
                this.isFinishable = isFinishable;
                this.destinationIndex = destination;
            }
        }

        public void clearMoves()
        {
            this.Nextmove = new NextMove(false);
        }

        public void move(int locationIndex)
        {
            this.locationIndex = locationIndex;
        }
    }
}
