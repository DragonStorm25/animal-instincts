using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
        
	private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D rbOther = collision.gameObject.GetComponent<Rigidbody2D>();
 
            if (collision.gameObject != this.gameObject)
            {
                rb.AddForce(rb.velocity + rbOther.velocity * 0.5f);
                Debug.Log("OnCollisionStay2D");
                Debug.Log(rbOther.velocity);
            }
        }
        else return;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }
}
