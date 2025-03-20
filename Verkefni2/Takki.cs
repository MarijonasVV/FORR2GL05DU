using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Takki : MonoBehaviour
{
    //tekur in texta til að setja lokastig í
    public TextMeshProUGUI texti;

    public void Start()
    {
        //Ef það er sena 3 (endir sena), þá sýnir það lokastig
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            texti.text = "Lokastig " + PlayerMovment.count.ToString();
        }

    }
    //Loadar senu 1
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    //loadar senu 2
    public void Endir()
    {
        SceneManager.LoadScene(0);
        PlayerMovment.count = 0;
    }

}
