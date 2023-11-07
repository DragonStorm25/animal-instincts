using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    public SpringJoint web;

    // Start is called before the first frame update
    void Awake()
    {
        web = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
