using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PLayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject GameoverText;
    [SerializeField] float startTime = 5f;
    float timeLeft;
    bool gameOver = false;
    
    public bool GameOver => gameOver;
    void Start()
    {
        timeLeft = startTime;
    }
    void Update()
    {
        if(gameOver) return;
        DecreaseTime();
        if (timeLeft <= 0)
        {
            PlayerGameOver();
        }
    }

    private void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F2");
    }

    public void IncreaseTime(float timeToIncrease)
    {
        if(gameOver) return;
        timeLeft += timeToIncrease;
    }
    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        GameoverText.SetActive(true);
        Time.timeScale = .1f;
    }
    
}
