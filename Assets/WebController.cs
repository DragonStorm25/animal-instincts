using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    public SpringJoint web;
    private bool webToggle = false;

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
                mousePos.z = 0;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                Debug.Log(worldPosition);

                if (webToggle)
                {
                    web.anchor = worldPosition;
                    web.spring = 10;
                }
                else
                {
                    web.spring = 0;
                }
            }
    }
}
