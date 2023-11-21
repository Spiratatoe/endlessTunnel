using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBoost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Debug.Log("asdasdasdasdasdascoin???????");
            Destroy(gameObject);
            return;
            
        }
       
        // check that the object collided is player
        if (other.gameObject.name == "PlayerObj")
        {
            //gain pts
            Debug.Log("coin???????");
            other.transform.parent.gameObject.GetComponent<spaceship>().ptsUp = true;
            //destroy obj
            Destroy(gameObject);
            
        }
    }
}
