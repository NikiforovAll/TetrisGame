namespace Tetris
{
   public  class L_Detail : Part<SimpleCube> 
    {
       public L_Detail (int X, int Y):base(X,Y)
        {
            Cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.L_Detail);
            FindCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(PositionX, PositionY);
        }
    }
}
