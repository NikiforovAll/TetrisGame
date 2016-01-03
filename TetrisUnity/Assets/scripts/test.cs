using UnityEngine;


public class test : MonoBehaviour {

    public float deltaPos = 0.5f;
    public float CubeSize = 1f;
    public GameObject SC;
   
	// Use this for initialization
	void Start () {
        GameObject plane = GameObject.Find("Plane");
       Vector3 test = plane.GetComponent<Collider>().bounds.size;
       Debug.Log(test);
        GameObject[] MyArr= new GameObject[10];

        for(int i = 0 ; i<10; i++)
        {
           MyArr[i] =(GameObject) Instantiate(SC,new Vector3(deltaPos+i*CubeSize,0,0),Quaternion.identity);
        }
        
       

       //GameObject testCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
       //testCube.AddComponent<Rigidbody>();
       //testCube.GetComponent<Rigidbody>().useGravity = false;
       //testCube.transform.localScale = new Vector3(1, 1, 1);
       //testCube.transform.position = new Vector3(0, 0, 0);
       //test = testCube.GetComponent<Collider>().bounds.size;
       //Debug.Log(test);

        

        
	}
	
	// Update is called once per frame
	void Update () {

       
        
        
        
        
       
	}
}
