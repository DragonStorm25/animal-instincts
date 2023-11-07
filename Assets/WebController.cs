using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    public SpringJoint web;
    private bool webToggle = false;
    private GameObject webAnchor;

    // Start is called before the first frame update
    void Awake()
    {
        web = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            {
                webToggle = !webToggle;
                Vector3 mousePos = Input.mousePosition;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                worldPosition.z = 0;
                Debug.Log(worldPosition);

                if (webToggle)
                {
                    webAnchor = new GameObject();
                    webAnchor.transform.position = worldPosition;
                    webAnchor.AddComponent<Rigidbody>();
                    webAnchor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    web.connectedBody = webAnchor.GetComponent<Rigidbody>();
                    web.spring = 10;
                }
                else
                {
                    web.spring = 0;
                }
            }
    }
}
