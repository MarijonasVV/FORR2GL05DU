using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour
{
    //Snýr hlutinn sem þetta er sett á
    void Update()
    {
        transform.Rotate(new Vector3(0, 80, 0) * Time.deltaTime);
    }
}
