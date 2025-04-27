using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // lík skot
    Rigidbody2D rigidbody2d;


    // sækir í skot lík
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // uppfærrir 
    void Update()
    {
        // ef það hefur farið 100 eða hlutinn
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    // ef skotið
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }


    // ef hittir óvinn þá er óvinur lagaður
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
        }


        Destroy(gameObject);
    }

}
