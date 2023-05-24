using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioplay_enemies : MonoBehaviour
{
    void StartAttack(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }

    void StartDeath(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }

    void PlayFootStep(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }

    void Shooting(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }

    //gunner

    void PlayStep(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }

     void LightningCharge(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }

     void LaserCharge(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }

}