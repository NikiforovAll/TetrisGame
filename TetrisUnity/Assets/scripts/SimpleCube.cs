using System;


namespace Tetris
{
    
       public class SimpleCube
        {
            // position 
            int positionX;
            int positionY;
            // Is center Cube 
            bool isCenter;
            // Conjunctions 

            // SimpleCube leftConj;  Conj[0] 
            // SimpleCube rightConj; Conj[1]
            // SimpleCube UpConj;    Conj[2]
            // SimpleCube DownConj;  Conj[3]
           SimpleCube[] Conj = new SimpleCube[4];
            public SimpleCube()
            {
                isCenter = false;
            }
            public SimpleCube(int X, int Y)
            {
                this.positionX = X;
                this.positionY = Y;
                this.isCenter = true;
            }
            public void SetConj(SimpleCube left = null, SimpleCube up = null, SimpleCube right = null, SimpleCube down = null)
            {
                Conj[0] = left;
                Conj[1] = up;
                Conj[2] = right;
                Conj[3] = down;
            }

            public void SetPos(int X, int Y)
            {
                this.positionX = X;
                this.positionY = Y;
            }
            public int getPosX
            {
                get
                {
                    return positionX;
                }                
            }
            public int getPosY
            {
                get 
                {
                      return positionY;
                }              
            }

            public bool isCentral
            {
                get
                {
                    return isCenter;
                }               
            }
            public SimpleCube[] getConj
            {
                get
                {
                    return Conj;
                }
              
            }
           public SimpleCube[] setConj
            {
                set
                {
                    Conj = value;
                }
            }
           // true - clockwise right
           // false - clockwise left
           public void Rotate(bool direction)
           {              
               if (direction)              
               {
                   SimpleCube tmpCube = Conj[Conj.Length - 1];
                   Array.Copy(Conj, 0, Conj, 1, Conj.Length - 1);
                   Conj[0] = tmpCube;                   
               }
               else
               {
                   SimpleCube tmpCube = Conj[0];
                   Array.Copy(Conj, 1, Conj, 0, Conj.Length - 1);
                   Conj[Conj.Length - 1] = tmpCube;                  
               }

           }
        }
 
}
