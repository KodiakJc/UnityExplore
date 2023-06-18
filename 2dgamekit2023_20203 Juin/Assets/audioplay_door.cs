using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioplay_door : MonoBehaviour
{
    void Doorisopening(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
    }
}