using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rollForce = 5f;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Apply a force to make the coin roll
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (other.transform.position - transform.position).normalized;
                rb.isKinematic = false; //Ensure its not kinematic during the roll
                rb.AddForce(direction * rollForce, ForceMode.Impulse);
            }
            //Disable the collider to prevent interaction
            GetComponent<Collider>().enabled = false;
            //Destroy the coin after a brief period to allow the roll effect
           Destroy(gameObject, 2f);
        }
    }
    
}
