using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WebController2D : MonoBehaviour
{
    public SpringJoint2D web;
    public float currentLength;
    public Color lineColor;
    public Camera camera;
    private GameObject webAnchor;
    private LineRenderer webVisual;
    private bool isWebConnected;
    private float moveDirection;
    [SerializeField] private float maxWebLength = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        web.distance = currentLength;
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
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        webVisual.material = whiteDiffuseMat;
        webVisual.material.color = lineColor;
        isWebConnected = false;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPosition = camera.ScreenToWorldPoint(mousePos);
            worldPosition.z = 0;
            
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            float distance = Vector3.Distance(worldPosition, transform.position);
            Debug.Log("distance spider-click : " + distance);

            if (hit.collider != null && hit.collider.gameObject.tag == "WebTarget" && distance <= maxWebLength)
            {
                webAnchor.transform.position = worldPosition;
                web.connectedBody = webAnchor.GetComponent<Rigidbody2D>();
                web.distance = currentLength;
                isWebConnected = true;
            }
            else
            {
                web.connectedBody = GetComponent<Rigidbody2D>();
                currentLength = 3;
                isWebConnected = false;
            }
        }
        if(isWebConnected) {    
            currentLength += moveDirection * Time.deltaTime;
            currentLength = Mathf.Max(0, currentLength);
        }

        web.distance = currentLength;
        webVisual.SetPosition(0, transform.position);
        webVisual.SetPosition(1, webAnchor.transform.position);
        webVisual.forceRenderingOff = !isWebConnected;
    }
    
    public bool isConnected()
    {
        return isWebConnected;
    }

    private void OnWebCrawl(InputValue movementValue)
    {
        moveDirection = movementValue.Get<float>();
    }
}
