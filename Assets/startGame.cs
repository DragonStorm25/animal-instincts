using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void startTutorial(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         //SceneManager.LoadScene("Tutorial");
    }
}
