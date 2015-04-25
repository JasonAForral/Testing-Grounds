using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FrameCounter : MonoBehaviour {

    private Text fpsText;

    float fpsTimer = 0;
    float updateInterval = 1f;

    void Start ()
    {
        fpsText = GetComponent<Text>();
    }

    void LateUpdate ()
    {
        if (fpsTimer < updateInterval)
        {
            fpsTimer++;
        }
        else
        {
            fpsTimer = 0;
            fpsText.text = Mathf.FloorToInt(1f/Time.deltaTime) + " fps";
        }
    }
}
