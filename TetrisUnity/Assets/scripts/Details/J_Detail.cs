namespace Tetris
{
    public class J_Detail:Part<SimpleCube> 
    {
        public J_Detail (int X, int Y):base(X,Y)
        {
            Cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.J_Detail);
            FindCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(PositionX, PositionY);
        }
    }
}
