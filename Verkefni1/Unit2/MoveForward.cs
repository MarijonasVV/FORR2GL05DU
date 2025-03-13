using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //Hversu fljótt matur fer
    private float speed = 20.0f;
    void Start()
    {
        
    }

    void Update()
    {
        //updatar position hjá matinn
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
