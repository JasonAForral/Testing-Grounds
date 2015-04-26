using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random; 


public class MeshGenerator {

     [Serializable]
    private struct Coord3
    {
        public Vector3 _inverse;

        public Vector3 inverse
        {
            get
            {
                return _inverse;
            }
        }

        private Point3 _coord;

        public Point3 coord
        {
            
            get
            {
                return _coord;
            }
            set
            {
                _inverse = Inverse(value);
                _coord = value;
            }
        }

        public Coord3 ( Point3 point)
        {
            _coord = point;
            _inverse = Inverse(point);
            
        }

        public static Vector3 Inverse (Point3 value)
        {
            Vector3 output= new Vector3();
            if (0 != value.x)
            {
                output.x = 1f / (float)value.x;
            }
            if (0 != value.y)
            {
                output.y = 1f / (float)value.y;
            }
            if (0 != value.z)
            {
                output.z = 1f / (float)value.z;
            }
            return output;
        }

        public static Coord3 operator + (Coord3 a, int b)
        {
            return new Coord3(a.coord + b);
        }
    }

    // overloads

    public static Mesh GeneratePlane ()
    {
        return GeneratePlane(new Point3(1, 1, 1), 1f);
    }

    public static Mesh GeneratePlane (int faceCountX, int faceCountZ)
    {
        return GeneratePlane(new Point3(faceCountX, 1, faceCountZ), 1f);
    }

    public static Mesh GeneratePlane (int faceCountX, int faceCountZ, float faceScale)
    {
        return GeneratePlane(new Point3(faceCountX, 1, faceCountZ), faceScale);
    }

    public static Mesh GeneratePlane (Point3 faceCount)
    {
        return GeneratePlane(faceCount, 1f);
    }

    public static Mesh GeneratePlane (Point3 faceCount, float faceSize)
    {

        if (0 == faceCount.x || 0 == faceCount.z)
            return new Mesh();

        Vector3 planeOffset = new Vector3(faceCount.x, 0f, faceCount.z) * faceSize * 0.5f;

        Coord3 face = new Coord3(faceCount);
        Coord3 vertex = face + 1;

        int numVerts = vertex.coord.x * vertex.coord.z;

        Vector3[] vertices = new Vector3[numVerts];
        Vector3[] normals = new Vector3[numVerts];
        int[] triangles = new int[face.coord.x * face.coord.z * 6];
        Vector2[] uv = new Vector2[numVerts];
        //Debug.Log("triangles.length = "+triangles.Length);

        for (int z = 0; z < vertex.coord.z; z++)
        {
            int vertexIndex;
            for (int x = 0; x < vertex.coord.x; x++)
            {
                vertexIndex = (vertex.coord.x * z) + x;

                vertices[vertexIndex] = new Vector3(x, 0f, z) * faceSize - planeOffset;
                normals[vertexIndex] = Vector3.up;
                uv[vertexIndex] = new Vector2(face.inverse.x * (float)x, face.inverse.z * (float)z);
                //Debug.Log(vertex.inverse);
            }
        }

        for (int z = 0; z < face.coord.z; z++)
        {
            int faceIndex;
            int vertexIndex;

            for (int x = 0; x < face.coord.x; x++)
            {
                faceIndex = (face.coord.x * z + x) * 6;
                vertexIndex = vertex.coord.x * z + x;

                //Debug.Log("(" + x + ", " + z + ")");

        
                triangles[faceIndex    ] = vertexIndex;
                triangles[faceIndex + 1] = vertexIndex + vertex.coord.x;
                triangles[faceIndex + 2] = vertexIndex + 1 + vertex.coord.x;
                triangles[faceIndex + 3] = vertexIndex + 1;
                triangles[faceIndex + 4] = vertexIndex;
                triangles[faceIndex + 5] = vertexIndex + 1 + vertex.coord.x;

                //Debug.Log("face " + faceIndex + " => vertecies"
                //    + ", " + vertexIndex
                //    + ", " + (vertexIndex + 1)
                //    + ", " + (vertexIndex + vertex.coord.z)
                //    + ", " + (vertexIndex + 1 + vertex.coord.z));
            }
        }


        Mesh mesh = new Mesh();

        mesh.name = "The Plane";
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.triangles = triangles;
        mesh.uv = uv;

        mesh.RecalculateNormals();
        mesh.Optimize();

        return mesh;
	}

}
