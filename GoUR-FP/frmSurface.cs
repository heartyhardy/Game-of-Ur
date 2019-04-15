using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

namespace GoUR_FP
{
    public partial class frmSurface : Form
    {
        private List<Tile> tiles;
        private List<GamePiece> pieces;
        private List<PictureBox> pboxes;
        private List<PictureBox> pdice;
        private MapData map;
        private Dice dice;
        private Turn turn;
        private Players players;
        private bool gameStarted = false;
        private WindowsMediaPlayer musicPlayer;
        private readonly string defualtMusic, gameoverMusic;

        public frmSurface()
        {
            InitializeComponent();

            map = new MapData();
            dice = new Dice();
            turn = new Turn();

            defualtMusic = string.Format("{0}Resources\\pop.m4a", Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\")));
            gameoverMusic = string.Format("{0}Resources\\Ishtar.mp3", Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\")));

            pbCup.MouseDown += PbCup_MouseDown;
            pbStartupRoll.MouseDown += PbStartupRoll_MouseDown;
            KeyPress += FrmSurface_KeyPress;
            
            init();
            animateStartupText();
            pickHumanPlayerFaction();
            createTiles();
            createPieces();
            layoutBoard();
            fillBackDice();
            arrangeBoard();
        }

        #region -General functions-

        private void init()
        {
            pnlStartUp.Dock = DockStyle.Fill;
            pnlStartUp.Width = 1066;

            musicPlayer = new WindowsMediaPlayer();            
            musicPlayer.settings.volume = 50;
            musicPlayer.settings.setMode("loop", true);
            musicPlayer.URL = defualtMusic;
            musicPlayer.controls.play();            
        }

        private void animateStartupText()
        {
            Timer t = new Timer();
            t.Interval = 1000;
            lblBlink.Tag = 1;
            t.Start();
            t.Tick += (o, e) =>
              {
                  if ((int)lblBlink.Tag == 1)
                  {
                      lblBlink.Tag = 2;
                      lblBlink.Text = "";
                  }
                  else if ((int)lblBlink.Tag == 2)
                  {
                      lblBlink.Tag = 1;
                      lblBlink.Text = GoUR_FP.Properties.Resources.BLINK_TEXT;
                  }
                  else if ((int)lblBlink.Tag==3)
                  {
                      t.Stop();
                      t.Dispose();
                  }

              };
        }

        private void createTiles()
        {
            Tile tile;
            tiles = new List<Tile>();

            for (int i = 0; i < map.MapSize; i++)
            {
                for (int j = 0; j < map.MapSize; j++)
                {
                    tile = new Tile(
                                    map.TileSize,
                                    (map.MapSize * i) + j,
                                    map.Skindata[i, j],
                                    map.Typedata[i, j],
                                    map.Ownerdata[i, j],
                                    map.Trackdata[i,j]
                                   );
                    tiles.Add(tile);
                }
            }
        }

        private void createPieces()
        {
            GamePiece gp;
            pieces = new List<GamePiece>();

            for (int i=0;i<GamePiece.PiecesPerPlayer*2;i++)
            {
                if(i<7)
                {
                    gp = new GamePiece(0, 0, i, 1);
                    pieces.Add(gp);
                }
                if(i>=7)
                {
                    gp = new GamePiece(0, 0, i, 2);
                    pieces.Add(gp);
                }
            }
        }

        private void layoutBoard()
        {
            PictureBox pb;
            pboxes = new List<PictureBox>();
            int xoffset, yoffset = 0;

            for (int i=0;i<tiles.Count;i++)
            {
                xoffset = i % map.MapSize;
                yoffset = i / map.MapSize;

                pb = new PictureBox();
                pb.Name = "pb" + i.ToString();
                pb.Width = map.TileSize;
                pb.Height = map.TileSize;
                pb.Left = xoffset * map.TileSize;
                pb.Top = yoffset * map.TileSize;
                pb.BackgroundImage = getImage(tiles[i].SkinIndex);
                linkToTile(pb, i);

                pb.MouseEnter += Pb_MouseEnter;
                pb.MouseLeave += Pb_MouseLeave;
                pb.MouseDown += Pb_MouseDown;

                pboxes.Add(pb);
            }
            foreach(PictureBox p in pboxes)
            {
                pnlBoard.Controls.Add(p);
            }
        }

        private void arrangeBoard()
        {
            List<int> whitePieces = getPiecesByFaction(1);
            List<int> blackPieces = getPiecesByFaction(2);
            List<int> whiteStation = getPieceStationsByFaction(1);
            List<int> blackStation = getPieceStationsByFaction(2);

            for(int i=0;i<GamePiece.PiecesPerPlayer;i++)
            {
                pieces[whitePieces[i]].move(tiles[whiteStation[i]].PhysicalIndex);
                tiles[whiteStation[i]].hold(pieces[whitePieces[i]].PhysicalIndex);
                pboxes[whiteStation[i]].Image = GoUR_FP.Properties.Resources.whitepiece;

                pieces[blackPieces[i]].move(tiles[blackStation[i]].PhysicalIndex);
                tiles[blackStation[i]].hold(pieces[blackPieces[i]].PhysicalIndex);
                pboxes[blackStation[i]].Image = GoUR_FP.Properties.Resources.blackpiece;
            }
        }

        private void renderDice(int diceroll)
        {
            PictureBox pb;
            
            for(int i=0;i<Dice.DiceCount;i++)
            {
                pb = new PictureBox();
                pb.Name = "pbd" + i.ToString();
                pb.Width = map.TileSize;
                pb.Height = map.TileSize;
                pb.Top = 0;
                pb.Left = i * map.TileSize;
                pb.BackgroundImageLayout = ImageLayout.Center;
                if (i <= diceroll - 1)
                    pb.BackgroundImage = GoUR_FP.Properties.Resources.dice_one;
                else
                    pb.BackgroundImage = GoUR_FP.Properties.Resources.dice_zero;
                pdice.Add(pb);
            }
            foreach (PictureBox p in pdice)
            {
                pnlDice.Controls.Add(p);
            }
        }

        private void fillBackDice()
        {
            if (pdice != null)
            {
                foreach (PictureBox p in pdice)
                {
                    p.Dispose();
                }
                pdice.Clear();

            }
            else
                pdice = new List<PictureBox>();

            if (pnlDice.Controls.Count > 0)
            {
                foreach (Control c in pnlDice.Controls)
                {
                    c.Dispose();
                }
                pnlDice.Controls.Clear();
            }

            dice.DiceReady = true;
            pbCup.BackgroundImage = GoUR_FP.Properties.Resources.Rolling_cup;
        }

        private void pickHumanPlayerFaction()
        {
            int roll = dice.roll();

            if (roll > 2)
            {
                players = new Players(1, 2, 0);
                pbPortrait.BackgroundImage = Properties.Resources.Prince__Fallen_King_;
            }
            else
            {
                players = new Players(2, 1, 0);
                pbPortrait.BackgroundImage = Properties.Resources.Magus_Infobox_Pic_Render;
            }
        }

        private void renderPortrait()
        {
            switch(turn.ActiveFaction)
            {
                case 1:
                case 2:
                    if (players.PlayerFaction == turn.ActiveFaction)
                        pbPortrait.BackgroundImage = pbPortrait.BackgroundImage = Properties.Resources.Prince__Fallen_King_;
                    else
                        pbPortrait.BackgroundImage = Properties.Resources.Magus_Infobox_Pic_Render;
                    break;
            }
        }

        private void updateHud()
        {
            switch (turn.ActiveFaction)
            {
                case 1:
                case 2:
                    if (players.PlayerFaction == turn.ActiveFaction)
                    {
                        pbHudPlayer.BackgroundImage = pbPortrait.BackgroundImage = Properties.Resources.Prince__Fallen_King_;
                        lblPlayers.Text = Properties.Resources.PLAYER_TURN;
                        lblPlayers.ForeColor = Color.LightSteelBlue;

                        if(turn.ActiveFaction==1)
                        {
                            pnlHud.BackColor = Color.WhiteSmoke;
                            pbPlayer.BackgroundImage = Properties.Resources.whitepiece;
                        }
                        else
                        {
                            pnlHud.BackColor = Color.Black;
                            pbPlayer.BackgroundImage = Properties.Resources.blackpiece;
                        }
                    }
                    else
                    {
                        pbHudPlayer.BackgroundImage = Properties.Resources.Magus_Infobox_Pic_Render;
                        lblPlayers.Text = Properties.Resources.OPPONENT_TURN;
                        lblPlayers.ForeColor = Color.Tomato;

                        if (turn.ActiveFaction == 1)
                        {
                            pnlHud.BackColor = Color.WhiteSmoke;
                            pbPlayer.BackgroundImage = Properties.Resources.whitepiece;
                        }
                        else
                        {
                            pnlHud.BackColor = Color.Black;
                            pbPlayer.BackgroundImage = Properties.Resources.blackpiece;
                        }
                    }
                    break;
            }
        }

        private void updateDiceRollPermissions()
        {
            if(turn.ActiveFaction==players.PlayerFaction)
            {
                pbCup.Cursor = Cursors.Hand;
                pnlBoard.Cursor = Cursors.Hand;
            }
            else
            {
                pbCup.Cursor = Cursors.WaitCursor;
                pnlBoard.Cursor = Cursors.WaitCursor;
            }
        }

        private void lockPlayerControls(bool flag)
        {
            switch (flag)
            {
                case true:
                    foreach (Control c in this.Controls)
                        c.Enabled = false;
                    pnlStartUp.Enabled = true;
                    break;
                case false:
                    Timer t = new Timer();
                    t.Interval = 500;
                    t.Start();
                    t.Tick += (o, e) =>
                     {
                         pnlHud.Visible = true;
                         foreach (Control c in this.Controls)
                             c.Enabled = true;
                         newTurn();
                         this.gameStarted = true;
                         isPlayerMoveEnabled = false;
                         isOpponentMoveEnabled = false;
                         t.Stop();
                         t.Dispose();                       
                     };
                    break;
            }            
        }

        private bool isMoveMode()
        {
            if (turn.ActiveFaction == players.PlayerFaction && turn.RollUsed)
            {
                return true;
            }
            else if (turn.ActiveFaction == players.OpponentFaction && turn.RollUsed)
            {
                return true;
            }
            else
                return false;
        }

        private bool isPlayerMoveEnabled
        {
            get;set;
        }

        private bool isOpponentMoveEnabled
        {
            get; set;
        }

        private void enableMovingPhase()
        {
            bool hasZeromove = false;

            if (dice.LastRoll == 0)
            {
                eliminateZeroRollTurn();
                return;
            }

            if (isPlayersTurn())
            {
                if (determineMovablePieces())
                {
                    disableMovingPhase();
                    delayedNewTurn(3000);
                }
                else
                {
                    isPlayerMoveEnabled = true;
                    isOpponentMoveEnabled = false;
                    pnlBoard.Enabled = true;
                }
            }
            else
            {
                if (determineMovablePieces())
                {
                    disableMovingPhase();
                    delayedNewTurn(3000);
                }
                else
                {
                    isPlayerMoveEnabled = false;
                    isOpponentMoveEnabled = true;
                    pnlBoard.Enabled = false;
                    //need to implement this
                    aiMakeAMove();
                }
            }
        }

        private void disableMovingPhase()
        {
            isPlayerMoveEnabled = false;
            isOpponentMoveEnabled = false;
            pnlBoard.Enabled = false;
        }

        private void eliminateZeroRollTurn()
        {
            if(dice.LastRoll==0)
            {
                delayedNewTurn(2000);
            }
        }

        private void newTurn(bool isBonus=false)
        {
            switch (isVictorius())
            {
                case -1:
                    break;
                case 1:
                    if (players.PlayerFaction == 1)
                        showVictoryScreen(1, true);
                    else if (players.OpponentFaction == 1)
                        showVictoryScreen(1, false);
                    return;
                case 2:
                    if (players.PlayerFaction == 2)
                        showVictoryScreen(2, true);
                    else if (players.OpponentFaction == 2)
                        showVictoryScreen(2, false);
                    return;
            }

            switch (turn.ActiveFaction)
            {
                case 1:
                    turn.nextTurn(isBonus);
                    lblTurn.Text = "Turn " + turn.TurnID.ToString();
                    renderPortrait();
                    updateHud();
                    updateDiceRollPermissions();
                    fillBackDice();
                    EnableDiceRollPhase();
                    break;
                case 2:
                    turn.nextTurn(isBonus);
                    lblTurn.Text = "Turn " + turn.TurnID.ToString();
                    renderPortrait();
                    updateHud();
                    updateDiceRollPermissions();
                    fillBackDice();
                    EnableDiceRollPhase();
                    break;
            }
        }

        private void delayedNewTurn(int delay, bool isBonus=false)
        {
            pbCup.Cursor = Cursors.WaitCursor;
            pnlBoard.Cursor = Cursors.WaitCursor;

            Timer t = new Timer();
            t.Interval = delay;
            t.Start();
            t.Tick += (o, e) =>
              {
                  t.Stop();
                  if (isBonus)
                      newTurn(true);
                  else
                      newTurn();

                  t.Dispose();
              };
        }

        private void EnableDiceRollPhase()
        {
            if (turn.ActiveFaction == players.PlayerFaction)
                return;
            else
            {
                aiRollDice();
            }
        }

        #endregion

        #region - Tile/Piece related functions -

        private bool determineMovablePieces()
        {
            //need gamepieces list
            //need current players track indices
            //see if stationed
            //get dice roll
            //get piece trackIndex
            //check the destination tile isOccupied?
            //check if it can jump off the board?
            //if qualified make them isMovable=true
            //add possible destination field to the piece
            //add a consequence method after moving to determine rosettes and knockouts
            //see if none of the pieces can be moved
            List<int> currentTrack = getTrackByFaction(turn.ActiveFaction);
            List<int> currentFaction = getPiecesByFaction(turn.ActiveFaction);
            bool zeroMove = true;

            foreach (int i in currentFaction)
            {
                movability(i);
                if (pieces[i].Nextmove.IsMovable)
                    zeroMove = false;
            }
            return zeroMove;
        }

        private void movability(int pieceIndex)
        {
            int origin=-1;
            int destination = -1;
            int movabilityIndex = -1;

            if (hasFinished(pieceIndex))
                return;

            if (isPieceStationed(pieceIndex, false))
                pieces[pieceIndex].clearMoves();
            else if (isPieceStationed(pieceIndex))
                origin = 0;

            if (origin == -1)
                origin = tiles[pieces[pieceIndex].OccupyingIndex].TrackIndex;

            destination = origin + dice.LastRoll;

            if (destination != origin && destination <= Players.TrackLength)
            {
                movabilityIndex = getTileByTrackIndex(destination);

                if (!isMoveBlocked(movabilityIndex))
                    pieces[pieceIndex].Nextmove = new GamePiece.NextMove(true, false, movabilityIndex);
                else
                    pieces[pieceIndex].clearMoves();
            }
            else if (destination != origin && (destination <= Players.TrackLength + 1))
            {
                movabilityIndex = getUnoccupiedStation();
                pieces[pieceIndex].Nextmove = new GamePiece.NextMove(true, true, movabilityIndex);
            }
            else
                pieces[pieceIndex].clearMoves();
        }

        private void clearMovability()
        {
            List<int> selPieces = getPiecesByFaction(turn.ActiveFaction);

            foreach (int piece in selPieces)
            {
                if (!pieces[piece].HasFinished)
                    pieces[piece].clearMoves();
            }
        }

        private void playerMove(int srcTileIndex, int destTileIndex)
        {
            doCollateralMove(srcTileIndex,destTileIndex);
        }

        private void doCollateralMove(int srcTileIndex, int destTileIndex)
        {
            //knockout
            //hit a rosette
            if(tiles[destTileIndex].IsOccupied && pieces[tiles[destTileIndex].OccupantIndex].Faction != turn.ActiveFaction)
            {
                //perform knockout
                knockout(tiles[destTileIndex].OccupantIndex);
                movePiece(tiles[srcTileIndex].OccupantIndex);
                disableMovingPhase();
                delayedNewTurn(1500, false);
                return;
            }
            
            if(!tiles[destTileIndex].IsOccupied && tiles[destTileIndex].TypeIndex==1)
            {
                movePiece(tiles[srcTileIndex].OccupantIndex);
                disableMovingPhase();
                clearMovability();
                delayedNewTurn(1500,true);
                return;
            }

            movePiece(tiles[srcTileIndex].OccupantIndex);
            disableMovingPhase();
            clearMovability();
            delayedNewTurn(1000);
        }

        private void knockout(int pieceIndex)
        {
            int homeIndex = getUnoccupiedOpponentStation();
            int tileIndex = pieces[pieceIndex].OccupyingIndex;

            tiles[pieces[pieceIndex].OccupyingIndex].release();
            pieces[pieceIndex].move(homeIndex);
            tiles[homeIndex].hold(pieceIndex);

            refreshTile(homeIndex);
            refreshTile(tileIndex);
        }

        private void movePiece(int pieceIndex)
        {
            int srcIndex = pieces[pieceIndex].OccupyingIndex;
            int homeIndex = getTileByPieceDestination(pieceIndex);

            tiles[pieces[pieceIndex].OccupyingIndex].release();
            pieces[pieceIndex].move(homeIndex);
            tiles[homeIndex].hold(pieceIndex);

            if (pieces[pieceIndex].Nextmove.IsFinishable)
            {
                pieces[pieceIndex].HasFinished = true;
                pieces[pieceIndex].clearMoves();
                updateScore(pieceIndex);
            }

            refreshTile(homeIndex);
            refreshTile(srcIndex);
        }

        private void updateScore(int pieceIndex)
        {
            int faction = pieces[pieceIndex].Faction;
            
            if(faction==players.PlayerFaction)
            {
                players.PlayerScore++;
            }
            else if(faction==players.OpponentFaction)
            {
                players.OpponentScore++;
            }

            updateScoreCard(faction);
        }

        private void updateScoreCard(int pieceFaction)
        {
            Timer t = new Timer();
            int swapper = 0;
            t.Interval = 200;
            t.Start();
            t.Tick += (o, e) =>
              {
                  swapper++;
                  if(swapper % 2 ==0)
                  {
                      if(pieceFaction==1)
                          pbWhiteScore.Image = Properties.Resources.finishedpiece;
                      else if(pieceFaction==2)
                          pbBlackScore.Image = Properties.Resources.finishedpiece;
                  }
                  else if(swapper % 2 !=0)
                  {
                      if (pieceFaction == 1)
                          pbWhiteScore.Image = Properties.Resources.whitepiece;
                      else if (pieceFaction == 2)
                          pbBlackScore.Image = Properties.Resources.blackpiece;
                  }

                  if(swapper>=11)
                  {
                      t.Stop();
                      t.Dispose();
                  }
                      
              };

            switch (pieceFaction)
            {
                case 1:
                    lblWhiteScore.Text = (Convert.ToInt32(lblWhiteScore.Text)+1).ToString();
                    break;
                case 2:
                    lblBlackScore.Text = (Convert.ToInt32(lblBlackScore.Text) + 1).ToString();
                    break;
            }
        }

        private int isVictorius()
        {
            if (players.PlayerScore == GamePiece.PiecesPerPlayer)
                return players.PlayerFaction;
            else if (players.OpponentScore == GamePiece.PiecesPerPlayer)
                return players.OpponentFaction;
            else return -1;
        }

        private void showVictoryScreen(int faction, bool isPlayer)
        {
            if (isPlayer)
                pnlVictory.BackgroundImage = Properties.Resources.victory;
            else
                pnlVictory.BackgroundImage = Properties.Resources.defeat;

            if (faction == 1)
                pbVictoryFaction.BackgroundImage = Properties.Resources.whitepiece;
            else
                pbVictoryFaction.BackgroundImage = Properties.Resources.blackpiece;

            musicPlayer.URL = gameoverMusic;
            musicPlayer.controls.play();

            pnlVictory.Visible = true;
            pnlBoard.Enabled = false;
            pnlHud.Visible = false;
            pbCup.Enabled = false;
            pnlVictory.Dock = DockStyle.Fill;
        }

        private int getTileByPieceDestination(int pieceIndex)
        {
            if (pieces[pieceIndex].Nextmove.Destination > -1)
                return tiles[pieces[pieceIndex].Nextmove.Destination].PhysicalIndex;
            else return -1;
        }

        private int getTileByTrackIndex(int trackIndex)
        {
            return tiles.FindIndex(x => x.TrackIndex == trackIndex && ((x.OwnerIndex==turn.ActiveFaction)||(x.OwnerIndex==3)));
        }

        private int getTileByTrackIndex(List<int> trackIndices, int trackIndex)
        {
            foreach(int i in trackIndices)
            { 
                if (tiles[i].TrackIndex == trackIndex)
                {
                    return i;
                }
            }
            return -1;
        }

        private List<int> getPieceStationsByFaction(int faction)
        {
            List<int> selectedPieces = null;

            switch (faction)
            {
                case 1:
                    selectedPieces = Enumerable.Range(0, tiles.Count)
                            .Where(x => tiles[x].TypeIndex == 3 && tiles[x].OwnerIndex == 1)
                            .ToList<int>();
                    break;
                case 2:
                    selectedPieces = Enumerable.Range(0, tiles.Count)
                            .Where(x => tiles[x].TypeIndex == 3 && tiles[x].OwnerIndex == 2)
                            .ToList<int>();
                    break;
            }
            return selectedPieces;
        }

        private List<int> getPiecesByFaction(int faction)
        {
            List<int> selectedPieces = null;

            switch(faction)
            {
                case 1:
                    selectedPieces = Enumerable.Range(0, pieces.Count)
                                    .Where(x => pieces[x].Faction == faction)
                                    .ToList<int>();
                    break;
                case 2:
                    selectedPieces = Enumerable.Range(0, pieces.Count)
                                    .Where(x => pieces[x].Faction == faction)
                                    .ToList<int>();
                    break;
            }
            return selectedPieces;
        }

        private List<int> getTrackByFaction(int faction)
        {
            List<int> selectedIndices = null;

            switch (faction)
            {
                case 1:
                    selectedIndices = Enumerable.Range(0, tiles.Count)
                                    .Where(x => tiles[x].TrackIndex > 0 && (tiles[x].OwnerIndex == 1 || tiles[x].OwnerIndex==3))
                                    .OrderBy(x => tiles[x].TrackIndex)
                                    .ToList<int>();
                    break;
                case 2:
                    selectedIndices = Enumerable.Range(0, tiles.Count)
                                    .Where(x => tiles[x].TrackIndex > 0 && (tiles[x].OwnerIndex == 2 || tiles[x].OwnerIndex == 3))
                                    .OrderBy(x => tiles[x].TrackIndex)
                                    .ToList<int>();
                    break;
            }

            return selectedIndices;
        }

        private int getOccupyingPiece(int tileIndex)
        {
            return tiles[tileIndex].OccupantIndex;
        }

        private bool isPieceStationed(int pieceIndex, bool excludeFinished=true)
        {
            switch(excludeFinished)
            {
                case true:
                    if (tiles[pieces[pieceIndex].OccupyingIndex].TypeIndex == 3 && !pieces[pieceIndex].HasFinished)
                        return true;
                    else
                        return false;
                case false:
                    if (tiles[pieces[pieceIndex].OccupyingIndex].TypeIndex == 3 && pieces[pieceIndex].HasFinished)
                        return true;
                    else
                        return false;
                default:
                    return false;
            }

        }

        private bool hasFinished(int pieceIndex)
        {
            if (pieces[pieceIndex].HasFinished)
                return true;
            else
                return false;
        }

        private bool isPieceFactionActive(int index, int mode)
        {
            switch(mode)
            {
                case 1:
                    if (pieces[tiles[index].OccupantIndex].Faction == turn.ActiveFaction)
                        return true;
                    else
                        return false;
                case 2:
                    if (pieces[index].Faction == turn.ActiveFaction)
                        return true;
                    else
                        return false;
            }
            return false;
        }

        private bool isPlayersTurn()
        {
            if (turn.ActiveFaction == players.PlayerFaction)
                return true;
            else
                return false;
        }

        private bool isMoveBlocked(int movabilityIndex)
        {
            if (!tiles[movabilityIndex].IsOccupied)
                return false;

            if (pieces[getOccupyingPiece(movabilityIndex)].Faction == turn.ActiveFaction)
                return true;

            if (pieces[getOccupyingPiece(movabilityIndex)].Faction != turn.ActiveFaction && tiles[movabilityIndex].TypeIndex == 1)
                return true;
            else if (pieces[getOccupyingPiece(movabilityIndex)].Faction != turn.ActiveFaction && tiles[movabilityIndex].TypeIndex != 1)
                return false;

            return true;
        }

        private int getUnoccupiedStation()
        {
            List<int> stationIndices = getPieceStationsByFaction(turn.ActiveFaction);

            for(int i=stationIndices.Count-1;i>=0;i--)
            {
                if (tiles[stationIndices[i]].IsOccupied == false)
                    return tiles[stationIndices[i]].PhysicalIndex;
            }
            return -1;
        }

        private int getUnoccupiedOpponentStation()
        {
            List<int> stationIndices = getPieceStationsByFaction(turn.InactiveFaction);

            for (int i=0;i<stationIndices.Count;i++)
            {
                if (tiles[stationIndices[i]].IsOccupied == false)
                    return tiles[stationIndices[i]].PhysicalIndex;
            }
            return -1;
        }

        private Bitmap getImage(int index)
        {
            switch(index)
            {
                case 1:
                    return GoUR_FP.Properties.Resources._1;
                case 2:
                    return GoUR_FP.Properties.Resources._2;
                case 3:
                    return GoUR_FP.Properties.Resources._3;
                case 4:
                    return GoUR_FP.Properties.Resources._4;
                case 5:
                    return GoUR_FP.Properties.Resources._5;
                case 6:
                    return GoUR_FP.Properties.Resources._6;
                case 7:
                    return GoUR_FP.Properties.Resources._7;
                case 8:
                    return GoUR_FP.Properties.Resources._8;
                case 9:
                    return GoUR_FP.Properties.Resources._9;
                case 10:
                    return GoUR_FP.Properties.Resources._10;
                case 11:
                    return GoUR_FP.Properties.Resources._11;
                case 12:
                    return GoUR_FP.Properties.Resources._12;
                case 13:
                    return GoUR_FP.Properties.Resources.hl_whitepiece;
                case 14:
                    return GoUR_FP.Properties.Resources.err_whitepiece;
                case 15:
                    return GoUR_FP.Properties.Resources.hl_blackpiece;
                case 16:
                    return GoUR_FP.Properties.Resources.err_blackpiece;
                default:
                    return GoUR_FP.Properties.Resources._0;
            }
        }

        private Bitmap getDefaultImageByFaction()
        {
            switch (turn.ActiveFaction)
            {
                case 1:
                    return Properties.Resources.whitepiece;
                case 2:
                    return Properties.Resources.blackpiece;
                default:
                    return null;
            }
        }

        private Bitmap getSelImageByFaction()
        {
            switch(turn.ActiveFaction)
            {
                case 1:
                    return getImage(13);
                case 2:
                    return getImage(15);
                default:
                    return null;
            }
        }

        private Bitmap getErrImageByFaction()
        {
            switch (turn.ActiveFaction)
            {
                case 1:
                    return getImage(14);
                case 2:
                    return getImage(16);
                default:
                    return null;
            }
        }

        private void linkToTile(PictureBox p, int physicalIndex)
        {
            p.Tag = physicalIndex;
        }

        private int getTileLinkIndex(int tileIndex)
        {
            return Convert.ToInt32(pboxes[tileIndex].Tag);
        }

        private int getTileVisualIndex(string tileName)
        {
            return Convert.ToInt32(tileName.Substring(2));
        }

        private void highlightTile(int tileIndex)
        {
            switch(isPlayersTurn())
            {
                case true:
                    using (Graphics g = Graphics.FromImage(pboxes[getTileByPieceDestination(tiles[tileIndex].OccupantIndex)].BackgroundImage))
                    {
                        Pen highlighter = new Pen(Color.CornflowerBlue, 5);
                        Brush highlightBrush = new SolidBrush(Color.FromArgb(110, Color.LightSteelBlue));
                        g.DrawRectangle(highlighter, 1, 1, 70, 70);
                        g.FillRectangle(highlightBrush, 2, 2, 68, 68);
                        pboxes[getTileByPieceDestination(tiles[tileIndex].OccupantIndex)].Invalidate();
                    }
                    break;
                case false:
                    using (Graphics g = Graphics.FromImage(pboxes[getTileByPieceDestination(tiles[tileIndex].OccupantIndex)].BackgroundImage))
                    {
                        Pen highlighter = new Pen(Color.Firebrick, 5);
                        Brush highlightBrush = new SolidBrush(Color.FromArgb(110, Color.Tomato));
                        g.DrawRectangle(highlighter, 1, 1, 70, 70);
                        g.FillRectangle(highlightBrush, 2, 2, 68, 68);
                        pboxes[getTileByPieceDestination(tiles[tileIndex].OccupantIndex)].Invalidate();
                    }
                    break;
            }

        }

        private void dehighlightTile(int tileIndex)
        {
            int destTile = getTileByPieceDestination(tiles[tileIndex].OccupantIndex);

            if (destTile < 0)
                return;

            switch (isPlayersTurn())
            {
                case true:
                    pboxes[destTile].BackgroundImage = getImage(tiles[destTile].SkinIndex);
                    break;
                case false:
                    pboxes[destTile].BackgroundImage = getImage(tiles[destTile].SkinIndex);
                    break;
            }
        }

        private void refreshTile(int tileIndex)
        {
            pboxes[tileIndex].BackgroundImage = getImage(tiles[tileIndex].SkinIndex);

            if (tiles[tileIndex].IsOccupied && pieces[tiles[tileIndex].OccupantIndex].HasFinished)
            {
                pboxes[tileIndex].Image = Properties.Resources.finishedpiece;
                return;
            }

            if (tiles[tileIndex].IsOccupied && pieces[tiles[tileIndex].OccupantIndex].Faction == 1)
                pboxes[tileIndex].Image = Properties.Resources.whitepiece;
            else if (tiles[tileIndex].IsOccupied && pieces[tiles[tileIndex].OccupantIndex].Faction == 2)
                pboxes[tileIndex].Image = Properties.Resources.blackpiece;
            else if (!tiles[tileIndex].IsOccupied)
                pboxes[tileIndex].Image = null;
        }

        #endregion

        #region -AI operations-

        private void aiRollDice()
        {
            Timer t = new Timer();
            t.Interval = 3000;
            t.Start();
            t.Tick += (o, e) =>
              {
                  t.Stop();
                  renderDice(dice.roll());
                  dice.DiceReady = false;
                  turn.RollUsed = true;
                  pbCup.BackgroundImage = GoUR_FP.Properties.Resources.Rolling_cup_empty;
                  enableMovingPhase();
                  t.Dispose();
              };
        }

        private void aiMakeAMove()
        {
            disableMovingPhase();
            Timer t = new Timer();
            t.Interval = 3000;
            t.Start();
            t.Tick += (o, e) =>
              {
                  t.Stop();
                  BullRusherAIMove();
                  t.Dispose();
              };
        }

        private void BullRusherAIMove()
        {
            List<int> selectedTiles = Enumerable.Range(0, tiles.Count)
                                        .Where(x => (tiles[x].OwnerIndex==turn.ActiveFaction || tiles[x].OwnerIndex==3) && tiles[x].IsOccupied && pieces[tiles[x].OccupantIndex].Faction==turn.ActiveFaction)
                                        .Where(x => pieces[tiles[x].OccupantIndex].Nextmove.Destination > 0)
                                        .OrderByDescending(x => tiles[x].TrackIndex)
                                        .ToList<int>();
            int bestPiece = tiles[selectedTiles[0]].OccupantIndex;
            doCollateralMove(pieces[bestPiece].OccupyingIndex, pieces[bestPiece].Nextmove.Destination);                            
        }

        #endregion

        #region -Events-

        private void PbCup_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left && e.Clicks==1 && dice.DiceReady && !turn.RollUsed && isPlayersTurn())
            {
                renderDice(dice.roll());
                dice.DiceReady = false;
                turn.RollUsed = true;              
                pbCup.BackgroundImage = GoUR_FP.Properties.Resources.Rolling_cup_empty;
                enableMovingPhase();
            }
        }

