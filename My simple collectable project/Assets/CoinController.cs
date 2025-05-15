using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigidbody component attached to this GameObject
      rb = GetComponent<Rigidbody>();

    }
    public void MoveCoin(Vector3 direction)
    {
        //Apply force to the Rigidbody to move the coin
        rb.AddForce(direction, ForceMode.Impulse);
    }

   
}
