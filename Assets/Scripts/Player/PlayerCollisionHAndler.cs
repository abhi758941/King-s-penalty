using UnityEngine;

public class PlayerCollisionHAndler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustMoveSpeedAmmount = -2f;
    LevelGenerator levelGenerator;
    const string hitString = "Hit";
    float cooldownTimer = 0f;
    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(cooldownTimer< collisionCooldown) return;
        levelGenerator.ChangeChunkMoveSpeed(adjustMoveSpeedAmmount);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;   
    }
}
