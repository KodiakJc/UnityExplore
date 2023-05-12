using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBoxPosition : MonoBehaviour
{
    public GameObject pushableBox; // Référence à l'objet PushableBox dans la scène
    float pushableBoxPosY; // Variable pour stocker la position Y de l'objet PushableBox

    void Update()
    {
        pushableBoxPosY = pushableBox.transform.position.y; // Récupère la position Y actuelle de l'objet PushableBox
        Debug.Log("La position Y de l'objet PushableBox est : " + pushableBoxPosY); // Affiche la position Y dans la console Unity
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("YoyoWater", pushableBoxPosY);
    }
}
