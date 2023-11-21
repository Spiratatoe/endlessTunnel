
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2); // will destroy the object 2 second after passing the trigger 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        // choose a random point 
        int obstacleSpawnIndex = Random.Range(2, 7); //nb between 2 and 6 
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        
        
        // spawn the obstacle
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject collectablePrefab;

    void SpawnCollectables()
    {
        int nbToSpawn = 10;
        for (int i = 0; i < nbToSpawn; i++)
        {
            GameObject temp = Instantiate(collectablePrefab);
            
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(10, 20),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point))
        { // just in case you mess up
            point = GetRandomPointInCollider(collider);
        }

        return point;

    }
}
