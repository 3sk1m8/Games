using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increase the score in the GameManager
            GameManager.instance.IncreaseScore();
            //Destroy the collectible
            Destroy(gameObject);
        }
    }
    
}
