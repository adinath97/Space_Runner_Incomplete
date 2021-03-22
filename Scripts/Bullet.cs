using UnityEngine;

public class Bullet : MonoBehaviour
{
    float moveSpeed = 30f;

    private void Start()
    {
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
}
