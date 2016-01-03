namespace Tetris
{
   public  class L_Detail : Part<SimpleCube> 
    {
       public L_Detail (int X, int Y):base(X,Y)
        {
            cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.L_Detail);
            findCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(positionX, positionY);
        }
    }
}
