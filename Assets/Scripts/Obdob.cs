using UnityEngine;
using System.Collections;

public class Obdob : MonoBehaviour {

    MeshFilter meshFilter;
    Mesh mesh2;
    Transform boardHolder;
    //Vector3[] vertecies;

    public GameObject waterTile;

	// Use this for initialization
	void Start () {

        boardHolder = new GameObject ("Board").transform;

        meshFilter = GetComponent<MeshFilter>();
        //Debug.Log(meshFilter.mesh.bounds);

        
        //mesh2 = MeshGenerator.GeneratePlane();

        //meshFilter.sharedMesh = mesh2;

        loopThrough2(meshFilter.sharedMesh.vertices);
        
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public static void loopThrough<Type> (Type[] param)
    {
        Debug.Log(param.Length);
        for (int i = 0; i < param.Length; i++)
        {
            Debug.Log(i + " => " + param[i]);

        }
    }

    void loopThrough2 (Vector3[] position)
    {
        Vector3 myPosition = transform.position;
        for (int i = 0; i < position.Length; i++)
        {
           // Debug.Log(i + " => " + param[i]);
            GameObject instance = Instantiate(waterTile, myPosition + position[i], Quaternion.Euler(Vector3.right * 90f)) as GameObject;
            instance.transform.SetParent(boardHolder);
        }
    }
}
