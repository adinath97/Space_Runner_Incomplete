using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    bool shotAlready;

    private void Start()
    {
        shotAlready = false;
    }

    // Update is called once per frame
    void Update()
    {
        //try spherecasting
        RaycastHit hitInfo;

        if(Physics.SphereCast(transform.position,100f,-transform.forward,out hitInfo,200f))
        {
            if (hitInfo.collider.tag == "Player" && !shotAlready)
            {
                //Debug.Log("Player found");
                shotAlready = true;
                Shoot();
            }
        }

        /*
        //raycast to detect if player is in range
        var ray = new Ray(this.transform.position, -Vector3.forward);
        Debug.DrawRay(this.transform.position, -transform.forward * 10f, Color.green);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            if(hitInfo.collider.tag == "Player")
            {
                Debug.Log("Player found");
            }
        }
        */
    }

    private void Shoot()
    {
        GameObject enemyBulletInstance = Instantiate(enemyBullet, this.transform.position, Quaternion.identity) as GameObject;
        //Debug.Log(enemyBulletInstance.transform.position);
        //Debug.Log("Instantiated");
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "playerBullet")
        {
            Destroy(this.gameObject);
        }
    }
}
