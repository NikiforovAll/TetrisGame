namespace Tetris
{
   public  class S_Detail : Part<SimpleCube>
    {
        public S_Detail (int X, int Y):base(X,Y)
        {
            cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.S_Detail);
            findCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(positionX, positionY);
        }
    }
}
