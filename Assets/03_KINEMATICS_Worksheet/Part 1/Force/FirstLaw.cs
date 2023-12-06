using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes the ball move according to Newton's First Law
public class FirstLaw : MonoBehaviour
{
    //Declare the force to be applied to the ball and the rigidbody of the ball
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        //Store the rigidbody component of the ball
        rb = GetComponent<Rigidbody>();
        //Add a force (depending of the force vector taken from the values typed in the inspector) and applies it to the rigidbody of 
        //the ball once when the scene starts
        rb.AddForce(force, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        //Show the transform position of the ball on the console so that its position can be taken track of
        Debug.Log(transform.position);
    }
}

