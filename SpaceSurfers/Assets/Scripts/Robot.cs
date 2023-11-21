using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            //Debug.Log("collided in rock");
            Destroy(gameObject);
            return;
        }
        // check that the object collided is player
        if (other.gameObject.name == "PlayerObj")
        {
            Debug.Log("hmm");
            //gain pts
            other.transform.parent.gameObject.GetComponent<spaceship>().TakeDamage(5);
            Debug.Log("hmmasdasdasdas");
            //destroy obj
            Destroy(gameObject);
            
        }
    }
}
