using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speedTransRate = 0.2f;
    public float speed = 1f;
    public float maxSpeed = 5f;
    [SerializeField] Animator animator;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (speed <= maxSpeed)
        {
            speed += speedTransRate * Time.deltaTime;
        }
        animator.SetFloat("Input", Mathf.Max(Mathf.Abs(horizontalInput), Mathf.Abs(verticalInput)));
        transform.Translate(new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime);

        //animator.SetFloat("SpeedMult", speed);

        if (speed == maxSpeed && Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") == 0)
        {
            speed = 1;
        }
    }
}