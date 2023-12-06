using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        return (Mathf.Sqrt(Mathf.Pow(p1.x - p2.x, 2f) + Mathf.Pow(p1.y - p2.y, 2f)));
    }
}

