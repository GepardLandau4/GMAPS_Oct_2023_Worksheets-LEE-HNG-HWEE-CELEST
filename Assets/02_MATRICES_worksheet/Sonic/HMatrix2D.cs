using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    //Create a two dimensional array that contains 3 arrays of 3 floats to represent a 3 x 3 matrix
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
  
    }

    //Convert a two dimensional array into a HMatrix2D, where each array in the 2D array represents a column of the new matrix (?)
    public HMatrix2D(float[,] multiArray)
    {
        //y reperesents the number of columns in the matrix. Loop for each column in the matrix
        for (int y = 0; y < 3; y++)
        {
            //x reperesents the number of rows in the matrix. Loop for each row in the matrix
            for (int x = 0; x < 3; x++)
            {
                //Set the value of row x, column y in entries to the xth float in the yth array of multiArray
                entries[x, y] = multiArray[y,x];
            }
        }
    }

    //Convert 9 floats into a HMatrix2D
    public HMatrix2D(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
    {
        //Each value is manually set

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

    //This operator handles the addition of two HMatrix2Ds by calculating the result of the addition of each corresponding element of 
    //the left and right matrices
    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        //Declare a HMatrix2D called addMat that stores result of the additon of the HMatrix2Ds left and right
        HMatrix2D addMat = new HMatrix2D();
        //For each column (y) in the new matrix
        for (int y = 0; y < 3; y++)
        {
            //For each row (x) in the new matrix
            for (int x = 0; x < 3; x++)
            {
                //Set the xth row and yth column value of addMat to be the result of the addition of the xth row and yth column values 
                //the left and right matrices
                //Basically adding the corresponding elements of the left and right matrices and setting corresponding element of the 
                //addMat to the result
                addMat.entries[x, y] = left.entries[x, y] + right.entries[x, y];
            }
        }
        //Return the result in the form of a HMatrix2D
        return addMat;
    }

    //This operator handles the subtraction of two HMatrix2Ds by calculating the result of subtracting the corresponding elements of the 
    //right matrix from the left
    //This works similarly to the addition operator, but with subtraction instead of addition
    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        //Declare a HMatrix2D called subMat that stores result of the subtraction of the right HMatrix2D from the left HMatrix2D
        HMatrix2D subMat = new HMatrix2D();
        //For each column (y) in the new matrix
        for (int y = 0; y < 3; y++)
        {
            //For each row (x) in the new matrix
            for (int x = 0; x < 3; x++)
            {
                //Set the xth row and yth column value of subMat to be the result of the subtraction of the xth row and yth column 
                //value of the right HMatrix2D from that of the left HMatrix2D
                //Basically subtracting the corresponding elements of the right matrix from the left and setting corresponding element 
                //of the subMat to the result
                subMat.entries[x, y] = left.entries[x, y] - right.entries[x, y];
            }
        }
        //Return the result in the form of a HMatrix2D
        return subMat;
    }

    //This operator handles the multiplication of a HMatrix2D and a scalar by multiplying each element of the HMatrix by the scalar
    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        //Declare a HMatrix2D called mulMat that stores result of the multiplication of the HMatrix2D left with a scalar
        HMatrix2D mulMat = new HMatrix2D();
        //For each column (y) in the new matrix
        for (int y = 0; y < 3; y++)
        {
            //For each row (x) in the new matrix
            for (int x = 0; x < 3; x++)
            {
                //Set the xth row and yth column value of mulMat to be the result of the multiplication of the xth row and yth column 
                //value of the left HMatrix2D with the scalar
                //Basically multiplying the element by the scalar and storing the result as the corresponding element of the mulMat to
                //the result
                mulMat.entries[x, y] = left.entries[x, y] * scalar;
            }
        }
        //Return the result in the form of a HMatrix2D
        return mulMat;
    }

    //This operator handles the multiplication of a HMatrix2D and a HVector2D by manually setting the resulting element to be the dot
    //product of each row of the matrix and the vector
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        //Declare a HVector2D called mulVec that stores result of the multiplication of the HMatrix2D left with a HVector2D right
        HVector2D mulVec = new HVector2D();

        //Manually calculating and setting each value of the mulVec by setting each value to the dot product of the corresponding row of
        //the HMatrix2D and the HVector2D
        mulVec.x = left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h;
        mulVec.y = left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h;
        mulVec.h = left.entries[2, 0] * right.x + left.entries[2, 1] * right.y + left.entries[2, 2] * right.h;
        
        //Return the result in the form of a HVector2D
        return mulVec;
    }
    
    //This function returns the product of two matrices by 
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        //Create a new HMatrix2D to store the result of the matrix multiplication
        HMatrix2D mulMat2 = new HMatrix2D();

        //This will loop through the next lines of code three times, with y representing the column number of the new matrix/column 
        //number of the right matrix
        for (int y = 0; y < 3; y++)
        {
            //This will loop through the next lines of code three times, with x representing the row number of the new matrix/row number
            //of the left matrix
            for (int x = 0; x < 3; x++)
            {
                //This will loop throuh the next lines of code 3 times, with i representing the column number of the left matrix/row
                //number of the right matrix. This needs to be done as each value in the new matrix requires 3 different values to be 
                //calculated by multiplying a value from each of the matrices and added together
                for (int i = 0; i < 3; i++)
                {
                    //Add the product of row x column i of the left matrix and row i column y of the right matrix to row x column y of
                    //the new matrix. 
                    mulMat2.entries[x,y] += left.entries[x,i] * right.entries[i,y];
                }
            }
        }
        
        //Return the result of the matrix multiplication
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