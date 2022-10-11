using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 playerMovement;
    Vector2 playerLook;
    float xRotation;

    public float speed = 1f;
    public float sensitivity = 1f;
    public float jumpForce = 1f;
    Rigidbody rb;

    public Transform groundcheck;
    public LayerMask groundLayer;

    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Move();
        Look();
    }

    private void FixedUpdate()
    {

    }

    private void Move()
    {
        Vector3 MouseVector = transform.TransformDirection(playerMovement * speed);
        rb.velocity = new Vector3(MouseVector.x, rb.velocity.y, MouseVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.CheckSphere(groundcheck.position, 0.3f, groundLayer)) // is grounded
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

    }

    private void Look()
    {
        xRotation -= playerLook.y * sensitivity;
        transform.Rotate(0f, playerLook.x * sensitivity, 0f);
        if(xRotation < -90)
        {
            xRotation = -90;
        }
        if (xRotation > 90)
        {
            xRotation = 90;
        }
        cameraTransform.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Jump()
    {
        rb.velocity = Vector3.up * jumpForce;
    }
}
