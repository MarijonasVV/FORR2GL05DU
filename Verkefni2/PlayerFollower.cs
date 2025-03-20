using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerFollower : MonoBehaviour
{
    //Það sem myndavél á að elta
    public Transform player;

    //offset
    public Vector3 offset;
    private Space offsetPositionSpace = Space.Self;

    //hvort það á ap horfa á leikmanninn alltaf
    private bool lookAt = true;

    void Update()
    {
        //Breyttir offset eftir hvað það þarf
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = player.TransformPoint(offset);
        }
        else
        {
            transform.position = player.position + offset;

        }

        //Hjálpir að breytta myndavélinn ef leikmaður er að snúa
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }

    }

}
