using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnvScript : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] GameObject enemyShooterPrefab;
    [SerializeField] List<GameObject> enemyShooterInstantiationPoints = new List<GameObject>();
    Transform spawnPoint;

    /*Obstacles:
     - half wall
     - full wall that you need to shoot to break. Shoot only at the special spot. bullseye/aim animation?
     - tunnel walls (l shaped) that you need to go under
     */

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

        int randomNumber = Random.Range(0, 7);
        int randomNumberTwo = Random.Range(0, 7);
        if(randomNumber == randomNumberTwo)
        {
            SpawnObtacles();
        }

        int randomNumber1 = Random.Range(0, 5);
        int randomNumber2 = Random.Range(0, 5);
        if (randomNumber1 == randomNumber2)
        {
            SpawnEnemyShooter();
        }

        
    }

    private void SpawnEnemyShooter()
    {
        //pick instantation point, and appropriate shooter
        int randomNum = Random.Range(0, enemyShooterInstantiationPoints.Count);
        if(randomNum == 0)
        {
            GameObject enemyShooterInstance = Instantiate(enemyShooterPrefab, enemyShooterInstantiationPoints[randomNum].transform.position, Quaternion.identity) as GameObject;
        }
        else if (randomNum == 1)
        {
            GameObject enemyShooterInstance = Instantiate(enemyShooterPrefab, enemyShooterInstantiationPoints[randomNum].transform.position, Quaternion.Euler(0,0,180f)) as GameObject;
        }
        else if (randomNum == 2)
        {
            GameObject enemyShooterInstance = Instantiate(enemyShooterPrefab, enemyShooterInstantiationPoints[randomNum].transform.position, Quaternion.Euler(0, 0, 90f)) as GameObject;
        }
        else if (randomNum == 3)
        {
            GameObject enemyShooterInstance = Instantiate(enemyShooterPrefab, enemyShooterInstantiationPoints[randomNum].transform.position, Quaternion.Euler(0, 0, 90f)) as GameObject;
        }
        else if (randomNum == 4)
        {
            GameObject enemyShooterInstance = Instantiate(enemyShooterPrefab, enemyShooterInstantiationPoints[randomNum].transform.position, Quaternion.Euler(0, 0, 90f)) as GameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            groundSpawner.SpawnBasicEnvUnit();
            Destroy(this.gameObject, 2f);
        }
    }

    void SpawnObtacles()
    {
        //select random instantiation point
        //int obstacleSpawnIndex = Random.Range(0, 5);
        int obstacleSpawnIndex = 0;

        if(obstacleSpawnIndex == 1)
        {
            spawnPoint = this.transform.GetChild(7).transform;
            Instantiate(obstacles[0], spawnPoint.position, Quaternion.identity, transform);
        }
        else if(obstacleSpawnIndex == 2)
        {
            spawnPoint = this.transform.GetChild(8).transform;
            Instantiate(obstacles[0], spawnPoint.position, Quaternion.identity, transform);
        }
        else if(obstacleSpawnIndex == 0)
        {
            spawnPoint = this.transform.GetChild(10).transform;
            Instantiate(obstacles[1], spawnPoint.position, Quaternion.identity, transform);
        }
        
        if (obstacleSpawnIndex == 3)
        {
            spawnPoint = this.transform.GetChild(9).transform;
            Instantiate(obstacles[2], spawnPoint.position, Quaternion.identity, transform);
        }
        if (obstacleSpawnIndex == 4)
        {
            spawnPoint = this.transform.GetChild(9).transform;
            Instantiate(obstacles[2], spawnPoint.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f), transform);
        }
    }
}
