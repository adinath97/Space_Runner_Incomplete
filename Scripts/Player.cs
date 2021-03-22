using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float verticalMoveSpeed = 7f;
    [SerializeField] float horizontalMoveSpeed = 10f;
    [SerializeField] float playerBulletSpeed = 25f;
    [SerializeField] float bulletFiringPeriod = .5f;
    Coroutine firingCoroutine;
    float yMin, yMax, xMin, xMax, rotationDegree;
    Vector3 unclampedPosition;
    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        yMin = 5f;
        yMax = 20f;
        xMin = 4f;
        xMax = 58f;
    }
     
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * Time.deltaTime * verticalMoveSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * Time.deltaTime * verticalMoveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * horizontalMoveSpeed;
            transform.rotation = Quaternion.Euler(0f, 0f, -20f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * horizontalMoveSpeed;
            transform.rotation = Quaternion.Euler(0f, 0f, 20f);
        }
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            rotationDegree = 0;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,xMin,xMax), Mathf.Clamp(transform.position.y, yMin, yMax), transform.position.z);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    void Fire()
    {
        GameObject bulletInstance1 = Instantiate(bulletPrefab, this.transform.GetChild(1).transform.position, Quaternion.identity) as GameObject;
        GameObject bulletInstance2 = Instantiate(bulletPrefab, this.transform.GetChild(2).transform.position, Quaternion.identity) as GameObject;
        GameObject bulletInstance3 = Instantiate(bulletPrefab, this.transform.GetChild(3).transform.position, Quaternion.identity) as GameObject;
        GameObject bulletInstance4 = Instantiate(bulletPrefab, this.transform.GetChild(4).transform.position, Quaternion.identity) as GameObject;
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            Fire();
            yield return new WaitForSeconds(bulletFiringPeriod);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "DestroyWall")
        {
            Debug.Log("Game Over!");
        }
    }
}
