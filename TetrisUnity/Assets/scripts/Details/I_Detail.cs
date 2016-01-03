namespace Tetris
{
    public class I_Detail: Part<SimpleCube> 
    {
      

         public I_Detail (int X, int Y):base(X,Y)
        {
            Cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.I_Detail);
            FindCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(PositionX, PositionY);
        }

        
        
        
    }
}
