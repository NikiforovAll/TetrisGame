using UnityEngine;
using Tetris;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public GameObject CubePrefab;
    public static float CubeSize = 1;
    public static Vector3 Spawn = new Vector3(4, 0, 1);
    public static Part<SimpleCube> CurrPart;
    public static GameObject[] TmpArr;

    public Text Txt;
    public static float Time = 0;
    public static int Speed = 20;
    public static float Interval;
    public static int Height = 15;
    public static int Width = 10;
    public static GameObject[,] GameBoardUnity = new GameObject[Width, Height];
    public static GameField<SimpleCube> GameFiled = new GameField<SimpleCube>(Height, Width);
    // private Material materialColored = new Material(Shader.Find("Diffuse"));

    private void FillBoard(GameObject[] part)
    {
        //Debug.Log(tmpArr.Length);
        for (int i = 0; i < TmpArr.Length; i++)
        {
            //  Debug.Log(currPart.GetCubes[i].getPosX + "- X : Y - " + currPart.GetCubes[i].getPosY);
            GameBoardUnity[CurrPart.GetCubes[i].GetPosX, CurrPart.GetCubes[i].GetPosY] =
                (GameObject)Instantiate(TmpArr[i]);
            // System.Threading.Thread.Sleep(5000);
        }

    }
    private bool ScoreConditionUnity()
    {

        if (GameFiled.ScoreCondition())
        {

            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    //if (GameFiled.GameBoard[j, i] == null)
                    {
                        if (GameBoardUnity[j, i] != null)
                        {
                            Debug.Log(string.Format("i = {0}, j={1}", i, j));
                            Destroy(GameBoardUnity[j, i]);
                        }

                    }

                }
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    if (GameFiled.GameBoard[j, i] != null)
                    {
                        GameBoardUnity[j, i] = (GameObject)Instantiate(CubePrefab, new Vector3(-CubeSize / 2 + j * CubeSize, 0, -i * CubeSize)
                               , Quaternion.identity);
                        //  GameBoardUnity[j,i].AddComponent<Materia
                    }

                }
            return true;
        }
        return false;
    }
    private void ClearBoard()
    {
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
            {

                Destroy(GameBoardUnity[j, i]);


            }
    }
    public static void Translate(GameObject cube, SimpleCube p)
    {
        cube.transform.position = new Vector3(-CubeSize / 2 + p.GetPosX * CubeSize, 0,
             -p.GetPosY * CubeSize);
    }
    public static void TranslatePart(GameObject[] partUnity, Part<SimpleCube> part)
    {
        for (int i = 0; i < partUnity.Length; i++)
        {
            Translate(partUnity[i], part.GetCubes[i]);
        }
    }
    public static void GetRandomPart()
    {
        int numberOfAvailableParts = 7;
        System.Random r = new System.Random();
        switch (r.Next(numberOfAvailableParts))
        {
            case 0:
                CurrPart = new I_Detail((int)Spawn.x, (int)Spawn.z);
                break;
            case 1:
                CurrPart = new J_Detail((int)Spawn.x, (int)Spawn.z);
                break;
            case 2:
                CurrPart = new L_Detail((int)Spawn.x, (int)Spawn.z);
                break;
            case 3:
                CurrPart = new O_Detail((int)Spawn.x, (int)Spawn.z);
                break;
            case 4:
                CurrPart = new S_Detail((int)Spawn.x, (int)Spawn.z);
                break;
            case 5:
                CurrPart = new T_Detail((int)Spawn.x, (int)Spawn.z);
                break;
            case 6:
                CurrPart = new Z_Detail((int)Spawn.x, (int)Spawn.z);
                break;

            default:
                break;
        }

    }


    public void Start()
    {
        // Screen.SetResolution(640, 480, true);
        Interval = Speed * UnityEngine.Time.deltaTime;
        GetRandomPart();
        int sizeOfPart = CurrPart.GetCubes.Length;
        TmpArr = new GameObject[sizeOfPart];


        for (int i = 0; i < CurrPart.GetCubes.Length; i++)
        {
            // Debug.Log(currPart.GetCubes[i].getPosX);
            TmpArr[i] = (GameObject)Instantiate(CubePrefab, Spawn, Quaternion.identity);

        }
        TranslatePart(TmpArr, CurrPart);



    }

    // Update is called once per frame
    public static bool InGame = true;

    public void Update()
    {


        if (Time < Interval)
        {
            Time += UnityEngine.Time.deltaTime;
        }
        else
        {
            Time = 0;
            if (!InGame)
            {
                GetRandomPart();
                if (GameFiled.LoseCondition(CurrPart))
                {

                    GameFiled = new GameField<SimpleCube>(Height, Width);
                    ClearBoard();

                }
                InGame = true;
            }

            if (!GameFiled.MoveDown(CurrPart))
            {
                FillBoard(TmpArr);
                TranslatePart(TmpArr, CurrPart);
                ScoreConditionUnity();

                InGame = false;
            }




        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameFiled.MoveLeft(CurrPart);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameFiled.MoveRight(CurrPart);
        }
        if (Input.GetButton("S"))
        {
            Time *= 2;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameFiled.Rotate(CurrPart, false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameFiled.Rotate(CurrPart, true);
        }

        //  scoreText.text = "Score" + GameFiled.score;
        Txt.text = "Score " + GameFiled.Score;
        TranslatePart(TmpArr, CurrPart);


    }
}
