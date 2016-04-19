using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ToVictory()
    {
        SceneManager.LoadScene("Victory");
    }
}
