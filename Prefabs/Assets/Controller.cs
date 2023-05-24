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
        transform.Translate(new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
            speed = 1;
        }

        //speed multiplier
        animator.SetFloat("SpeedMult", speed);

    }
}