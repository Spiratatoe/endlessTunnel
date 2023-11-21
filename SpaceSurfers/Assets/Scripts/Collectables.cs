using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    //private float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Debug.Log("collided in rock");
            Destroy(gameObject);
            return;
        }
       
        // check that the object collided is player
        if (other.gameObject.name == "PlayerObj")
        {
            //gain pts
            other.transform.parent.gameObject.GetComponent<spaceship>().gainPoints(0);
            //destroy obj
            Destroy(gameObject);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
