namespace Tetris
{
   public  class T_Detail: Part<SimpleCube>
    {
        public T_Detail (int X, int Y):base(X,Y)
        {
            cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.T_Detail);
            findCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(positionX, positionY);
        }
    }
}
