using UnityEngine;


namespace Tetris
{
    public class SimpleCubeUnity : SimpleCube
    {
        private readonly SimpleCube mainCube;
        public GameObject Cube;
        public SimpleCubeUnity(SimpleCube mainCube, GameObject cube)
        {
            this.mainCube = mainCube;
            this.Cube = cube;
        }
        public void UpdatePos()
        {
            Cube.transform.position = new Vector3(mainCube.GetPosX * UnityGameFiled.CubeSize, 1,
                mainCube.GetPosY * UnityGameFiled.CubeSize);
        }




    }
}
