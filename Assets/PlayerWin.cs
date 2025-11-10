using UnityEngine;

public class PlayerWin : MonoBehaviour
{
   
    public GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Exit"))
        {
            Debug.Log("You Win!");

            
            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }

       
            Time.timeScale = 0f;  
        }
    }
}
