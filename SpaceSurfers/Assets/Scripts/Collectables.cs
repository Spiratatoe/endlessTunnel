using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    //private float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hey there");
        // check that the object collided is player
        if (other.gameObject.name != "PlayerObj")
        {
            Debug.Log("does it do this");
            return;
        }
        // add to the players score 
        
        //destroy orb
        Destroy(gameObject); // when lower case it means it is this object 
        Debug.Log("end");
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
