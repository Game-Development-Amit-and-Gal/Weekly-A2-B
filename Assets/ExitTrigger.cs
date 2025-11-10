using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameObject winPanel; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("YOU WIN!");

           
            if (winPanel != null)
            {
                winPanel.SetActive(true);  
            }

            Time.timeScale = 0f;            
        }
    }
}
