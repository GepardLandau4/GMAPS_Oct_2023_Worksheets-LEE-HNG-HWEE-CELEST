// Uncomment this whole file.

using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    //Declare an array to store the position of all the vectices
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    //Decalre multiple HMatrix2Ds to store the transformation matrices
    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();
    HMatrix2D scaleMatrix = new HMatrix2D();

    //Declare a MeshManager to access the MeshManager script component
    private MeshManager meshManager;
    //Declare a HVector2D to store the position of the mesh so that it can be edited for translation and 
    HVector2D pos = new HVector2D();

    void Start()
    {
        //Get the meshmanager component from the object
        meshManager = GetComponent<MeshManager>();
        //Store the position of the mesh in pos
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        //Code to test out the translate, rotate, and scaling functions
        Translate(1f,1f);
        //Rotate(45f);
        Scale(2f,1f);
    }


    //Function that translates the mesh by moving it x units to the right and y units up
    void Translate(float x, float y)
    {
        //Set the transformation matrix to an identity matrix, not really sure why this is needed, my guess is that its to clear the 
        //transformation matrix
        transformMatrix.setIdentity();
        //call the setTranslationMat function to set the transformation matrix into a translation matrix with the values needed to move
        //the mesh x units to the right and y units up
        transformMatrix.setTranslationMat(x, y);

        //Call the transform function to apply the transformation matrix to the mesh's vertices
        Transform();
       
        //Update the position of the mesh as it has changed
        pos = transformMatrix * pos;
    }

    //Function that rotates the mesh by angle degrees anticlockwise
    void Rotate(float angle)
    {
        //Declare these three HMatrix2Ds so that concatenating them will be easier, one for translating the mesh to the origin, 
        //one for translating the mesh back to its original position from the origin, and one for rotating the mesh. The mesh needs to 
        //translated to and from the origin as directly applying the rotation matrix to the mesh will rotate it around the origin, 
        //changing its position.
        //Although honestly, do not why why we have to declare these matrices again sinee they were declared earlier...
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        //Set the matrices to translate the mesh to and from the origin by translating the mesh based on its position
        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        //Call the setRotationMat function to set the rotateMatrix into a the rotation matrix with the values needed to rotate the mesh
        //by angle degrees anticlockwise
        rotateMatrix.setRotationMat(angle);

        //Set the transformation matrix to an identity matrix to clear(?) it
        transformMatrix.setIdentity();
        //Concatenate the three matrices declared in this function into a single transformation matrix
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        //Call the transform function to apply the transformation matrix to the mesh's vertices
        Transform();
    }

    //Function that scales the mesh by stretching it by x horizontally and y vertically
    //This function works similarly to the rotate function
    void Scale(float x, float y)
    {
        //Declare these three HMatrix2Ds so that concatenating them will be easier, one for translating the mesh to the origin, 
        //one for translating the mesh back to its original position from the origin, and one for scaling the mesh. The mesh needs to 
        //translated to and from the origin just like the rotate function as directly applying the scaling matrix to the mesh will 
        //scale it from the origin, changing its position.
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D scaleMatrix = new HMatrix2D();

        //Set the matrices to translate the mesh to and from the origin by translating the mesh based on its position
        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        //Call the setScalingMat function to set the scaleMatrix into a scaling matrix with the values needed to scale the mesh by x
        //and y
        scaleMatrix.setScalingMat(x, y);

        //Set the transformation matrix to an identity matrix to clear(?) it
        transformMatrix.setIdentity();
        //Concatenate the three matrices declared in this function into a single transformation matrix
        transformMatrix = fromOriginMatrix * scaleMatrix * toOriginMatrix;

        //Call the transform function to apply the transformation matrix to the mesh's vertices
        Transform();

    }

    //This function applies the transfromation matrix to every vertice in the cloned mesh
    private void Transform()
    {
        //Get the vertices from the MeshManager into the vertices array
        vertices = meshManager.clonedMesh.vertices;

        //For each vertice in the vertices array
        for (int i = 0; i < vertices.Length; i++)
        {
            //Store the position of the vertex, which is a Vector3, as a HVector2D, so that the functions and operators for HVector2Ds 
            //can work on it
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            //Multiply the vertex position by the transformation matrix to get the value of the position the vertex has to be to carry
            //out the transformation
            vert = transformMatrix * vert;
            //Set the x and y values of the vertex's position (a Vector3) to the x and y values stored in the vert variable (a HVector2D)
            //so that its new position can be stored as a Vector 3 and replace its original position
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        //Set the position of the actual vertices of the mesh to their new vertices stored in the vertices array
        meshManager.clonedMesh.vertices = vertices;
    }
}
