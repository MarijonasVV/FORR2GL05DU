using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vatn : MonoBehaviour
{
    //Kíkjir ef notandinn snertir vatn
    private void OnTriggerEnter(Collider other)
    {
        //Ef leikamðurinn snertir vatn þá tapa þau
        if (other.tag == "Player")
        {
            Debug.Log("Drukknaði");
            SceneManager.LoadScene(3);

        }
    }
}
//
