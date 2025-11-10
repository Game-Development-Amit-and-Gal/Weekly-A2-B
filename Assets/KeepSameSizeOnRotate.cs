using UnityEngine;



[RequireComponent(typeof(Camera))]
public class KeepSameSizeOnRotate : MonoBehaviour
{
  
    public float baseOrthoSize = 5f;

    private int baseScreenHeight;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();

      
        cam.orthographic = true;

        
        if (baseOrthoSize <= 0f)
        {
            baseOrthoSize = cam.orthographicSize;
        }

        baseScreenHeight = Screen.height;

        UpdateCameraSize();
    }

    private void Update()
    {
 
        UpdateCameraSize();
    }

    private void UpdateCameraSize()
    {
        float heightRatio = (float)Screen.height / baseScreenHeight;

        cam.orthographicSize = baseOrthoSize * heightRatio;
    }
}
