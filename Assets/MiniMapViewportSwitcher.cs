using UnityEngine;

public class MiniMapViewportSwitcher : MonoBehaviour
{
    public Rect rectLandscape = new Rect(0.65f, 0f, 0.35f, 0.25f); 
    public Rect rectPortrait = new Rect(0.55f, 0f, 0.45f, 0.3f);   

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float aspect = (float)Screen.width / Screen.height;

       
        if (aspect > 1f)
        {
            cam.rect = rectLandscape;
        }
        else                
        {
            cam.rect = rectPortrait;
        }
    }
}
