using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioplay_pickup : MonoBehaviour
{

    //[FMODUnity.EventRef]
    //public string pickup_weapon = "";
    public FMODUnity.EventReference pickup_weapon;
    FMOD.Studio.EventInstance playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = FMODUnity.RuntimeManager.CreateInstance(pickup_weapon);
    }

    public void Play()
    {
        playerState.start();
    }

}
