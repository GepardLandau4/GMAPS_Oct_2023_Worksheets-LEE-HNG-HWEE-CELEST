using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
	//Declare linefactory as it will be needed when drawing a line later
	public LineFactory lineFactory;
	//Declare the ball object that will store the cue ball as its position will be needed to find the start position of the line and to
	//get its script
	public GameObject ballObject;

	//Declare the line that will be drawn between the ball and the mouse
	private Line drawnLine;
	//Declare the ball script of the cue ball as it will be needed to call a function and change its velocity
	private Ball2D ball;

	private void Start()
	{
		//Get the ball script from the ball object that was declared earlier
		ball = ballObject.GetComponent<Ball2D>();
	}

	void Update()
	{
		//If the left mouse button is pressed
		if (Input.GetMouseButtonDown(0))
		{
			//Store the position of the mouse. Camera.main.ScreenToWorldPoint is needed to be used on Input.mousePosition as 
			//Input.mousePosition returns the position based on the screen space, and using the Camera.main.ScreenToWorldPoint function 
			//changes the vector into one that is based on the world space
			var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing

			//Check if the ball script exists and if the mouse is inside or colliding with the ball
			if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
			{
				//Draw and enable a line between the ball and the mouse position with lineFactory
				drawnLine = lineFactory.GetLine(ballObject.transform.position, startLinePos, 1f, Color.black);
				drawnLine.EnableDrawing(true);
			}
		}

		//If the left mouse button is released and the line between the ball and the mouse position is not null (drawnLine is not empty)
		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		{
			//Disable the line drawing between the ball and the mouse position so that the line disappears when the left mouse button is
			//released
			drawnLine.EnableDrawing(false);

			//Update the velocity of the white ball by setting its velocity vector to the vector from the mouse position when the mouse 
			//was released to the ball's transform so that the ball will move in the same direction as the direction from the mouse
			//position to the ball and have its velocity be the magnitude of that vector
			HVector2D v = new HVector2D(ballObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
			ball.Velocity = v;

			//Stop the line drawing by setting the drawnLine to null
			drawnLine = null; // End line drawing            
		}

		//If the line between the ball and the mouse position is not null (drawnLine is not empty)
		if (drawnLine != null)
		{
			//Update the end point of the line by setting its position to that of the mouse's current position based on the world space,
			//so that the end point of the line will follow the mouse position when the mouse moves as long as the left mouse button is
			//held down
			drawnLine.end = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x , Camera.main.ScreenToWorldPoint(Input.mousePosition).y); // Update line end
		}
	}

	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
	public void Clear()
	{
		//Disables all of the lines that are currently active
		var activeLines = lineFactory.GetActive();

		foreach (var line in activeLines)
		{
			line.gameObject.SetActive(false);
		}
	}
}
