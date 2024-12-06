using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreboard;
    public void scoreUpdater(int increasedScore)
    {
        if (gameManager.GameOver) return; 
        score += increasedScore;
        scoreboard.text = score.ToString();
    }
}
