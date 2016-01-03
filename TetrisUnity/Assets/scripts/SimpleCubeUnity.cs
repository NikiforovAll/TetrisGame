using UnityEngine;


namespace Tetris
{
   public  class SimpleCubeUnity:SimpleCube
    {
       private SimpleCube mainCube;
       public GameObject cube;
       public SimpleCubeUnity(SimpleCube mainCube, GameObject cube)
       {
           this.mainCube = mainCube;
           this.cube = cube;
       }
       public void updatePos()
       {           
           
           cube.transform.position = new Vector3(mainCube.getPosX * UnityGameFiled.CubeSize, 1,
               mainCube.getPosY*UnityGameFiled.CubeSize);
       }

       


    }
}
