using System;


namespace Tetris
{
    public class GameField<T> where T : SimpleCube
    {
        protected int Height;
        protected int Width;
        // protected int score;
        public int Score;
        protected int SpawnPointX;
        protected int SpawnPointY;
        private static int _lineScore = 100;
        // protected SimpleCube[,] GameBoard;
        public T[,] GameBoard;


        public GameField(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.Score = 0;
            // Spawn POINT
            SpawnPointX = width / 2;
            SpawnPointY = 1;
            GameBoard = new T[width, height];

        }

        // return true if player scored a line
        public bool LoseCondition(Part<T> part)
        {
            return !isValid(part);
        }

        public bool ScoreCondition()
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
                {
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
            return multiScore > 0;
        }

        #region Actions
        // wrappers for valid moves        

        #region supportAct
        private void FillBoard(Part<T> part, bool value)
        {
            foreach (T sc in part.GetCubes)
            {
                GameBoard[sc.getPosX, sc.getPosY] = sc;
            }
        }
        // true - right 1 false - (-1) no err 0 
        public bool isValid(Part<T> part, out bool isOutOfBoard, out int side)
        {
            isOutOfBoard = false;
            side = 0;
            foreach (SimpleCube sc in part.GetCubes)
            {
                try
                {
                    if (sc.getPosX > Width - 1)
                    {
                        side = 1;
                    }
                    else if (sc.getPosX < 0)
                    {
                        side = -1;
                    }

                    if (GameBoard[sc.getPosX, sc.getPosY] != null)
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
        public bool isValid(Part<T> part)
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
            return true;

        }
        public bool MoveDown(Part<T> part)
        {
            part.MoveDown();
            if (!isValid(part))
            {
                part.MoveUp();
                FillBoard(part, true);
                return false;
            }
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
            return true;
        }
        #endregion


    }
}
