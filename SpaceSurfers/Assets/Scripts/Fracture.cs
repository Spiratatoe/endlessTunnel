using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;

    //public spaceship ship;
    public void FractureObject()
    {
        Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        Destroy(gameObject); //Destroy the object to stop it getting in the way
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("does this happen?????");
            //take damage or die
            FractureObject();
            collision.gameObject.GetComponent<spaceship>().TakeDamage(1);
            //PlayerMovement.Die();
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("does this happen");
            FractureObject();
        }
    }
}
