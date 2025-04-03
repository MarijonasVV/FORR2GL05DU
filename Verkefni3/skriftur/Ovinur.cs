using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using TMPro;

public class Ovinur : MonoBehaviour
{
    //líf leikmanns, leikmaður og fleiri breyttur
    public static int health = 30;
    public Transform player;
    private  TextMeshProUGUI texti;
    private Rigidbody rb;
    private Vector3 movement;
    public float hradi = 5f;

    void Start()
    {
        //finnur text2 til að skrifa líf
        texti = GameObject.Find("Text2").GetComponent<TextMeshProUGUI>();
        rb = this.GetComponent<Rigidbody>();
        texti.text = "Líf " + health.ToString();
    }

    void Update()
    {
        //láta óvinni elta leikmannin
        Vector3 stefna = player.position - transform.position;
        stefna.Normalize();
        movement = stefna;
    }
    private void FixedUpdate()
    {
        //hreyfir óvinn
        Hreyfing(movement);
    }
    //hvernig óvinur hreyfist
    void Hreyfing(Vector3 stefna)
    {
        rb.MovePosition(transform.position + (stefna * hradi * Time.deltaTime));
    }
    //ef snertir eitthvað
    private void OnCollisionEnter(Collision collision)
    {
        //ef það er leikmaður, eyðir sjálfan sig og leikmaður tapar 10 líf
        if (collision.collider.tag=="Player")
        {
            Destroy(gameObject);
            Debug.Log("Leikmaður fær í sig óvin");
            TakeDamage(10);
            gameObject.SetActive(false);
        }
    }
    //tekur líf
    public void TakeDamage(int damage)
    {
        //tekur 10 líf af leikmann
        Debug.Log("health er núna" + (health).ToString());
        health -= damage;
        texti.text = "Líf " + health.ToString();
        //ef það er minna en 0 þá tapar leikmaðurinn
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
            health = 30;
            Kassi.count = 0;//núll stilli stigin 
            texti.text = "Líf " + health.ToString();
        }

    }
    

}
