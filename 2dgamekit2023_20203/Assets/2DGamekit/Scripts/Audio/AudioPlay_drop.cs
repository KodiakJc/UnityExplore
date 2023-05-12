using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioPlay_drop : MonoBehaviour
{
    public FMODUnity.EventReference water_drop;

    private ParticleSystem particleSystem;

    private void Start()
    {
        // Récupérer le composant ParticleSystem de l'objet
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        // Récupérer les données de collision de la particule
        ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];
        int eventCount = particleSystem.GetCollisionEvents(other, collisionEvents);

        // Déclencher l'événement FMOD en one-shot à la position de l'impact
        for (int i = 0; i < eventCount; i++)
        {
            Vector3 position = collisionEvents[i].intersection;
            FMODUnity.RuntimeManager.PlayOneShot(water_drop, position);
        }
    }
}
