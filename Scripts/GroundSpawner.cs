using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject basicEnvUnit;
    Vector3 nextSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 30; i++)
        {
            SpawnBasicEnvUnit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBasicEnvUnit()
    {
        GameObject tempEnvUnit = Instantiate(basicEnvUnit, nextSpawnPoint, Quaternion.identity) as GameObject;
        nextSpawnPoint = tempEnvUnit.transform.GetChild(3).transform.position;
    }
}
