
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    private Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems, bool robots)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCollectables();
            temp.GetComponent<GroundTile>().SpawnPowers();
            if (robots)
            {
                temp.GetComponent<GroundTile>().SpawnRobot();
            }
            
        }
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i < 1)
            {
                SpawnTile(false, false);
            }
            else
            {
                
                SpawnTile(true, false);
            }
            
        }


    }

    

}
