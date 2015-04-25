using UnityEngine;
using System.Collections;

public class SpriteField : MonoBehaviour {

    Transform boardHolder;
    public GameObject[] Tiles;

    public Point3 spriteFieldDimensions = new Point3 (10, 0, 10);
    public float spriteScale = 1;


    void Start ()
    {
        boardHolder = new GameObject("Board").transform;

        Vector3 perlinOrigin = new Vector3(Random.Range(0f, 1000f), 0f, Random.Range(0f, 1000f));
        
        float perlinScale = 6f;


        Vector3 spriteFieldOffset = new Vector3(spriteFieldDimensions.x - 1, 0f, spriteFieldDimensions.z - 1) * spriteScale * 0.5f;

        Vector3 spriteFieldDimensionsInverse = new Vector3(1f / spriteFieldDimensions.x, 1f , 1f / spriteFieldDimensions.z );
        Debug.Log(spriteFieldDimensionsInverse.x);

        for (int z = 0; z < spriteFieldDimensions.z; z++)
        {

            for (int x = 0; x < spriteFieldDimensions.x; x++)
            {
                Vector3 perlinInput = new Vector3(spriteFieldDimensionsInverse.x * x, 0f, spriteFieldDimensionsInverse.z * z) * perlinScale + perlinOrigin;
                float perlinShade = Mathf.PerlinNoise(perlinInput.x, perlinInput.z) ;
                int perlinOutput = Mathf.Clamp(Mathf.FloorToInt(perlinShade * 4f), 0, Tiles.Length - 1);

                Vector3 position = new Vector3(x, 0f, z) * spriteScale - spriteFieldOffset;

                Debug.Log(perlinOutput);
                GameObject instance = Instantiate(Tiles[perlinOutput], position, Quaternion.Euler(Vector3.right * 90f)) as GameObject;
                instance.transform.SetParent(boardHolder);

            }
        }
    }

}
