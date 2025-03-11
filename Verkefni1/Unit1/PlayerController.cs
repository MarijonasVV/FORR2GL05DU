using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Breyttur fyrir hraðan á bílin
    private float speed = 25.0f;
    private float turnSpeed =  50.0f;

    //Breyttur til að fá input frá notanda
    private float horizontalInput;
    private float forwardInput;


    void Start()
    {
        
    }
    void Update()
    {

        //fær input fyrir vinstri beygju og hægri
        horizontalInput = Input.GetAxis("Horizontal");

        //fær input sem lætur bílin keyra fram
        forwardInput = Input.GetAxis("Vertical");

        // kóði sem munn láta bílinn keyra
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        
        //snýr bílin eftir input notanda
        transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed);
    }
}
