using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public GameObject toDestroy; 
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D obj)    
    {
        if(obj.tag == "Player")
        {
            Destroy(toDestroy);
            audioSource.Play();
        }
        
    }

}
