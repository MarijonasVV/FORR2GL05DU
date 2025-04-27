using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Breyttur fyrir hreyfing leikmannsins
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

    // Breyttur fyrir líf leikmannsins
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    // Breyttir fyrir þegar leikmaðurinng meiðist
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    // Breyttur fyrir animation
    Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);

    // Breyttur fyrir skjótta
    public GameObject projectilePrefab;





    // Þegar leikmaðurinn byrjar leikinn
    void Start()
    {
        //kveikja á hreyfingu
        MoveAction.Enable();

        //lík leikmans
        rigidbody2d = GetComponent<Rigidbody2D>();

        //setjir max líf sem current
        currentHealth = maxHealth;

        //fyrir hreyfingar
        animator = GetComponent<Animator>();

    }


    // uppfærir 
    void Update()
    {

        //fær input og hreyfir
        move = MoveAction.ReadValue<Vector2>();


        //tekur inn hreyfingu og setir sem movement
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }

        //hreyfing
        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        //kíkir ef leikmaður er invincible
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;

            //þegar hættir
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

        //ef notandi ýttir á c, þá kasta þau
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        //ef notandi ýttir á x þá talar við npc
        if (Input.GetKeyDown(KeyCode.X))
        {
            FindFriend();
        }
    }


    //´uppfærir hvert hreyfingu
    void FixedUpdate()
    {
        //færir leikmannin
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }


    public void ChangeHealth(int amount)
    {
        //if hærra en 0
        if (amount < 0)
        {
            //ef invincible ekkert gerist
            if (isInvincible)
            {
                return;
            }
            //annar verður invicnible 
            isInvincible = true;
            damageCooldown = timeInvincible;
            animator.SetTrigger("Hit");
        }
        //breyttir líf
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //úi breyttist
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);

        //ef notandi hefur 0 líf þá tapar leikmaður
        if (currentHealth == 0)
        {
            SceneManager.LoadScene(3);
        }
    }


    //notandi kastar hlut
    void Launch()
    {
        //gerir nýtt prefab sem kastar hlut
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(moveDirection, 300);
        animator.SetTrigger("Launch");
    }


    //finnir npc
    void FindFriend()
    {
        //ef það er nóg nálægt þá getur leikmaðurinn talað við þeim
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
            if (character != null)
            {
                UIHandler.instance.DisplayDialogue();
            }
        }
    }



}
