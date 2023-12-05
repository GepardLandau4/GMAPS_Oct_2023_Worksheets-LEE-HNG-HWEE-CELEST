using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
  
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                entries[x, y] = multiArray[y,x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
    {
	    // First row
        entries[0,0] = m00;
        entries[0,1] = m01;
        entries[0,2] = m02;

        // Second row
        entries[1,0] = m10;
        entries[1,1] = m11;
        entries[1,2] = m12;

        // Third row
        entries[2,0] = m20;
        entries[2,1] = m21;
        entries[2,2] = m22;
    }

    
    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D addMat = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                addMat.entries[x, y] = left.entries[x, y] + right.entries[x, y];
            }
        }
        return addMat;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D subMat = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                subMat.entries[x, y] = left.entries[x, y] - right.entries[x, y];
            }
        }
        return subMat;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D mulMat = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                mulMat.entries[x, y] = left.entries[x, y] * scalar;
            }
        }
        return mulMat;
    }

    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        HVector2D mulVec = new HVector2D();

        mulVec.x = left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h;
        mulVec.y = left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h;
        mulVec.h = left.entries[2, 0] * right.x + left.entries[2, 1] * right.y + left.entries[2, 2] * right.h;
        
        return mulVec;
    }
    
    //This function returns the product of two matrices by 
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        //create a new HMatrix2D to store the result of the matrix multiplication
        HMatrix2D mulMat2 = new HMatrix2D();

        //this will loop through the next lines of code three times, with y representing the column number of the new matrix/column 
        //number of the right matrix
        for (int y = 0; y < 3; y++)
        {
            //this will loop through the next lines of code three times, with x representing the row number of the new matrix/row number
            //of the left matrix
            for (int x = 0; x < 3; x++)
            {
                //this will loop throuh the next lines of code 3 times, with i representing the column number of the left matrix/row
                //number of the right matrix. This needs to be done as each value in the new matrix requires 3 different values to be 
                //calculated by multiplying a value from each of the matrices and added together
                for (int i = 0; i < 3; i++)
                {
                    //add the product of row x column i of the left matrix and row i column y of the right matrix to row x column y of
                    //the new matrix. 
                    mulMat2.entries[x,y] += left.entries[x,i] * right.entries[i,y];
                }
            }
        }
        
        //return the result of the matrix multiplication
        return mulMat2;
 
    } 
    
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.entries[y,x] != right.entries[y,x])
                {
                    return false;
                }
            }
        }
        return true;
    }
    

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.entries[y,x] != right.entries[y,x])
                {
                    return true;
                }
            }
        }
        return false;
    }

    /*

    public override bool Equals(object obj)
    {
        // your code here
    }

    public override int GetHashCode()
    {
        // your code here
    }

    public HMatrix2D transpose()
    {
        return // your code here
    }

    public float getDeterminant()
    {
        return // your code here
    }
    */

    public void setIdentity()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                /*
                if (x == y)
                {
                    entries[y,x] = 1;
                }
                else
                {
                    entries[y,x] = 0;
                }
                */
                entries[y,x] = (x == y) ? 1 : 0;
            }
        }
        
    }

    public void setTranslationMat(float transX, float transY)
    {
        setIdentity();
        entries[0,2] = transX;
        entries[1,2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {
        setIdentity();
        float rad = rotDeg * (Mathf.PI / 180);
        entries[0,0] = Mathf.Cos(rad);
        entries[0,1] = -Mathf.Sin(rad);
        entries[1,0] = Mathf.Sin(rad);
        entries[1,1] = Mathf.Cos(rad);
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        setIdentity();
        entries[0,0] = scaleX;
        entries[1,1] = scaleY;
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}