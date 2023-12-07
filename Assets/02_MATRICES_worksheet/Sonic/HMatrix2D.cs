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
    
    //This operator returns the product of two matrices by setting each element in the matrix to the dot product of the xth row of the 
    //left matrix and the yth column of the right matrix.
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        //Declare a HVector2D called mulVec that stores result of the multiplication of the two HMatrix2Ds 
        HMatrix2D mulMat2 = new HMatrix2D();

        //This will loop through the next lines of code for each column in the resulting matrix, with y representing the column number 
        //of the new matrix/column number of the right matrix
        for (int y = 0; y < 3; y++)
        {
            //This will loop through the next lines of code for each row in the resulting matrix, with x representing the row number 
            //of the new matrix/row number of the left matrix
            for (int x = 0; x < 3; x++)
            {
                //This will set the xth row and the yth column of mulMat2 to the dot product of the corresponding row of left and
                //columns of right by adding each multiplication of the corresponding elements to the xth row and the yth column of 
                //mulMat2, with i representing the ith element of left's row x and the ith element of right's column y
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
    
    //This operator is used to check if the left and right matrices are equal (same corresponding elements) and will return true if so
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        //For each column (y) in the matrices
        for (int y = 0; y < 3; y++)
        {
            //For each row (x) in the matrices
            for (int x = 0; x < 3; x++)
            {
                //If any of the elements of the same row and column from the left and right matrices are not equal, stop the loops and
                //immediately return false to indicate that the matrices are not equal
                if (left.entries[x,y] != right.entries[x,y])
                {
                    return false;
                }
            }
        }
        //If all the loops have been gone through without getting interrupted, it means that none of the corresponding elements in the
        //two matrices are not equal, thus all the elements in the two matrices are equal, which means the matrices are equal, thus
        //true will be returned to indicate the matrices are equal
        return true;
    }
    
    //This operator is used to check if the left and right matrices are not equal (at least one different corresponding element) and 
    //will return true if so
    //This operator works similarly to the == operator, but with the true and false swapped
    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        //For each column (y) in the matrices
        for (int y = 0; y < 3; y++)
        {
            //For each row (x) in the matrices
            for (int x = 0; x < 3; x++)
            {
                //If any of the elements of the same row and column from the left and right matrices are not equal, stop the loops and
                //immediately return true to indicate that the matrices are not equal
                if (left.entries[x,y] != right.entries[x,y])
                {
                    return true;
                }
            }
        }
        //If all the loops have been gone through without getting interrupted, it means that none of the corresponding elements in the
        //two matrices are not equal, thus all the elements in the two matrices are equal, which means the matrices are equal, thus
        //flase will be returned to indicate the matrices are equal
        return false;
    }


    //Honestly, i do not know but those functions are for
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

    //This function turn turns the HMatrix2D into an identity HMatrix2D by looping through each element in the HMatrix2D and setting the
    //values to 0 and 1 if the row number is equal to the column number as identity matrices are matrices where the elements on the main
    //diagonal are equal to 1 (row number = column number) while the rest of the elements are equal to 0
    public void setIdentity()
    {
        //For each column (y) in the matrix
        for (int y = 0; y < 3; y++)
        {
            //For each row (x) in the matrix
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
                //If x == y returns true (the row number equals the column number), set the element in row x and column y to 1, however 
                //if it returns false (the row number does not equal the column number), set the element in row x and column y to 0
                entries[x,y] = (x == y) ? 1 : 0;
            }
        }
        
    }

    //This function takes in the x and y translation values to turn a HMatrix2D into a translation matrix
    public void setTranslationMat(float transX, float transY)
    {
        //Set the HMatrix2D to an identity matrix (i assume its to reset the matrix?)
        setIdentity();
        //Set the third element in rows 1 and 2 to the appropriate translation values
        entries[0,2] = transX;
        entries[1,2] = transY;
    }

    //This function takes in the angle of rotation (in degrees) to turn a HMatrix2D into a rotation matrix
    public void setRotationMat(float rotDeg)
    {
        //Set the HMatrix2D to an identity matrix (i assume its to reset the matrix?)
        setIdentity();
        //Convert the rotDeg (which is in degrees) into radians by multiplying it by pi/180 and storing it in rad. This has to be done
        //Mathf.Cos and Mathf.Sin requires the angle to be in radians in order to calculate the values
        float rad = rotDeg * (Mathf.PI / 180);
        //Set the elements that are in both the first 2 rows and columns to the appropriate rotation values as 
        //new x position = old x * cos(angle of rotation) - old y * sin(angle of rotation) and
        //new y position = old x * sin(angle of rotation) + old y * cos(angle of rotation)
        entries[0,0] = Mathf.Cos(rad);
        entries[0,1] = -Mathf.Sin(rad);
        entries[1,0] = Mathf.Sin(rad);
        entries[1,1] = Mathf.Cos(rad);
    }

    //This function takes in the x and y scale values to turn a HMatrix2D into a scaling matrix
    public void setScalingMat(float scaleX, float scaleY)
    {
        //Set the HMatrix2D to an identity matrix (i assume its to reset the matrix?)
        setIdentity();

        //Set the first element in the first row and the second element in the second row to the appropriate scaling values
        entries[0,0] = scaleX;
        entries[1,1] = scaleY;
    }

    //This function prints the matrix with Debug.Log so that it can be easily viewed in the console
    public void Print()
    {
        //Declare the print result as a string
        string result = "";

        //For each row (r) in the matrix, print out a while row
        for (int r = 0; r < 3; r++)
        {
            //For each column (c) in the matrix, print out each value in the row
            for (int c = 0; c < 3; c++)
            {
                //Add the value from the rth row and the cth column to the result, then add a space so that each value will be separated
                //and be easier to view
                result += entries[r, c] + "  ";
            }
            //After printing out a whole row, make sure the next row will be printed out on a new line so that it is easier to view
            result += "\n";
        }
        //Display the result string in the console
        Debug.Log(result);
    }
}