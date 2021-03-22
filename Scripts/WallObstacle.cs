using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "playerBullet")
        {
            Destroy(collision.gameObject);
            Debug.Log("HIT!");
            Destroy(this.gameObject);
        }
    }
}
