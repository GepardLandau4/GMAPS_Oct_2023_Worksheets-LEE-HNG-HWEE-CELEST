using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    //Declare the height the cube will jump, it is a public variable so that it can be changed in the inspector for the different cubes
    public float Height = 1f;
    //Declare a rigidbody
    Rigidbody rb;

    private void Start()
    {
        //Get the rigidbody component fromn the object and store it in rb
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        //Calculate the final velocity (u) to be applied to the cube with the SUVAT equations shown above. Final velocity equals to the
        //square root of the intial velocity(0 as we assume the cubes are not moving before the jump function is called) minus 
        //2 * (accleration (which is the gravity's y value as accleration is the rate of change of velocity over time, and the gravity 
        //should be changing the velocity of the cube over time i think, y value is used as gravity, in this case, is only affecting the
        //y value as it should ject be pulling the cubes down) * displacement (height as that is how much we want to cubes to be 
        //displaced))
        float u = Mathf.Sqrt(-2f * Physics.gravity.y * Height);
        rb.velocity = new Vector3(0f, u, 0f);
    }

    private void Update()
    {
        //Call the jump function when space is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

