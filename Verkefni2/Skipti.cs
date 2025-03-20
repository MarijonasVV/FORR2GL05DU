using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{

    //Ef það snertir eitthvað, þá munn hlutirnn hætta að virka 
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        StartCoroutine(Bida());
    }
    //leyfir aðra senu að loada
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);
        Endurræsa();
    }
    //Kveikr á næsta senu
    public void Endurræsa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//næsta sena
    }

}
