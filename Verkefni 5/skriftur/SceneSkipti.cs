using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSkipti : MonoBehaviour
{
    //ef notandi snertir hlutinn fer í aðra senu
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            SceneManager.LoadScene(2);
        }
    }
    //takki til að byrja, setur á senu 1
    public void Byrja()
    {
        // til þess að stig byrja upp á nýtt
        PlayerController.count = 5;
        SceneManager.LoadScene(1);
    }
}
