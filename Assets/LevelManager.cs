using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    CameraScript cs;
    float verticalDistance, horizontalDistance;
    float spawnTimer = 0;
    public float spawnInterval = 5;
    public GameObject asteroidPrefab;


    void Start()
    {
        cs = Camera.main.GetComponent<CameraScript>();
        
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnInterval)
        {
            Vector3 spawnPosition = getRandomSpawnPosition();
            GameObject asteoride = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            spawnTimer = 0;
        }
    }
    Vector3 getRandomSpawnPosition()
    {
        verticalDistance = 0.55f * cs.gameHeight;
        horizontalDistance = 0.55f * cs.gameWidth;
        int randomSpawnLine = Random.Range(1, 5);
        Vector3 randomSpawnLocation = Vector3.zero;
        switch (randomSpawnLine)
        {
            case 1:
                
                randomSpawnLocation = new Vector3(Random.Range(-horizontalDistance, horizontalDistance),
                                                                0,
                                                                verticalDistance);
                break;
            case 2:
                
                randomSpawnLocation = new Vector3(horizontalDistance,
                                                  0,
                                                  Random.Range(-verticalDistance, verticalDistance));
                break;
            case 3:
                
                randomSpawnLocation = new Vector3(Random.Range(-horizontalDistance, horizontalDistance),
                                                                0,
                                                                -verticalDistance);
                break;
            case 4:
                
                randomSpawnLocation = new Vector3(-horizontalDistance,
                                                  0,
                                                  Random.Range(-verticalDistance, verticalDistance));
                break;
        }
        return randomSpawnLocation;
    }
}