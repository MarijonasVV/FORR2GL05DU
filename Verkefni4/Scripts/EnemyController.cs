using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    // hreyfing og hversu lengi þau lappa breyttur
    public float speed;
    public bool vertical;
    public float changeTime;
    // sækir í reykinn
    public ParticleSystem smokeEffect;
    // líkamanninn
    Rigidbody2D rigidbody2d;
    // hreyfing
    Animator animator;
    // timer óvinur
    float timer;
    // hvaða átt
    int direction = 1;
    // ef það er brotið eða ekki
    bool broken = true;


    // Þegar leikur byrjar
    void Start()
    {
        // sækir í breyttur og hreyfing og líkamann
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }


    // uppfært hvert frame
    void Update()
    {

        // timi
        timer -= Time.deltaTime;

        // ef tími er ekki búinn
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    // uppfært
    void FixedUpdate()
    {
        // ef það er ekki brotið
        if (!broken)
        {
            return;
        }

        // hreyfir upp eða niður fer eftir hvað ég setti
        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        // hreyfir
        rigidbody2d.MovePosition(position);
    }

    // ef snertir leikmann þá tapr leikmaðurinn líf
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();


        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    // ef notandi hittir með skot er óvinur lagaður
    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
    }

}
