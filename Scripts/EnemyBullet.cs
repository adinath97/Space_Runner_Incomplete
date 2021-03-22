using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float moveSpeed = 4f;

    private void Start()
    {
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
        //transform.position += -Vector3.forward * Time.deltaTime * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -Vector3.forward * Time.deltaTime * moveSpeed;
    }
}
