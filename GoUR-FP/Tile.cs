namespace GoUR_FP
{
    class Tile
    {
        private readonly int tileSize;
        private readonly int skinIndex;
        private readonly int typeIndex;
        private readonly int ownerIndex;
        private readonly int trackIndex;
        private bool isOccupied;
        private int occupantIndex;
        private int physicalIndex;

        public Tile(int tileSize, int physicalIndex, int skinIndex, int typeIndex, int ownerIndex,int trackIndex)
        {
            this.tileSize = tileSize;
            this.physicalIndex = physicalIndex;
            this.skinIndex = skinIndex;
            this.typeIndex = typeIndex;
            this.ownerIndex = ownerIndex;
            this.trackIndex = trackIndex;
            isOccupied = false;
            occupantIndex = -1;
        }

        public int SkinIndex
        {
            get
            {
                return skinIndex;
            }
        }

        public int TypeIndex
        {
            get
            {
                return typeIndex;
            }
        }

        public int OwnerIndex
        {
            get
            {
                return ownerIndex;
            }
        }

        public bool IsOccupied
        {
            get
            {
                return isOccupied;
            }

            set
            {
                isOccupied = value;
            }
        }

        public int OccupantIndex
        {
            get
            {
                return occupantIndex;
            }

            set
            {
                occupantIndex = value;
            }
        }

        public int PhysicalIndex
        {
            get
            {
                return physicalIndex;
            }
        }

        public int TileSize
        {
            get
            {
                return tileSize;
            }
        }

        public int TrackIndex
        {
            get
            {
                return trackIndex;
            }
        }

        public void hold(int occupantIndex)
        {
            this.occupantIndex = occupantIndex;
            isOccupied = true;
        }

        public void release()
        {
            occupantIndex = -1;
            isOccupied = false;
        }
    }
}