        private void PbStartupRoll_MouseDown(object sender, MouseEventArgs e)
        {
            pbStartupRoll.Enabled = false;
            lblBlink.Tag = 3;
            lblBlink.Text = Properties.Resources.ROLLING;
            pbStartupRoll.BackgroundImage = Properties.Resources.Rolling_cup_start_empty;
            lockPlayerControls(true);

            Timer t = new Timer();
            t.Interval = 250;
            t.Start();

            t.Tick += (o, f) =>
              {
                  lblBlink.Tag = ((int)lblBlink.Tag + 1);
                  
                  switch((int)lblBlink.Tag)
                  {
                      case 4:
                          pbStartDice1.Visible = true;
                          break;
                      case 5:
                          pbStartDice2.Visible = true;
                          break;
                      case 6:
                          pbStartDice3.Visible = true;
                          break;
                      case 7:
                          pbStartDice4.Visible = true;
                          lblBlink.Text = Properties.Resources.START_GAME;
                          break;
                      case 12:
                          t.Stop();
                          Timer tscroll = new Timer();
                          tscroll.Interval = 2;

                          pnlStartUp.Dock = DockStyle.None;
                          pnlStartUp.Top = 0;
                          pnlStartUp.Height = 691;
                          pbStartupRoll.Visible = false;
                          lblBlink.Visible = false;
                          pbStartDice1.Visible = pbStartDice2.Visible = pbStartDice3.Visible = pbStartDice4.Visible = false;
                          pnlStartUp.BackgroundImageLayout = ImageLayout.Tile;
                          tscroll.Start();

                          tscroll.Tick += (p, g) =>
                            {
                                if (pnlStartUp.Width > 0)
                                    pnlStartUp.Width = pnlStartUp.Width - 100;
                                else
                                {
                                    lockPlayerControls(false);
                                    tscroll.Stop();
                                    tscroll.Dispose();
                                }
                            };

                          t.Dispose();
                          break;
                  }
              };
        }

