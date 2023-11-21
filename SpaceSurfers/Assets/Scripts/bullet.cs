using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 0.4f;
    private float distance;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed;
        distance += Time.deltaTime * speed;
        if (distance > 2.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Rock")
        {
            other.gameObject.GetComponent<Fracture>().FractureObject();
            Destroy(gameObject);
        }
        
    }
}
