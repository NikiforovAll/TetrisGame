namespace Tetris
{
   public  class T_Detail: Part<SimpleCube>
    {
        public T_Detail (int X, int Y):base(X,Y)
        {
            Cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.T_Detail);
            FindCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(PositionX, PositionY);
        }
    }
}
