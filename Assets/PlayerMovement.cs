using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxColl;
    private WebController2D web;
    public bool isSpider;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // Start is called before the first frame update
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (isSpider)
        {
            web = GetComponent<WebController2D>();
        }
   
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpider || !web.isConnected())
        {
            float dirX;
            float jump;
            if (isSpider)
            {
                dirX = Input.GetAxisRaw("Horizontal");
                jump = Input.GetAxisRaw("Jump");
            }
            else
            {
                dirX = Input.GetAxisRaw("Horizontal2");
                jump = Input.GetAxisRaw("Jump2");
            }

            float appliedJumpForce = jump > 0 && IsGrounded() ? jumpForce : 0;
            rb.AddForce(new Vector2(dirX * moveSpeed, appliedJumpForce));
        }
    }

    private bool IsGrounded()
    {
        return rb.velocity.y == 0;
    }
}
