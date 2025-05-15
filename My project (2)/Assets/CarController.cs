using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
  private  void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
   private void Update()
    {
       Move();
    }
    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //A/D or Left/Right arrows
        float moveVertical = Input.GetAxis("Vertical"); //W/S or Up/Down arrows
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * moveSpeed;
    }
}
