using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public const string HORIZONTAL = "Horizontal", VERTICAL = "Vertical";
    private float inputTol = 0.2f; //Input tolerance
    private float xInput, yInput;

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw(HORIZONTAL);

        if(Mathf.Abs(xInput) > inputTol)
        {
            Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            transform.Translate(translation);
        }

        yInput = Input.GetAxisRaw(VERTICAL);

        if (Mathf.Abs(yInput) > inputTol)
        {
            Vector3 translation = new Vector3(0, yInput * speed * Time.deltaTime, 0);
            transform.Translate(translation);
        }
    }
}
