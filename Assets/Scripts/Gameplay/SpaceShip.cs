using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public ParticleSystem impactParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(false);
            ShowImpactParticle();
            Debug.Log("hit Spaceship");
        }
    }

    private void ShowImpactParticle()
    {
        if (impactParticle != null)
        {
            ParticleSystem impactInstance = Instantiate(impactParticle, transform.position, Quaternion.identity);

            Destroy(impactInstance.gameObject, impactInstance.main.duration);
        }
    }
}
