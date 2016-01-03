using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tetris
{
   // namespace Part
    //{
        public   abstract /*partial*/ class Part
        {
            public enum Definition { O_Detail, I_Detail, J_Detail, L_Detail,S_Detail,Z_Detail,T_Detail };
            protected SimpleCube[] cubes;
            // posX,posY == centralCube.X,.Y  ? 

            protected int positionX;
            protected int positionY;
            protected SimpleCube centralCube;    
        
            public Part(int positionX, int positionY)
            {
                this.positionX = positionX;
                this.positionY = positionY;
            }
           

            protected void findCentralCube()
            {
                int i = 0;
                if (cubes != null)
                    while (!cubes[i++].isCentral) { }
                centralCube = cubes[--i];
            }
            protected void SetPos(int X, int Y)
            {
                centralCube.SetPos(X,Y);
                this.positionX = X;
                this.positionY = Y;                
                UpdatePos();
            }
            public SimpleCube[] GetCubes
            {
                get
                {
                    return cubes;
                }
            }
            
            public void MoveDown()
            {
                this.SetPos(positionX, positionY + 1);
            }
            public void MoveUp()
            {
                this.SetPos(positionX, positionY - 1);
            }
            public void MoveRight()
            {
                this.SetPos(positionX+1, positionY);
            }
            public void MoveLeft()
            {
                this.SetPos(positionX - 1, positionY);
            }          
           
           // true  - clockwise right
           // false - clockwise left
           public virtual void Rotate(bool direction)
            {
                foreach (SimpleCube cube in cubes)
                {
                    cube.Rotate(direction);
                }
                UpdatePos();
            }
           private void UpdatePos()
           {
               UpdatePos(centralCube);
           }
            private static void UpdatePos(SimpleCube SimCubeInstance)
             {
                int currPosX = SimCubeInstance.getPosX;
                int currPosY = SimCubeInstance.getPosY;
                SimpleCube[] ArrConj =SimCubeInstance.getConj;
                for(int i = 0 ; i<4 ;i++)
                {
                    if(ArrConj[i]!=null)
                    {
                        switch(i)
                        {
                            case 0:
                                ArrConj[0].SetPos(currPosX - 1, currPosY);                                
                                break;
                            case 1:
                                ArrConj[1].SetPos(currPosX, currPosY-1);
                                break;
                            case 2:
                                ArrConj[2].SetPos(currPosX + 1, currPosY);
                                break;
                            case 3:
                                ArrConj[3].SetPos(currPosX, currPosY + 1);
                                break;
                        }
                        UpdatePos(ArrConj[i]);
                    }
                }
             }

        }
   // }
   
}
