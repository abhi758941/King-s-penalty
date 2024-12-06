using UnityEngine;
using UnityEngine.Apple.ReplayKit;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    void Update() 
    {
        Replay();
    }
    void Replay()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
            Time.timeScale = 1f;
        }
    }
}
