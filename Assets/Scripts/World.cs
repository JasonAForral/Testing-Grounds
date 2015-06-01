using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public static World world;

    public Chunk chunkPrefab;

    public int chunkWidth = 1;
    public int chunkHeight = 1;
    Transform myTransform;

    public Transform sphere;

    public float viewRange;

    float chunkWidthInverse;

    public float input;
    public float floorOutput;



    void Awake ()
    {
        if (null == world)
            world = this;
        else if (this != world)
            Destroy(gameObject);

        //if (0 == seed)
        //    seed = Random.Range(0, int.MaxValue);

        myTransform = transform;
        chunkWidthInverse = 1f / (float)chunkWidth;
    }

    public int chunkCount;

    void Update ()
    {
        chunkCount = Chunk.chunks.Count;
        Vector3 checkPosition =
            new Vector3(
            Mathf.Floor((myTransform.position.x * chunkWidthInverse) + 0.5f) * (float)chunkWidth,
            0f,
            Mathf.Floor((myTransform.position.z * chunkWidthInverse) + 0.5f) * (float)chunkWidth);
        
        sphere.transform.position = new Vector3(checkPosition.x, myTransform.position.y, checkPosition.z);

        for (float x = myTransform.position.x - viewRange; x < myTransform.position.x + viewRange; x += chunkWidth) {
            for (float z = myTransform.position.z - viewRange; z < myTransform.position.z + viewRange; z += chunkWidth) {
                Vector3 pos = new Vector3(x, 0, z);

                pos.x = Mathf.Floor(pos.x * chunkWidthInverse) * (float)chunkWidth;
                pos.z = Mathf.Floor(pos.z * chunkWidthInverse) * (float)chunkWidth;
                //sphere.transform.position = pos;

                Chunk chunk = Chunk.FindChunk(pos);
                if (chunk != null) {
                    //Debug.Log(pos);
                    continue;
                }
                Debug.Log("not null");

                chunk = (Chunk)Instantiate(chunkPrefab, pos, Quaternion.identity);
            }
        }
    }
}