        private void Pb_MouseEnter(object sender, EventArgs e)
        {
            if (!turn.RollUsed || !isPlayerMoveEnabled)
                return;

            PictureBox pb = (PictureBox)sender;
            int vindex = getTileVisualIndex(pb.Name);
            int index = getTileLinkIndex(vindex);

            //set MoveMode
            //check for rosettes aka consequences
            //highlight knockouts
            if (tiles[index].IsOccupied && isPieceFactionActive(index, 1) && isMoveMode() && isPlayersTurn())
            {
                if (pieces[tiles[index].OccupantIndex].Nextmove.IsMovable)
                {
                    pb.Image = getSelImageByFaction();
                    highlightTile(index);
                }
                else
                {
                    pb.Image = getErrImageByFaction();
                }
            }
        }

        private void Pb_MouseLeave(object sender, EventArgs e)
        {
            if (!turn.RollUsed || !isPlayerMoveEnabled)
                return;

            PictureBox pb = (PictureBox)sender;
            int vindex = getTileVisualIndex(pb.Name);
            int index = getTileLinkIndex(vindex);

            //set MoveMode
            //check for rosettes aka consequences
            if(tiles[index].IsOccupied && pieces[tiles[index].OccupantIndex].HasFinished)
            {
                pb.Image= Properties.Resources.finishedpiece;
                return;
            }

            if (tiles[index].IsOccupied && isPieceFactionActive(index, 1) && isMoveMode() && isPlayersTurn())
            {
                dehighlightTile(index);
                pb.Image=getDefaultImageByFaction();
            }
        }

        private void Pb_MouseDown(object sender, MouseEventArgs e)
        {
            if (!turn.RollUsed || !isPlayerMoveEnabled || e.Button!=MouseButtons.Left)
                return;

            PictureBox pb = (PictureBox)sender;
            int vindex = getTileVisualIndex(pb.Name);
            int index = getTileLinkIndex(vindex);
            int destIndex = -1;
            //set MoveMode
            //check for rosettes aka consequences
            //highlight knockouts
            if (tiles[index].IsOccupied && isPieceFactionActive(index, 1) && isMoveMode() && isPlayersTurn())
            {
                destIndex= getTileByPieceDestination(tiles[index].OccupantIndex);

                if (pieces[tiles[index].OccupantIndex].Nextmove.IsMovable)
                {
                    playerMove(index, destIndex);
                    //move //consequances //visual update
                }
            }
        }

        private void FrmSurface_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!gameStarted)
            {
                PbStartupRoll_MouseDown(pbStartupRoll, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            }
            KeyPress -= FrmSurface_KeyPress;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
