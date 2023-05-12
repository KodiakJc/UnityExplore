using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public Transform circle; // référence à l'objet Circle
    public Collider2D acidCollider; // référence au box collider 2D de l'objet Acid correspondant

    private float minX; // position X minimale autorisée pour l'objet Circle
    private float maxX; // position X maximale autorisée pour l'objet Circle

    void Start()
    {
        // déterminer les positions X minimale et maximale autorisées
        minX = acidCollider.bounds.min.x + circle.GetComponent<SpriteRenderer>().bounds.extents.x;
        maxX = acidCollider.bounds.max.x - circle.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void Update()
    {
        // associer la position X de l'avatar avec la position X de l'objet Circle
        circle.position = new Vector2(transform.position.x, circle.position.y);

        // empêcher l'objet Circle de sortir des limites du box collider 2D de l'objet Acid correspondant
        float newX = Mathf.Clamp(circle.position.x, minX, maxX);
        circle.position = new Vector2(newX, circle.position.y);
    }
}