using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");
        if (other.tag == "Player" && other.name == "Spider")
        {
            other.transform.SetParent(transform.parent);

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        if (other.tag == "Player" && other.name == "Spider")
        {
            other.transform.SetParent(null);

        }
    }

}
