namespace Tetris
{
    public class I_Detail: Part<SimpleCube> 
    {
      

         public I_Detail (int X, int Y):base(X,Y)
        {
            cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.I_Detail);
            findCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(positionX, positionY);
        }

        
        
        
    }
}
