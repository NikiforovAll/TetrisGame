using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tetris
{
    class GameField
    {
        protected  int height;
        protected  int width;
        protected int score;
        protected int spawnPointX;
        protected int spawnPointY;
        private static int lineScore = 100;
       // protected SimpleCube[,] GameBoard;
          protected SimpleCube[,]GameBoard;
          

        public GameField (int height, int width)
        {
            this.height = height;
            this.width = width;
            this.score = 0;
            // Spawn POINT
            spawnPointX = width / 2;
            spawnPointY = 1;
            GameBoard = new SimpleCube[width, height];

        }    
        // return true if player scored a line
        protected bool loseCondition(Part part)
        {
            return !isValid(part);
        }
       
        protected bool scoreCondition()
        {
            int multiScore = 0;
            bool scored ;
            bool[] scoredLine = new bool[height];
            for(int i = 0 ; i<height;i++)
            {
                scored = true;
                for(int j = 0; j< width;j++)
                {
                    if(GameBoard[j,i]==null)
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
            if(multiScore>0)
            for (int i = height-1; i > 0 ; i--)
            {
                if(scoredLine[i])
                {
                    downOffset++;
                    continue;
                }
                if(downOffset>0)
                {
                    for (int j = 0; j < width; j++)                        
                    {
                        GameBoard[j, i + downOffset] = GameBoard[j, i];
                        GameBoard[j, i] = null;
                    }                         
                }
            }
            //end:
           score += multiScore * lineScore;    
           return multiScore>0? true : false;
        }

        #region Actions
        // wrappers for valid moves        
        
        #region supportAct
        private void fillBoard(Part part, bool value)
        {
            foreach (SimpleCube sc in part.GetCubes)
            {
                GameBoard[sc.getPosX, sc.getPosY] = sc;
            }
        }
        // true - right 1 false - (-1) no err 0 
        private bool isValid(Part part, out bool isOutOfBoard, out int side)
        {
            isOutOfBoard = false;
            side = 0;
            foreach (SimpleCube sc in part.GetCubes)
            {
                try
                {
                    if(sc.getPosX>width-1)
                    {
                        side = 1;
                    }
                    else if (sc.getPosX<0)
                    {
                        side = -1;
                    }

                    if (GameBoard[sc.getPosX, sc.getPosY] !=null)
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
        private bool isValid(Part part)
        {
            bool foo;
            int foo1;            
            return isValid(part, out foo, out foo1);
        }
        #endregion        
        
         public bool MoveLeft(Part part)
        {
             part.MoveLeft();
             if(!isValid(part))
             {
                 part.MoveRight();
                 return false;
             }
             return true;
        }
         public bool MoveRight(Part part)
         {
             part.MoveRight();
             if(!isValid(part))
             {
                 part.MoveLeft();                 
                 return false;
             }
             return true;
             
         }
         public bool MoveDown(Part part)
        {
            part.MoveDown();
             if(!isValid(part))
             {                 
                 part.MoveUp();
                 fillBoard(part, true);
                 return false;
             }             
             return true;
        }
        // true  - clockwise right
        // false - clockwise left
        // simple spin
        public bool Rotate(Part part, bool orientation)
         {
             bool factor;
             int side;
             part.Rotate(orientation);
            if(!isValid(part, out factor, out side))
            {
                part.Rotate(!orientation);
                if(factor)
                {
                    if(side == 1)
                    {
                        if (MoveLeft(part))
                        {
                            return Rotate(part, orientation);
                        }                        
                    }
                    else
                    {                        
                        if(MoveRight(part))
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
