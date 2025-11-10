using UnityEngine;

public class MiniMapFitCamera : MonoBehaviour
{
   
    public float landscapeMazeWidth = 20f;
    public float landscapeMazeHeight = 10f;

    public float portraitMazeWidth = 20f;
    public float portraitMazeHeight = 10f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        float aspect = (float)Screen.width / Screen.height;

        float mazeWidth;
        float mazeHeight;

        if (aspect > 1f)
        {
            mazeWidth = landscapeMazeWidth;
            mazeHeight = landscapeMazeHeight;
        }
       
        else
        {
            mazeWidth = portraitMazeWidth;
            mazeHeight = portraitMazeHeight;
        }

      
        float sizeByHeight = mazeHeight / 2f;
        float sizeByWidth = mazeWidth / (2f * aspect);

        cam.orthographicSize = Mathf.Max(sizeByHeight, sizeByWidth);
    }
}
