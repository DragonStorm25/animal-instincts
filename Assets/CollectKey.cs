using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectKey : MonoBehaviour
{
    public TextMeshProUGUI keysText; 
    private static int numberOfKeys = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(keysText == null)
        {
            Debug.Log("No text found");
        }
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
            numberOfKeys += 1; //collect the key
            Destroy(other.gameObject);
            keysText.text = "Keys: " + numberOfKeys;           
        }
        
        if(other.tag == "Door")
        {
            //use keys 
            other.gameObject.GetComponent<UnlockDoor>().unlock(numberOfKeys);
            //reset keys
            numberOfKeys = 0;
            keysText.text = "Keys: " + numberOfKeys;
        }
    }
}
