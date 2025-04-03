using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Klikk : MonoBehaviour
{
    //til þess að það sé hægt að ýtta á takka
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    //bara takki til að byrja aðal leikinn
    public void Byrja()
    {
  
        SceneManager.LoadScene(1);
    }
}
