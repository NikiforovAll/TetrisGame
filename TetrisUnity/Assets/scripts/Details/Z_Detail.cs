namespace Tetris
{
    public class Z_Detail : Part<SimpleCube> 
    {
        public Z_Detail (int X, int Y):base(X,Y)
        {
            Cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.Z_Detail);
            FindCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(PositionX, PositionY);
        }
    }
}
