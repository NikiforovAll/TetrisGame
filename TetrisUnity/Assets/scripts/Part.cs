namespace Tetris
{

    public abstract class Part<T> where T : SimpleCube
    {

        protected SimpleCube[] Cubes;
        protected int PositionX;
        protected int PositionY;
        protected SimpleCube CentralCube;

        public Part(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }

        protected void FindCentralCube()
        {
            int i = 0;
            if (Cubes != null)
                while (!Cubes[i++].isCentral) { }
            CentralCube = Cubes[--i];
        }
        protected void SetPos(int x, int y)
        {
            CentralCube.SetPos(x, y);
            this.PositionX = x;
            this.PositionY = y;
            UpdatePos();
        }
        public SimpleCube[] GetCubes
        {
            get
            {
                return Cubes;
            }
        }

        public void MoveDown()
        {
            this.SetPos(PositionX, PositionY + 1);
        }
        public void MoveUp()
        {
            this.SetPos(PositionX, PositionY - 1);
        }
        public void MoveRight()
        {
            this.SetPos(PositionX + 1, PositionY);
        }
        public void MoveLeft()
        {
            this.SetPos(PositionX - 1, PositionY);
        }

        // true  - clockwise right
        // false - clockwise left
        public virtual void Rotate(bool direction)
        {
            foreach (SimpleCube cube in Cubes)
            {
                cube.Rotate(direction);
            }
            UpdatePos();
        }
        private void UpdatePos()
        {
            UpdatePos(CentralCube);
        }
        private static void UpdatePos(SimpleCube simCubeInstance)
        {
            int currPosX = simCubeInstance.getPosX;
            int currPosY = simCubeInstance.getPosY;
            SimpleCube[] arrConj = simCubeInstance.getConj;
            for (int i = 0; i < 4; i++)
            {
                if (arrConj[i] != null)
                {
                    switch (i)
                    {
                        case 0:
                            arrConj[0].SetPos(currPosX - 1, currPosY);
                            break;
                        case 1:
                            arrConj[1].SetPos(currPosX, currPosY - 1);
                            break;
                        case 2:
                            arrConj[2].SetPos(currPosX + 1, currPosY);
                            break;
                        case 3:
                            arrConj[3].SetPos(currPosX, currPosY + 1);
                            break;
                    }
                    UpdatePos(arrConj[i]);
                }
            }
        }

    }


}
