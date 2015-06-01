using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    public static List<Chunk> chunks = new List<Chunk>();

    public static int width
    {
        get
        {
            return World.world.chunkWidth;
        }
    }
    public static int height
    {
        get
        {
            return World.world.chunkHeight;
        }
    }

    void Start ()
    {
        chunks.Add(this);
    }

    public static Chunk FindChunk (Vector3 pos)
    {
        for (int a = 0; a < chunks.Count; a++) {
            Vector3 cpos = chunks[a].transform.position;
            //if ((pos.x < cpos.x) || (pos.x > cpos.x + width) ||
            //    (pos.z < cpos.z) || (pos.z > cpos.z + width))
            //    continue;
            if (pos == cpos)
            return chunks[a];
        }
        return null;
    }
}