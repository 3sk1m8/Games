using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 _velocity = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;
    private float _camerarotationX = 0f;
    private float currentCamRotX = 0f;
    private Vector3 thrusterforce = Vector3.zero;

    [SerializeField]
    private float camRotLimit = 85f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Gets a movement vector
    public void Move (Vector3 velocity)
    {
        _velocity = velocity;
    }

    //Gets a rotation vector
    public void Rotate (Vector3 rotation)
    {
        _rotation = rotation;
    }

    //Gets a camera rotation vector
    public void RotateCamera (float camerarotationX)
    {
        _camerarotationX = camerarotationX;
    }

    //Gets force vector for thruster
    public void Thrusterforce (Vector3 _thrusterforce)
    {
        thrusterforce = _thrusterforce;
    }

    //Run every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform movement based on velocity variable
    void PerformMovement()
    {
        if (_velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + _velocity * Time.fixedDeltaTime);
        }

        if (thrusterforce != Vector3.zero)
        {
            rb.AddForce (thrusterforce* Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    //Perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (_rotation));
        if (cam != null)
        {
            currentCamRotX -= _camerarotationX;
            currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotLimit, camRotLimit);

            cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        }
    }

}
