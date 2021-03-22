using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*
    // camera will follow this object
    public Transform Target;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;
    private float yMax = 19f;
    private float yMin = 5f;

    private void Start()
    {
        Offset = camTransform.position - Target.position;

    }

    private void Update()
    {
        // update position
        Vector3 targetPosition = Target.position + Offset;
        Vector3 finalTargetPosition = new Vector3(
            targetPosition.x,
            Mathf.Clamp(targetPosition.y, yMin, yMax),
            targetPosition.z);
        camTransform.position = Vector3.SmoothDamp(transform.position, finalTargetPosition, ref velocity, SmoothTime);
        Debug.Log(finalTargetPosition.y);
        // update rotation
        transform.LookAt(Target);
    }
    */
    
    [SerializeField] Transform player;
    private float targetRefinedX, targetRefinedY, targetRefinedZ;
    Vector3 offset, initialPlayerPosition, updatedPlayerPos;
    private float yMax = 19f;
    private float yMin = 5f;

    // Start is called before the first frame update
    void Start()
    {
        initialPlayerPosition = player.position;
        offset = this.transform.position - initialPlayerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //follow player; maintain initial distance
        Vector3 targetPos = player.position + offset;
        transform.position = new Vector3(targetPos.x, targetPos.y, targetPos.z);
    }
}
