using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 1f;
    Rigidbody2D rb;
    Test1 test;

    public Transform groundcheck;
    public LayerMask groundLayer;
    bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        test = new Test1();
        test.Hello();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed, rb.velocity.y * speed, 0);
        Move();
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);        
    }

    private void Move()
    {
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }


}
