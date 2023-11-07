using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    public SpringJoint web;
    public float stringStrength;
    private GameObject webAnchor;

    // Start is called before the first frame update
    void Awake()
    {
        web = GetComponent<SpringJoint>();
        webAnchor = new GameObject("Web Anchor");
        webAnchor.AddComponent<Rigidbody>();
        webAnchor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        web.spring = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            worldPosition.z = 0;
            RaycastHit hit;
            Physics.Raycast(worldPosition - new Vector3(0, 0, 10), Vector3.forward, out hit);
            if (hit.transform != null && hit.transform.tag == "WebTarget")
            {
                webAnchor.transform.position = worldPosition;
                web.connectedBody = webAnchor.GetComponent<Rigidbody>();
                web.spring = stringStrength;
            }
            else
            {
                web.spring = 0;
            }
        }
    }
}
