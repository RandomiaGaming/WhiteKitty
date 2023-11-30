using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput pi;

    public float MoveForce = 5;
    public float MaxMoveSpeed = 7;
    public float JumpForce = 5;
    public float MaxJumpTime = 0.5f;
    public float DragForce = 1;

    private bool Grounded = false;
    private float JumpTimer = 0;
    private bool Jumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pi = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Grounded = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (SideCollision.Direction(collision).y < -0.5 && collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
        if (SideCollision.Direction(collision).y > 0.5 && collision.gameObject.tag == "Ground")
        {
            JumpTimer = 0;
            Jumping = false;
        }
        if (collision.gameObject.tag == "Hazzard")
        {
            FadeManager.Instance.State = FadeState.FadingIn;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazzard")
        {
            FadeManager.Instance.State = FadeState.FadingIn;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Drag();
        Move();
        Jump();
    }
    void Jump()
    {
        if (Grounded && pi.JumpDown)
        {
            JumpTimer = 0;
            Jumping = true;
        }
        if (JumpTimer >= MaxJumpTime || pi.JumpUp)
        {
            JumpTimer = 0;
            Jumping = false;
        }
        if (Jumping)
        {
            JumpTimer += Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }
    void Move()
    {
        if (pi.MoveAxis != 0)
        {
            transform.localScale = new Vector3(pi.MoveAxis, 1, 1);
        }
        if ((rb.velocity.x < MaxMoveSpeed && pi.MoveAxis == 1) || (rb.velocity.x > -MaxMoveSpeed && pi.MoveAxis == -1))
        {
            rb.velocity += new Vector2(MoveForce * pi.MoveAxis * Time.deltaTime, 0);
        }
    }
    void Drag()
    {
        float Sign = Mathf.Sign(rb.velocity.x);
        rb.velocity -= new Vector2(DragForce * Sign * Time.deltaTime, 0);
        if (Mathf.Sign(rb.velocity.x) != Sign)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
