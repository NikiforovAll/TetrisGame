using UnityEngine;

namespace Tetris
{
    class UnityGameFiled:GameField<SimpleCubeUnity>
    {
        public static float CubeSize;
        public GameObject cube;

        public UnityGameFiled(int height, int width, float CubeSize, GameObject cube)
            : base(height, width)
        {
            UnityGameFiled.CubeSize = CubeSize;
            this.cube = cube;

        }
        public void UpdatePos()
        {
            foreach(SimpleCubeUnity sc in GameBoard)
            {
                sc.updatePos();
            }
        }
    }
}
