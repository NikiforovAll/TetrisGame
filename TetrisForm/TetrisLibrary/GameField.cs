using System;
using TetrisLibrary;

namespace Tetris
{
    public class GameField<T> where T : ITetrisable, new()
    {
        protected int Height;
        protected int Width;
        protected int Score;
        protected int SpawnPointX;
        protected int SpawnPointY;
        private static int _lineScore = 100;
        // protected SimpleCube[,] GameBoard;
        protected SimpleCube[,] GameBoard;
        private T[,] _gameBoardObj;



        public GameField(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.Score = 0;
            // Spawn POINT
            SpawnPointX = width / 2 - 1;
            SpawnPointY = 1;
            GameBoard = new SimpleCube[width, height];
            _gameBoardObj = new T[width, height];
        }
        public int GetScore
        {
            get { return Score; }
        }
        // make a simple game move 
        //return true if player keep playing
        public bool PlayGame(ref Part<T> part)
        {
            if (part == null)
            {
                part = part = new Part<T>(
                    PartDefinitions.GerDefinedRandomPart());
                SpawnPart(part);
            }
            else
            {
                if (!MoveDown(part))
                {
                    ScoreCondition();
                    part = new Part<T>(
                    PartDefinitions.GerDefinedRandomPart());
                    SpawnPart(part);
                    if (LoseCondition(part))
                        return false;

                }

            }

            return true;
        }
        // rendering new table 
        private void Sync()
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i, j] != null && _gameBoardObj == null)
                    {
                        if (_gameBoardObj != null) _gameBoardObj[i, j] = (T)new T().Create(GameBoard[i, j]);
                    }
                    else if (_gameBoardObj != null && (GameBoard[i, j] == null && _gameBoardObj[i, j] != null))
                    {
                        _gameBoardObj[i, j].Delete();
                        _gameBoardObj[i, j] = default(T);
                    }
                }
            }
        }

        private void SpawnPart(Part<T> part)
        {
            part.SetPos(SpawnPointX, SpawnPointY);
            part.Sync();
        }
        // adding part 
        private void FillBoard(Part<T> part)
        {
            foreach (SimpleCube sc in part.GetCubes)
            {
                GameBoard[sc.GetPosX, sc.GetPosY] = sc;
                _gameBoardObj[sc.GetPosX, sc.GetPosY] = (T)new T().Create(sc);

            }
        }

        private bool LoseCondition(Part<T> part)
        {
            return !isValid(part);
        }
        // return true if player scored a line *!!
        private bool ScoreCondition()
        {
            int multiScore = 0;
            bool scored;
            bool[] scoredLine = new bool[Height];
            for (int i = 0; i < Height; i++)
            {
                scored = true;
                for (int j = 0; j < Width; j++)
                {
                    if (GameBoard[j, i] == null)
                    {
                        scored = false;
                        break;
                    }
                }
                if (scored)
                {//multi line bonus score
                    multiScore++;
                    scoredLine[i] = true;
                }
            }
            int downOffset = 0;
            if (multiScore > 0)
                for (int i = Height - 1; i > 0; i--)
                {
                    if (scoredLine[i])
                    {
                        downOffset++;
                        continue;
                    }
                    if (downOffset > 0)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            GameBoard[j, i + downOffset] = GameBoard[j, i];
                            GameBoard[j, i] = null;
                        }
                    }
                }
            //end:
            Score += multiScore * _lineScore;
            if (multiScore > 0)
            {
                Sync();
                return true;
            }
            return false;

        }

        #region Actions
        // wrappers for valid moves        

        #region supportAct


        // true - right 1 false - (-1) no err 0 
        private bool isValid(Part<T> part, out bool isOutOfBoard, out int side)
        {
            isOutOfBoard = false;
            side = 0;
            foreach (SimpleCube sc in part.GetCubes)
            {
                try
                {
                    if (sc.GetPosX > Width - 1)
                    {
                        side = 1;
                    }
                    else if (sc.GetPosX < 0)
                    {
                        side = -1;
                    }

                    if (GameBoard[sc.GetPosX, sc.GetPosY] != null)
                    {
                        return false;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    isOutOfBoard = true;
                    return false;
                }

            }
            return true;
        }
        private bool isValid(Part<T> part)
        {
            bool foo;
            int foo1;
            return isValid(part, out foo, out foo1);
        }
        #endregion

        public bool MoveLeft(Part<T> part)
        {
            part.MoveLeft();
            if (!isValid(part))
            {
                part.MoveRight();
                return false;
            }
            part.Sync();
            return true;
        }
        public bool MoveRight(Part<T> part)
        {
            part.MoveRight();
            if (!isValid(part))
            {
                part.MoveLeft();
                return false;
            }
            part.Sync();
            return true;

        }
        public bool MoveDown(Part<T> part)
        {
            part.MoveDown();
            if (!isValid(part))
            {
                part.MoveUp();
                FillBoard(part);
                part.Delete();
                return false;
            }
            part.Sync();
            return true;
        }
        // true  - clockwise right
        // false - clockwise left
        // simple spin
        public bool Rotate(Part<T> part, bool orientation)
        {
            bool factor;
            int side;
            part.Rotate(orientation);
            if (!isValid(part, out factor, out side))
            {
                part.Rotate(!orientation);
                if (factor)
                {
                    if (side == 1)
                    {
                        if (MoveLeft(part))
                        {
                            return Rotate(part, orientation);
                        }
                    }
                    else
                    {
                        if (MoveRight(part))
                        {
                            return Rotate(part, orientation);
                        }
                    }
                }
                return false;
            }
            part.Sync();
            return true;
        }
        #endregion


    }
}
