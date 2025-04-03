using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Kassi : MonoBehaviour
{
    //breyttur fyrir kassan
    public static int count=0;
    public GameObject sprenging;
    private TextMeshProUGUI countText;
    void Start()
    {
        //finnur text og setur stig notanda
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        count = 0;
        SetCountText();
    }
    private void Update()
    {
        //eyða kassa ef leikmaðurinn skýttur það
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    //ef það snertir ehv
    private void OnCollisionEnter(Collision collision)
    {
        //ef það er byssukula, þá er bætt við stig og eytt kassan og kveikt á sprengingu
        if (collision.collider.tag == "kula")
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
            Debug.Log("varð fyrir kúlu");
            count = count + 1;//færð stig
            SetCountText();//kallar í aðferðina
            Sprengin();
        }
    }
    //bæta við stig
    void SetCountText()//hér er aðferðin
    {
        countText.text = "Stig: " + count.ToString();
    }
    //sprenginn
    void Sprengin()
    {
        Instantiate(sprenging, transform.position, transform.rotation);
    }
}
