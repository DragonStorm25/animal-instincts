using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController2D : MonoBehaviour
{
    public SpringJoint2D web;
    public float curDistance;
    public Color lineColor;
    private GameObject webAnchor;
    private LineRenderer webVisual;
    private bool isWebConnected;

    // Start is called before the first frame update
    void Awake()
    {
        web = GetComponent<SpringJoint2D>();
        web.distance = curDistance;
        web.connectedBody = GetComponent<Rigidbody2D>();
        webAnchor = new GameObject("Web Anchor");
        webAnchor.AddComponent<Rigidbody2D>();
        webAnchor.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        webAnchor.AddComponent<LineRenderer>();
        webVisual = webAnchor.GetComponent<LineRenderer>();
        webVisual.startColor = lineColor;
        webVisual.endColor = lineColor;
        webVisual.startWidth = 0.1f;
        webVisual.endWidth = 0.1f;
        isWebConnected = false;
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
           // Physics.Raycast(worldPosition, Vector3.up, out hit);
            //  hit = Physics2D.Raycast(mousePos, Vector3.one, 100);
            //Debug.Log(mousePos);
            //Debug.DrawRay(mousePos, mousePos + Vector3.one * 100);
            //Debug.Log("shoot");
            // Debug.Log(hit.transform.name);
     

            if (!isWebConnected)
            {
                webAnchor.transform.position = worldPosition;
                web.connectedBody = webAnchor.GetComponent<Rigidbody2D>();
                web.distance = curDistance;
                isWebConnected = true;
            }
            else
            {
                web.connectedBody = GetComponent<Rigidbody2D>();
                curDistance = 3;
                isWebConnected = false;
            }
        }
        float vertAxis = Input.GetAxis("Vertical");
        curDistance -= vertAxis * Time.deltaTime;
        curDistance = Mathf.Max(0, curDistance);

        web.distance = curDistance;
        webVisual.SetPosition(0, transform.position);
        webVisual.SetPosition(1, webAnchor.transform.position);
        webVisual.forceRenderingOff = !isWebConnected;
    }
    
    public bool isConnected()
    {
        return isWebConnected;
    }
}
