using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxColl;
    private WebController2D web;
    private float movementX;
    private float tryJump;
    private bool isGrounded = false;
    public bool hasWeb;
    private SpriteRenderer sprite;
    [SerializeField] private float moveForce = 7f;
    [SerializeField] private float jumpForce = 14f;

    // Start is called before the first frame update
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (hasWeb)
        {
            web = GetComponent<WebController2D>();
        }
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float appliedJumpForce = tryJump > 0 && CheckGrounded() ? jumpForce : 0;
        if (tryJump > 0) 
        {
            tryJump = 0;
        }
        rb.AddForce(new Vector2(movementX * moveForce, appliedJumpForce));
    }

    private bool CheckGrounded()
    {
        return isGrounded || Mathf.Abs(rb.velocity.y) <= 0.01;
    }

    private void OnMove(InputValue movementValue) 
    {
        movementX = movementValue.Get<float>();
        if (movementX > 0)
        {
            sprite.flipX = false;
        }
        else if (movementX < 0)
        {
            sprite.flipX = true;
        }
    }

    private void OnJump(InputValue jumpValue)
    {
        tryJump = jumpValue.Get<float>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            isGrounded = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            isGrounded = false;

        }
    }
}
