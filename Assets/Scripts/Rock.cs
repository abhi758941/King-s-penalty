using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] AudioSource boulderAudio;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] float shakeModifier = 5f;
    [SerializeField] float collisionCooldown = 1f;
    float collisionTimer = 1f;
    CinemachineImpulseSource cinemachineImpulseSource;
    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();

    }
    void Update()
    {
        collisionTimer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < collisionCooldown) return;
        FireImpulse();
        CollisionVFX(other);
        collisionTimer = 0;
    }

    void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = 1 / distance * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
    void CollisionVFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        boulderAudio.Play();
    }
}
