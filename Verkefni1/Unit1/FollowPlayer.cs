using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // til þess að við getum set bílin sem player object
    public GameObject player;

    // breytta fyrir offset myndavélina sem eltir bílin
    private Vector3 offset = new Vector3(0,8, -10);

    void Start()
    {
        
    }


    void LateUpdate()
    {
        // eltir bílin
        transform.position = player.transform.position + offset;
    }
}
