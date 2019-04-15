namespace GoUR_FP
{
    class MapData
    {
        private readonly int mapSize = 8;
        private readonly int tileSize = 74;
        private readonly int[,] skindata;
        private readonly int[,] typedata;
        private readonly int[,] ownerdata;
        private readonly int[,] trackdata;

        public int MapSize
        {
            get
            {
                return mapSize;
            }
        }

        public int TileSize
        {
            get
            {
                return tileSize;
            }
        }

        public int[,] Skindata
        {
            get
            {
                return skindata;
            }
        }

        public int[,] Typedata
        {
            get
            {
                return typedata;
            }
        }

        public int[,] Ownerdata
        {
            get
            {
                return ownerdata;
            }

        }

        public int[,] Trackdata
        {
            get
            {
                return trackdata;
            }
        }

        public MapData()
        {
            skindata = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 },
                                       { 8, 8, 8, 8, 0, 0, 8, 8 },
                                       { 1, 2, 3, 2, 9, 10, 1, 5 },
                                       { 6, 3, 4, 1, 3, 4, 2, 3 },
                                       { 1, 2, 3, 2, 12, 11, 1, 5 },
                                       { 7, 7, 7, 7, 0, 0, 7, 7 },
                                       { 0, 0, 0, 0, 0, 0, 0, 0 },
                                       { 0, 0, 0, 0, 0, 0, 0, 0 },
                                     };
            typedata = new int[8, 8] { { 3, 3, 3, 3, 3, 3, 3, 3 },
                                       { 0, 0, 0, 0, 0, 0, 0, 0 },
                                       { 1, 2, 2, 2, 0, 0, 1, 2 },
                                       { 2, 2, 2, 1, 2, 2, 2, 2 },
                                       { 1, 2, 2, 2, 0, 0, 1, 2 },
                                       { 0, 0, 0, 0, 0, 0, 0, 0 },
                                       { 3, 3, 3, 3, 3, 3, 3, 3 },
                                       { 0, 0, 0, 0, 0, 0, 0, 0 },
                                     };
            ownerdata = new int[8, 8] { { 1, 1, 1, 1, 1, 1, 1, 1 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 1, 1, 1, 1, 0, 0, 1, 1 },
                                        { 3, 3, 3, 3, 3, 3, 3, 3 },
                                        { 2, 2, 2, 2, 0, 0, 2, 2 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 2, 2, 2, 2, 2, 2, 2, 2 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                                      };
            trackdata = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 4, 3, 2, 1, 0, 0, 14, 13 },
                                        { 5, 6, 7, 8, 9, 10, 11, 12 },
                                        { 4, 3, 2, 1, 0, 0, 14, 13 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0 },
                                      };
        }
    }
}
