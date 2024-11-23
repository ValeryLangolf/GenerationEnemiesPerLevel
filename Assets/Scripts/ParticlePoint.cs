using UnityEngine;

public class ParticlePoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    public void ShowSpawn()
    {
        _particle.Play();
    }
}