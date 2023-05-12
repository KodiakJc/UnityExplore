using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioplay_cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/Gunner/GunnerIntro", transform.position);
    }

}
