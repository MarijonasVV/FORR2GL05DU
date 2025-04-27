using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageZone : MonoBehaviour
{
    // Þegar leikmaðurinn snertir hlutinn og heldur áfram að snerta
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        //tapar líf
        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}
