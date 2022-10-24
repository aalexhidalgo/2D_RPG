using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public const string HORIZONTAL = "Horizontal", VERTICAL = "Vertical";

    private float inputTol = 0.2f; //Input tolerance
    private float xInput, yInput;

    public static bool playerCreated;

    private bool isWalking;

    public Vector2 lastDirection;
    public string nextUuid;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;

    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerCreated = true;
    }

    void Update()
    {
        xInput = Input.GetAxisRaw(HORIZONTAL);
        isWalking = false;

        //Horizontal Movement

        if (Mathf.Abs(xInput) > inputTol)
        {
            /*Another valid logic
            Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            transform.Translate(translation);*/
            playerRigidbody.velocity = new Vector2(xInput * speed, 0);
            isWalking = true;
            lastDirection = new Vector2(xInput, 0);
        }

        yInput = Input.GetAxisRaw(VERTICAL);

        if (Mathf.Abs(yInput) > inputTol)
        {
            /*Another valid logic
            Vector3 translation = new Vector3(0, yInput * speed * Time.deltaTime, 0);
            transform.Translate(translation);*/
            playerRigidbody.velocity = new Vector2(0, yInput * speed);
            isWalking = true;
            lastDirection = new Vector2(0, yInput);
        }
    }

    private void LateUpdate()
    {
        //Animations set by the different states and actions

        playerAnimator.SetFloat(HORIZONTAL, xInput);
        playerAnimator.SetFloat(VERTICAL, yInput);
        playerAnimator.SetFloat("LastHorizontal", lastDirection.x);
        playerAnimator.SetFloat("LastVertical", lastDirection.y);
        playerAnimator.SetBool("IsWalking", isWalking);

        //No movement

        if(!isWalking)
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
