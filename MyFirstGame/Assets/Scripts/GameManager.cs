using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool endGame = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    
    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }

    public void GameOver()
    {
        if(endGame == false)
        {
            endGame = true;
            
            // Restart Ganme
            Invoke("RestartGame", restartDelay);
            //Debug.Log("GAME OVER");
        }
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
