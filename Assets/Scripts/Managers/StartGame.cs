using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        StartTheGame();
    }

    void StartTheGame()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene); 
        }
    }
}
