using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private ParticleSystem collectParticles;

    [SerializeField] private float floatingSpeed = 1;
    [SerializeField] private float floatingHeight = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & mask.value) > 0)
            Collect();
    }

    private void Collect()
    {
        collectParticles.transform.SetParent(null);
        collectParticles.Play();

        Destroy(gameObject);
    }
}