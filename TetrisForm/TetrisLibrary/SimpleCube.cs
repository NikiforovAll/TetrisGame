using System;

namespace Tetris
{

    public class SimpleCube
    {
        // position 
        // Is center Cube 

        // Conjunctions 
        // SimpleCube leftConj;  Conj[0] 
        // SimpleCube rightConj; Conj[1]
        // SimpleCube UpConj;    Conj[2]
        // SimpleCube DownConj;  Conj[3]
        public SimpleCube()
        {
            IsCentral = false;
        }
        public SimpleCube(int x, int y)
        {
            this.GetPosX = x;
            this.GetPosY = y;
            this.IsCentral = true;
        }

        public int GetPosX { get; private set; }
        public int GetPosY { get; private set; }

        public bool IsCentral { get; }

        public SimpleCube[] GetConj { get; private set; } = new SimpleCube[4];

        public SimpleCube[] setConj
        {
            set
            {
                GetConj = value;
            }
        }
        public void SetConj(SimpleCube left = null, SimpleCube up = null, SimpleCube right = null, SimpleCube down = null)
        {
            GetConj[0] = left;
            GetConj[1] = up;
            GetConj[2] = right;
            GetConj[3] = down;
        }
        public void SetPos(int x, int y)
        {
            this.GetPosX = x;
            this.GetPosY = y;
        }

        // true - clockwise right
        // false - clockwise left
        public void Rotate(bool direction)
        {
            if (direction)
            {
                SimpleCube tmpCube = GetConj[GetConj.Length - 1];
                Array.Copy(GetConj, 0, GetConj, 1, GetConj.Length - 1);
                GetConj[0] = tmpCube;
            }
            else
            {
                SimpleCube tmpCube = GetConj[0];
                Array.Copy(GetConj, 1, GetConj, 0, GetConj.Length - 1);
                GetConj[GetConj.Length - 1] = tmpCube;
            }

        }
    }


}
