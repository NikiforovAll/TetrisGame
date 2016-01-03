namespace Tetris
{
    public class J_Detail:Part<SimpleCube> 
    {
        public J_Detail (int X, int Y):base(X,Y)
        {
            cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.J_Detail);
            findCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(positionX, positionY);
        }
    }
}
