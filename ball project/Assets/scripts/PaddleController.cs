using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;

   
    void Update()
    {
      float move = Input.GetAxis("Horizontal") * speed * Time.deltatime;
      transform.position += new Vector3(move, 0, 0);

      //Clamp paddle position
      float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);
      transform.position = new Vector3(ClampedX, transform.position.y, 0);  
    }
}
