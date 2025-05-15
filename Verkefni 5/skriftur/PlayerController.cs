using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Breyttur fyrir hreyfing leikmannsins
    public InputAction MoveAction;
    public InputAction JumpAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;
    public float jumpForce = 500.0f;


    // Breyttur fyrir líf leikmannsins
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;


    // Breyttur fyrir animation
    Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);

    // Breyttur fyrir skjótta
    public GameObject projectilePrefab;

    //geymir stig
    public static int count = 5;
    public TextMeshProUGUI countText;


    // Þegar leikmaðurinn byrjar leikinn
    void Start()
    {
        //kveikja á hreyfingu
        MoveAction.Enable();
        JumpAction.Enable();

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
        if (!Mathf.Approximately(move.x, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }

        //hreyfing
        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Speed", move.magnitude);

        //ef notandi hoppar
        if (JumpAction.WasPerformedThisFrame())
        {
            Jump();
        }


        //ef notandi ýttir á c, þá kasta þau
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

    }


    //´uppfærir hvert hreyfingu
    void FixedUpdate()
    {
        //færir leikmannin
        Vector2 velocity = rigidbody2d.velocity;
        velocity.x = move.x * speed;
        rigidbody2d.velocity = velocity;

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

    //ef notandi snerti kiwi
    void OnTriggerEnter2D(Collider2D other)
    {
        // kíkir ef það er kiwi og bætir við 1 stig
        if (other.tag == "Kiwi")
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();//kallar á fallið
        }
    }
        //stig sem sést á skjáinn, ef það er minna en 0 tapar leikmaðurinn
    public void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();

        if (count <= -1)
        {
            SceneManager.LoadScene(3);
        }

    }
    //fall sem lætur leikmann hoppa
    void Jump()
    {
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
    }
}
