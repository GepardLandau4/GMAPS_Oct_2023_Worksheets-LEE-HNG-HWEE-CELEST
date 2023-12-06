using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Does the same thing as the FirstLaw script, but by setting the velocity of the ball manually instead of adding force to the rigidbody,
//rigbody is not required
public class Motion : MonoBehaviour
{
    //Declare a vector that determines the velocity of the ball
    public Vector3 Velocity;

    void FixedUpdate()
    {
        //Store the amount of time that has passed for calculating the displacement of the ball
        float dt = Time.deltaTime;

        //Calculate the x, y, and z displacement of the ball by multiplying the velocity by the amount of time that has passed as 
        //displacement = 0.5 * (initial velocity + final velocity) * time, though i do not understand why we do not need to divide it by
        //2
        float dx = Velocity.x * dt;
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        //Translate the transform of the ball by moving it based on the displacement values calculated earlier so that the ball will 
        //move
        transform.Translate(new Vector3(dx, dy, dz));
    }
}
