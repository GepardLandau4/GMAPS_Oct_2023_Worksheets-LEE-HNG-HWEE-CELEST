using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    //Store the position and velocity if the ball as HVector2Ds
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);
    
    //Store the radius of the ball as a float
    [HideInInspector]
    public float Radius;

    private void Start()
    {
        //Store the transform position of the ball in the Position HVector2D so that the transform's position is stored as a HVector2D
        //so that the functions that require HVector2D can work on it
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        //Get the sprite of the ball and store its size to calculate the radius of the ball so that it can be used to check if the mouse
        //is in the ball
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;

        //Codes to test if the FindDistance function in Util is working
        // HVector2D a = new HVector2D(8f, 5f);
        // HVector2D b = new HVector2D(1f, 3f);
        // float distance = Util.FindDistance(a,b);
        // Debug.Log(distance);
    }

    //Function to check if something at the specified position (x, y) is within the ball's radius (inside the ball)
    public bool IsCollidingWith(float x, float y)
    {
        //use the FindDistance function to find the distance between the ball and the mouse, and if the distance is less than or equal
        //to the radius (inside the ball), return true
        float distance = Util.FindDistance(Position, new HVector2D(x, y));
        return distance <= Radius;
    }

    //I think this checks if the ball has collided with another ball (other)
    // public bool IsCollidingWith(Ball2D other)
    // {
    //     //Calculates distance between the two balls' transforms and returns true if the distance between them is less than or equal
    //     //to the sum of their radii (meaning that the balls have collided)
    //     float distance = Util.FindDistance(Position, other.Position);
    //     return distance <= Radius + other.Radius;
    // }


    public void FixedUpdate()
    {
        //call the UpdateBall2DPhysics in fixed update so that the displacement and position of the ball can be calculated without 
        //getting affected by frame rate
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        //set the x and y values of the displacement of the ball to be equal to the x and y values of its velocity muyltiplied by time
        //as displacement = 0.5 * (initial velocity + final velocity) * time, did not divide velocity and time by 2 as when i tried that,
        //the ball seemed to move slower than the example shown in the worksheet, although i am not sure why dividing by 2 is not needed
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        //add the displacement x and y values to the position variable to store the ball's new position
        Position.x += displacementX;
        Position.y += displacementY;

        //set the transform position of the ball to its new position that has been stored
        transform.position = new Vector2(Position.x, Position.y);
    }
}

