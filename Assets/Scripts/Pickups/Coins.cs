using UnityEngine;

public class Coins : Pickup
{
    [SerializeField] int scoreToIncrease = 100;
    [SerializeField] AudioSource coinPickupSound;
    ScoreManager scoreManager;
    public void Init (ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickup()
    {
        scoreManager.scoreUpdater(scoreToIncrease);
        coinPickupSound.Play();
    }
}
