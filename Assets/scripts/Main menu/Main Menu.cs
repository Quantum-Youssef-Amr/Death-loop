using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play Game");
        //SceneManager.LoadScene("add the scene name here");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        //Application.Quit();
    }


}
