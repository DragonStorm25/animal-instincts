using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    public SpringJoint web;
    public float stringStrength;
    public float stringDrag;
    public float curDistance;
    public Color lineColor;
    private GameObject webAnchor;
    private LineRenderer webVisual;
    private bool isWebConnected;
    private MoveDirection webMovement;

    // Start is called before the first frame update
    void Awake()
    {
        web = GetComponent<SpringJoint>();
        webAnchor = new GameObject("Web Anchor");
        webAnchor.AddComponent<Rigidbody>();
        webAnchor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        webAnchor.AddComponent<LineRenderer>();
        web.spring = 0;
        webVisual = webAnchor.GetComponent<LineRenderer>();
        webVisual.SetColors(lineColor, lineColor);
        webVisual.SetWidth(0.1f, 0.1f);
        isWebConnected = false;
        webMovement = MoveDirection.NoMovement;
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
                web.damper = stringDrag;
                isWebConnected = true;
            }
            else
            {
                web.spring = 0;
                web.damper = 0;
                isWebConnected = false;
            }
        }
        web.minDistance = curDistance;
        webVisual.SetPosition(0, transform.position);
        webVisual.SetPosition(1, webAnchor.transform.position);
        webVisual.forceRenderingOff = !isWebConnected;
    }

    enum MoveDirection {
        Up,
        Down,
        NoMovement
    }
}
