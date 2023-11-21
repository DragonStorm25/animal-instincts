using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayLimitedTimeObject : MonoBehaviour
{
    [SerializeField] private float _duration = 10;
    [SerializeField] private GameObject _objectToDisplay;

    // Start is called before the first frame update

    private bool isActive = false;
    private float timeLeft;
    void Start()
    {
        //hide object
        if(_objectToDisplay != null)
        {
            _objectToDisplay.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0)
            {
                isActive = false;
                _objectToDisplay.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player" && !isActive)
        {
            isActive = true;
            timeLeft = _duration;
            _objectToDisplay.SetActive(true);
        }
    }

    public IEnumerator DisplaySequence()
    {
        //display 
        _objectToDisplay.SetActive(true);
        //wait for some amount of time 
        yield return new WaitForSeconds(_duration);
        //disappear 
        _objectToDisplay.SetActive(false);
    }
}