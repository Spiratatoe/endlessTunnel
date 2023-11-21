
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
    public GameObject obstaclePrefab2;

    public void SpawnObstacle()
    {
        GameObject obstacle = obstaclePrefab; //by default 
        int mystery = Random.Range(1, 3); // 1 to 2 
        switch (mystery)
        {
            case 1:
                obstacle = obstaclePrefab;
                break;
            case 2:
                obstacle = obstaclePrefab2;
                break;
        }

        // choose a random point 
        int obstacleSpawnIndex = Random.Range(2, 7); //nb between 2 and 6 
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        
        // spawn the obstacle
        Instantiate(obstacle, spawnPoint.position, Quaternion.identity, transform);
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
    
    public GameObject scorePrefab;
    public GameObject pointPrefab;
    public GameObject bulletPrefab;
    public GameObject healPrefab;
    public GameObject starPrefab;
    
    public GameObject hpPrefab;
    public GameObject boostPrefab;
    public GameObject multiplierPrefab;
    
    public void SpawnPowers()
    {
        GameObject temp;
        int mystery = Random.Range(1, 9); // 1 to 8 
        switch(mystery) 
        {
            case 1:
                temp = Instantiate(scorePrefab, transform); // transform attaches it to parent and destroys with it 
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                break;
            case 2:
                temp = Instantiate(pointPrefab, transform); // transform attaches it to parent and destroys with it 
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                break;
            case 3:
                temp = Instantiate(bulletPrefab, transform); // transform attaches it to parent and destroys with it 
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                break;
            case 4:
                temp = Instantiate(healPrefab, transform); // transform attaches it to parent and destroys with it 
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                break;
            case 5:
                temp = Instantiate(starPrefab, transform); // transform attaches it to parent and destroys with it 
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                break;
            case 6:
                temp = Instantiate(hpPrefab, transform); // transform attaches it to parent and destroys with it 
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                break;
            case 7:
                temp = Instantiate(boostPrefab, transform); // transform attaches it to parent and destroys with it 
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                break;
            case 8:
                temp = Instantiate(multiplierPrefab, transform); // transform attaches it to parent and destroys with it 
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                break;
            
        }
        
        
    }
}
