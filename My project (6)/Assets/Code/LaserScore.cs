using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Invader1"))
        {
         
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(10); 
            }

           
            
        }

        if (collision.CompareTag("Invader2"))
        {

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(20);
            }


            
        }

        if (collision.CompareTag("Invader3"))
        {

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(30);
            }


          
        }

        if (collision.CompareTag("MysteryShip"))
        {
           
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(50);
            }


          
        }

    }
}
