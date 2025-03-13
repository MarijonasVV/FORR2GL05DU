using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // hversu langt dýr eða matur getur farið áður en það er eytt
    private float topBound = 30f;
    private float lowerBound = -10f;
    void Start()
    {
        
    }

    void Update()
    {
        // ef maturinn er farinn lengri en það má, þá er það eytt
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        // ef dýr fer lengur að það má, þá er Game Over! sett í debug og eytt dýrið
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
