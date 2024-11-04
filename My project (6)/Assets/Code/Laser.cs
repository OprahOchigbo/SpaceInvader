using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Laser : Projectile
{

    private void Awake()
    {
        direction = Vector3.up;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);
    }

    void CheckCollision(Collider2D collision)
    {
        Bunker bunker = collision.gameObject.GetComponent<Bunker>();

        if (bunker == null) // Om det inte är en bunker vi träffat så ska skottet försvinna.
        {
            Invader invader = collision.gameObject.GetComponent<Invader>();

            // Only destroy the laser if it does not hit an invader (let the invader handle destruction if hit)
            if (invader == null)
            {
                Destroy(gameObject); // Destroy the laser only if it's not hitting an invader
            }
        }

    }
}
