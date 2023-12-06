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
    public AudioSource getKeySound;
    [SerializeField] private float moveForce = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float maxSpeed = 14f;
    private float mass;

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
        mass = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        float appliedJumpForce = tryJump > 0 && CheckGrounded() ? jumpForce : 0;
        
        if (tryJump > 0) 
        {
            tryJump = 0;
        }
        if (transform.parent == null)
        {
            if(appliedJumpForce > 0 && getKeySound != null){
                getKeySound.Play();
            }
            rb.AddForce(new Vector2(movementX * moveForce, appliedJumpForce));
        }
        else
        {
            if(appliedJumpForce > 0 && getKeySound != null){
             getKeySound.Play();
            }
            //if parented (on top of other), also follow parent 
            List<float> x = transform.parent.GetComponent<PlayerMovement>().getMovementValues();
            float parentMass = transform.parent.GetComponent<PlayerMovement>().getMass();
            float scaledParentForce = (x[0] * x[1])/parentMass*mass;
            rb.AddForce(new Vector2(scaledParentForce + movementX * moveForce, appliedJumpForce));
        }
        capSpeed();
    }
    private void capSpeed(){
        float newSpeedX = Mathf.Min(maxSpeed, rb.velocity.x);
        rb.velocity = new Vector2(newSpeedX, rb.velocity.y);
    }
    public List<float> getMovementValues()
    {
        float appliedJumpForce = tryJump > 0 && CheckGrounded() ? jumpForce : 0;
        List<float>  v = new List<float>();
        v.Add(movementX);
        v.Add(moveForce);
        v.Add(appliedJumpForce);
        return v;

    }
    public float getMass()
    {
        return mass; 

    }
    private bool CheckGrounded()
    {
        return  transform.parent != null|| Mathf.Abs(rb.velocity.y) <= 0.01;
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

    private void OnColliderEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.name == "Spider")
        {
            isGrounded = true;
            other.transform.SetParent(transform);

        }
    }
    private void OnColliderExit2D(Collider2D other)
    {
        if (other.tag == "Player" &&  other.name == "Spider")
        {
            isGrounded = false;
            other.transform.SetParent(null);

        }
    }
}
