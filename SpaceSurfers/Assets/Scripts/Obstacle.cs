using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    spaceship PlayerMovement;
    Fracture facture;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = GameObject.FindObjectOfType<spaceship>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //take damage or die
            facture.FractureObject();
            //PlayerMovement.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
