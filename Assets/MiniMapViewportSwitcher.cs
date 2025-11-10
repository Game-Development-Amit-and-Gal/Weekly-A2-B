using UnityEngine;

public class MiniMapViewportSwitcher : MonoBehaviour
{
    public Rect rectLandscape = new Rect(0.65f, 0f, 0.35f, 0.25f); // 16:9
    public Rect rectPortrait = new Rect(0.55f, 0f, 0.45f, 0.3f);   // 9:16 – תשני איך שטוב לך

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float aspect = (float)Screen.width / Screen.height;

        // אם הרוחב גדול מהגובה → מסך לרוחב (16:9 בערך)
        if (aspect > 1f)
        {
            cam.rect = rectLandscape;
        }
        else                // מסך לאורך (9:16)
        {
            cam.rect = rectPortrait;
        }
    }
}
