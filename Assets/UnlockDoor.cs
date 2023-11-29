using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private int keyRequired; 
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

        if (keyRequired <= 0)
        {
            //Open the door when the number of keys is met
            SceneManager.LoadScene("TestStage2");
        }
    }
    public void unlock(int nkeys)
    {
        keyRequired -= nkeys;
    }
}
