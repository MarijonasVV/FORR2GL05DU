using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takki : MonoBehaviour
{
    //til þess að það sé hægt að ýtta á takka
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    //Kveikir á senu 1 (leikinn)
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    
}
