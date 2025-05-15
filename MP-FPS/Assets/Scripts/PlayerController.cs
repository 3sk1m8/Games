using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3;
    [SerializeField]
    private float thrusterforce = 1000f;
    [SerializeField]
    private float FuelBurnSpeed = 1f;
    [SerializeField]
    private float FuelRegenSpeed = 0.3f;
    private float FuelAmt = 1f;

    public float GetFuelAmt()
    {
        return FuelAmt;
    }

    [SerializeField]
    private LayerMask envMask;

    [Header("Spring settings:")]
    [SerializeField]
    private float jointSpring = 20f;
    [SerializeField]
    private float jointMaxForce = 40f;

    private PlayerMotor motor;
    private ConfigurableJoint joint;
    private Animator animator;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();
        animator = GetComponent<Animator>();

        SetJointSettings(jointSpring);
    }

    void Update()
    {
        //Setting traget position for spring
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 100f, envMask))
        {
            joint.targetPosition = new Vector3(0f, -hit.point.y, 0f);
        }else
        {
            joint.targetPosition = new Vector3(0f, 0f, 0f);
        }

        //Calculate movement velocity as a 3D vector
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        //Final movement vector
        Vector3 velocity = (movHorizontal + movVertical) * speed;

        //Animate movement
        animator.SetFloat("ForwardVelocity", zMov);

        //Apply movement
        motor.Move(velocity);

        //Calculate rotation as a 3D vector 
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3 (0f, yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(rotation);

         //Calculate camera rotation as a 3D vector 
        float xRot = Input.GetAxisRaw("Mouse Y");
        float camerarotationX = xRot * lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(camerarotationX);

        //Calculate thruster force from player input
        Vector3 _thrusterforce = Vector3.zero;
        if (Input.GetButton("Jump") && FuelAmt > 0f)
        {
            FuelAmt -= FuelBurnSpeed * Time.deltaTime;

            if(FuelAmt >= 0.01f)
            {
                _thrusterforce = Vector3.up * thrusterforce;
                SetJointSettings(0f);
            }  
        }else
        {
            FuelAmt += FuelRegenSpeed * Time.deltaTime;
            SetJointSettings(jointSpring);
        }

        FuelAmt = Mathf.Clamp(FuelAmt, 0f, 1f);

        motor.Thrusterforce(_thrusterforce);
    }

    private void SetJointSettings(float _jointSpring)
    {
        joint.yDrive = new JointDrive{
            positionSpring = _jointSpring,
            maximumForce = jointMaxForce
            };
    }
}
