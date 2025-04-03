using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //byssu skot object og hversu fljótt það fer
    public GameObject bullet;
    public float speed = 4000f;
    

    void Update()
    {
        //ef það er ýtt á z, þá skýttur byssan
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("skjOtttttttta");

            //gerir nýja byssuskotm gefur henni body, skjóttir hana og eyðir hana
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * speed);
            Destroy(instBullet, 0.5f);//kúl eytt eftir 0.5sek
           
        }
    }
}
