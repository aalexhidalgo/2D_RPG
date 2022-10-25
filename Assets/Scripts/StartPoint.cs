using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartPoint : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private Vector2 facingDirection;
    public string uuid; //uuid = Universal Unique Identifier

    void Start()
    {
        //Transform the position of the player into the position of the start point
        player = FindObjectOfType<PlayerController>();
        if (!player.nextUuid.Equals(uuid)) //(== Equals)
        {
            return;
        }
        player.transform.position = transform.position;
        player.lastDirection = facingDirection; //Transform the direction of the player

        GameObject confiner = GameObject.Find("Camera Confiner");

        if (confiner != null)
        {
            FindObjectOfType<CinemachineConfiner2D>().m_BoundingShape2D = confiner.GetComponent<PolygonCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
