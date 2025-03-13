using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //hraði, hversu langt notandi getur farið og breytta fyrir input notanda
    private float horizontalInput;
    private float speed = 10.0f;
    private float xRange = 10.0f;
    private GameObject projectilePrefab;
    void Start()
    {
        
    }

    
    void Update()
    {
        //ef notandinn reynir að fara of langt til vinstri, þá er það ekki leyft
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //ef notandinn reynir að fara of langt hægri, þá er það ekki leyft
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //hvert skipti notandinn ýttir á space, þá er gert mat
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        //Til þess að notandinn getur farið vinstri og hægri
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }
}

