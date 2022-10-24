using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneName = "New scene name here";

    public string uuid;

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
        Teleport(other.name);
    }

    //Manual teleport
    private void OnTriggerStay2D(Collider2D other)
    {
        Teleport(other.name);
    }

    private void Teleport(string objName)
    {
        if(objName == "Player")
        {
            if (isAutomatic || (!isAutomatic && manualEnter))
            {
                FindObjectOfType<PlayerController>().nextUuid = uuid;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
