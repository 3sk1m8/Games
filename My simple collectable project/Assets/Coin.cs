using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindAnyObjectByType<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
       {
        gameController.IncreaseScore(1); //Use IncreaseScore instead of AddScore
        Destroy(gameObject);
       }
    }


}
