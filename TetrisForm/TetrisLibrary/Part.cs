using Tetris;

namespace TetrisLibrary
{

    public class Part<T> where T : ITetrisable, new()
    {

        protected SimpleCube[] Cubes;
        // posX,posY == centralCube.X,.Y 
        protected int PositionX;
        protected int PositionY;
        protected SimpleCube CentralCube;
        private bool _isRotatable;        
        protected T[] ModelObjects;

        public Part(int positionX, int positionY, PartDefinitions.Definition def = PartDefinitions.Definition.T_Detail, bool isRotatable = true)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;

            if (def == PartDefinitions.Definition.ODetail)
            {
                isRotatable = false;
            }
            else
            {
                this._isRotatable = isRotatable;
            }

            this.Cubes = PartDefinitions.GetPartDefinition(def);
            ModelObjects = new T[Cubes.Length];
            FindCentralCube();
            SetPos(positionX, positionY);
            for (int i = 0; i < Cubes.Length; i++)
            {

                ModelObjects[i] = (T)new T().Create(Cubes[i]);
            }

        }
        public Part(PartDefinitions.Definition def, bool isRotatable = true)
            : this(0, 0, def, isRotatable)
        {
        }
        // native interface for Part (no ITetrisable implementation)
        public void Sync()
        {
            for (int i = 0; i < Cubes.Length; i++)
            {
                ModelObjects[i].Sync(Cubes[i]);               
            }
        }
        public void Delete()
        {
            for (int i = 0; i < Cubes.Length; i++)
            {
                ModelObjects[i].Delete();
            }
        }

        protected void FindCentralCube()
        {
            int i = 0;
            if (Cubes != null)
                while (!Cubes[i++].IsCentral) { }
            CentralCube = Cubes[--i];
        }
        public void SetPos(int x, int y)
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
            if (_isRotatable)
            {
                foreach (SimpleCube cube in Cubes)
                {
                    cube.Rotate(direction);
                }
                UpdatePos();
            }

        }
        private void UpdatePos()
        {
            UpdatePos(CentralCube);
        }
        private void UpdatePos(SimpleCube simCubeInstance)
        {
            int currPosX = simCubeInstance.GetPosX;
            int currPosY = simCubeInstance.GetPosY;
            SimpleCube[] arrConj = simCubeInstance.GetConj;
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
