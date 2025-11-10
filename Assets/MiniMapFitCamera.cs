using UnityEngine;

public class MiniMapFitCamera : MonoBehaviour
{
    // ערכים למצב לרוחב (16:9 בערך)
    public float landscapeMazeWidth = 20f;
    public float landscapeMazeHeight = 10f;

    // ערכים למצב לאורך (9:16 בערך)
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

        // אם המסך לרוחב (רוחב גדול מגובה) – נשתמש בערכים של landscape
        if (aspect > 1f)
        {
            mazeWidth = landscapeMazeWidth;
            mazeHeight = landscapeMazeHeight;
        }
        // אחרת – המסך לאורך (גובה גדול מרוחב) – נשתמש בערכים של portrait
        else
        {
            mazeWidth = portraitMazeWidth;
            mazeHeight = portraitMazeHeight;
        }

        // מכאן זה כמו קודם – מחשבים Size לפי גודל המבוך והיחס הנוכחי
        float sizeByHeight = mazeHeight / 2f;
        float sizeByWidth = mazeWidth / (2f * aspect);

        cam.orthographicSize = Mathf.Max(sizeByHeight, sizeByWidth);
    }
}
