using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //Fall sem kíkir ef dýr fær mat
    private void OnTriggerEnter(Collider other)
    {
        //Ef dýr snerti mat þá er það og maturinn eytt
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
