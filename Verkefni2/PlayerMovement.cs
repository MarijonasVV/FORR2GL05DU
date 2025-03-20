using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovment : MonoBehaviour
{
    //upl um leikmann
    public float speed = 0.2f;
    public float sideways = 0.2f;
    public float jump = 0.2f;

    //geymir stig
    public static int count;
    public TextMeshProUGUI countText;


    void FixedUpdate()
    {
        //ef leikmaður dettur tapa þau
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(4);
        }
        //fær inputs og gerir það við leikmannin
        if (Input.GetKey(KeyCode.UpArrow))//áfram
        {
            transform.position += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += -transform.forward * speed;

        }
        if (Input.GetKey(KeyCode.RightArrow))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//vinstri
        {
            transform.position += -transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * jump;
        }
        if (Input.GetKey(KeyCode.Space))//hoppa
        {
            transform.position += transform.up * jump;
        }

        //sný player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        //hér rétti ég playerinn við ef hann dettur
        if (Input.GetKey("q"))// ef ýtt er á q
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

    }
    //ef leikmaðurinn snertir eitthvað
    void OnCollisionEnter(Collision collision)
    {
        // ef player keyrir á object sem heitir hlutur
        if (collision.collider.tag == "hlutur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1;
            // Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "peningur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 5;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "hindrun")
        {
            collision.collider.gameObject.SetActive(false);
            count = count - 3;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
    }
    //stig sem sést á skjáinn, ef það er minna en 0 tapar leikmaðurinn
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();

        if (count <= 0)
        {
            SceneManager.LoadScene(4);
        }

    }

}
