using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private Vector2 facingDirection; 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        player.transform.position = transform.position;
        player.lastDirection = facingDirection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
