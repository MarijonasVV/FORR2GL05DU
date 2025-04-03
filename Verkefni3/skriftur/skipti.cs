using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    //debug 
    void Start()
    {
        Debug.Log("byrja");
    }
    //ef leikmaðurinn snertir kistuna
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        StartCoroutine(Bida());    
    }
    //bíður í smá stund
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);
        Endurræsa();
    }
    //kveikjir á næsta senu
    public void Endurræsa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//næsta sena
    }

}
