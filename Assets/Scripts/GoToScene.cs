using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneName = "New scene name here";

    public bool isAutomatic;
    private bool manualEnter;

    private void Update()
    {
        //Manual teleport: Have to press "Enter" to travel to the other teleport point.
        if(!isAutomatic && !manualEnter)
        {
            manualEnter = Input.GetButtonDown("Fire1");
        }
    }

    //Automatic teleport
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if(isAutomatic)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    //Manual teleport
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(!isAutomatic && manualEnter)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
