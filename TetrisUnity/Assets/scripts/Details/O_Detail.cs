namespace Tetris
{
 public  class O_Detail: Part<SimpleCube> 
    {
        
        public O_Detail (int X, int Y):base(X,Y)
        {
            cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.O_Detail);
            findCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(positionX, positionY);
        }
        public override void Rotate(bool direction)
        {
            
        }
         
      

    }
}
