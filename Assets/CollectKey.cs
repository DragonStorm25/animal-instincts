using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectKey : MonoBehaviour
{
    private int nkeys = 0;
    //[SerializeField] private Canvas textCanvas;
  //  TextMeshPro keysText; 
    // Start is called before the first frame update
    void Start()
    {
     /*  if(textCanvas != null)
        {
            keysText = textCanvas.transform.Find("Text").GetComponent<TextMeshPro>();
            if(keysText == null)
            {
                Debug.Log("No text found");
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //collide with a player + hasn't been picked up
        if (other.tag == "Key")
        {
            nkeys += 1; //collect the key
            Destroy(other.gameObject);
            //keysText.text = "Keys: " + nkeys; 
           
        }
        
    }
}