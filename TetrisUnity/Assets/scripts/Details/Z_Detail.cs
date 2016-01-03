namespace Tetris
{
    public class Z_Detail : Part<SimpleCube> 
    {
        public Z_Detail (int X, int Y):base(X,Y)
        {
            cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.Z_Detail);
            findCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(positionX, positionY);
        }
    }
}
