using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float steerSpeed = 180f;

    [SerializeField] float boostSpeed = 35f;
    [SerializeField] float slowSpeed = 5f;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }

    void Update()
    {
        float moveAmount = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate (0, moveAmount, 0);

        float steerAmount = Input.GetAxis ("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate (0, 0, -steerAmount);
    }
}
