using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaHp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
       
        // check that the object collided is player
        if (other.gameObject.name == "PlayerObj")
        {
            //gain pts
            other.transform.parent.gameObject.GetComponent<spaceship>().maxHp += 2;
            other.transform.parent.gameObject.GetComponent<spaceship>().hp += 2;
            //destroy obj
            Destroy(gameObject);
            
        }
    }
}
