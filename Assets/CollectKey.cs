using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectKey : MonoBehaviour
{
    public TextMeshProUGUI keysText; 
    private int nkeys = 0;
    //[SerializeField] private Canvas textCanvas;
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
            nkeys += 1; //collect the key
            Destroy(other.gameObject);
            keysText.text = "Keys: " + nkeys;
            //keysText.text = "Keys: " + nkeys; 
           
        }
        
        if(other.tag == "Door")
        {
            //use keys 
            other.gameObject.GetComponent<UnlockDoor>().unlock(nkeys);
            //reset keys
            nkeys = 0;
            keysText.text = "Keys: " + nkeys;
        }
    }
}
