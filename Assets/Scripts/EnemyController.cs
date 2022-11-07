using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 directionToMove;

    private Rigidbody2D _rigidbody;
    private bool isMoving;

    [Tooltip("Time the enemy takes between successive steps")]
    [SerializeField] private float timeBetweenSteps;
    //Time since the last step taken by the enemy
    private float timeBetweenStepsCounter;

    [Tooltip("Time it takes for the enemy to take a step")]
    [SerializeField] private float timeToMakeStep;
    //Time the enemy has been taking a step
    private float timeToMakeStepCounter;

    [Tooltip("If enemy movement is not random, ememyDirections needs to have at least two elements")]
    [SerializeField] private bool hasRandomMove;
    [Tooltip("Directions the enemy will follow to complete a path. The idea is that it should be cyclical.Components must be - 1, 0 or 1")]
    [SerializeField] private Vector2[] enemyDirections;
    private int indexDirection;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        timeBetweenStepsCounter = timeBetweenSteps * (hasRandomMove ? Random.Range (0.5f, 1.5f) : 1);
        timeToMakeStepCounter = timeToMakeStep * (hasRandomMove ? Random.Range(0.5f, 1.5f) : 1);

        indexDirection = 0;
        directionToMove = hasRandomMove ? new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) : enemyDirections[indexDirection];
    }

    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _rigidbody.velocity = speed * directionToMove;
            if(timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                _rigidbody.velocity = Vector2.zero;
            }
        }
        else //No movement
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if(timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;

                //It has random movement
                if (hasRandomMove)
                {
                    directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
                }
            }
            else
            {
                indexDirection++;
                if(indexDirection >= enemyDirections.Length)
                {
                    indexDirection = 0;
                }
                directionToMove = enemyDirections[indexDirection];
            }
        }

    }
}
