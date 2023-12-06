using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    //A function that returns the distance between two HVector2Ds as a float
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //To find the distance between the two HVector2Ds, the Pythagorean theorem is used, with the hypotenuse being the distance,
        //and two sides x and y value differences between the two vectors. Thus the distance between the two HVector2Ds is calculated 
        //by square rooting the sum of the square of the x value difference and the square of the y value difference
        return (Mathf.Sqrt(Mathf.Pow(p1.x - p2.x, 2f) + Mathf.Pow(p1.y - p2.y, 2f)));
    }
}

