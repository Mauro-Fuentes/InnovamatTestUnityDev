using UnityEngine;

public class ParticlesWin : MonoBehaviour
{
    private ParticleSystem particles;
    private Controller controller;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        controller = FindObjectOfType<Controller>();
        controller.GameWasWon += StartParticles;
    }

    private void StartParticles()
    {

        particles.Play();
    }
}
