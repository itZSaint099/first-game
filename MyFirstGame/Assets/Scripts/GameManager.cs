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
            //Debug.Log("GAME OVER");
            // Restart Ganme
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
