using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
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
            other.transform.parent.gameObject.GetComponent<spaceship>().hp = other.transform.parent.gameObject.GetComponent<spaceship>().maxHp;
            //destroy obj
            Destroy(gameObject);
            
        }
    }
}
