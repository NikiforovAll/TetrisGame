namespace Tetris
{
 public  class O_Detail: Part<SimpleCube> 
    {
        
        public O_Detail (int X, int Y):base(X,Y)
        {
            Cubes = PartDefinitions.GetPartDefinition(PartDefinitions.Definition.O_Detail);
            FindCentralCube();
            // set central cube position as a center of a part 
            this.SetPos(PositionX, PositionY);
        }
        public override void Rotate(bool direction)
        {
            
        }
         
      

    }
}
