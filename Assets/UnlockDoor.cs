using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private int keyRequired;
    [SerializeField] private string nextStage; 
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyRequired <= 0)
        {
            //Open the door when the number of keys is met
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            count += 1;
        }
        if (keyRequired <= 0 && count == 2)
        {
            //Open the door when the number of keys is met
            SceneManager.LoadScene(nextStage);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            count -= 1;
        }
        //player leaves the door area
    }
    public void unlock(int nkeys)
    {
        keyRequired -= nkeys;
    }
}
