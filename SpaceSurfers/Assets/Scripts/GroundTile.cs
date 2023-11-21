
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

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerObj" || other.gameObject.name == "Player")
        {
            groundSpawner.SpawnTile(true);
            Destroy(gameObject, 2); // will destroy the object 2 second after passing the trigger 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    public void SpawnObstacle()
    {
        // choose a random point 
        int obstacleSpawnIndex = Random.Range(2, 7); //nb between 2 and 6 
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        
        
        // spawn the obstacle
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject collectablePrefab;

    public void SpawnCollectables()
    {
        int nbToSpawn = 10;
        for (int i = 0; i < nbToSpawn; i++)
        {
            GameObject temp = Instantiate(collectablePrefab, transform); // transform attaches it to parent and destroys with it 
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x , collider.bounds.max.x),
            Random.Range(1, 15),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point))
        { // just in case you mess up
            point = GetRandomPointInCollider(collider);
        }

        return point;

    }
}
