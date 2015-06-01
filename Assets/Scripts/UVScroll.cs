using UnityEngine;
using System.Collections;

public class UVScroll : MonoBehaviour
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";
    [SerializeField]
    private Renderer rendererObject;

    Vector2 uvOffset = Vector2.zero;

    void Awake ()
    {
        rendererObject = GetComponent<Renderer>();
    }

    void LateUpdate ()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (rendererObject.enabled)
        {
            rendererObject.sharedMaterials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}