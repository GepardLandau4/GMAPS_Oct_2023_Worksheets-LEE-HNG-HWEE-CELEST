/* Note that Mesh.vertices returns a copy of the vertices array for a mesh.
 * 
 * From the Unity documentation: Returns a copy of the vertex positions or assigns a 
 * new vertex positions array.
 * 
 * Mesh.vertices is actually a C# property, that doesn't just return a value. See the 
 * source code here, if you're interested:
 * 
 * https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Graphics/Mesh.cs
 * (line 143)
 */

using UnityEngine;

//A script to clone and store the mesh properties so that it can be edited
public class MeshManager : MonoBehaviour
{
    //Declare the mesh filter component to get the mesh later on
    private MeshFilter meshFilter;

    //Declare variables to store the original and cloned mesh
    [HideInInspector]
    public Mesh originalMesh, clonedMesh;

    //Declare arrays to store the properties of the vertices and triangles from the mesh
    public Vector3[] vertices { get; private set; }
    public int[] triangles { get; private set; }

    void Awake()
    {
        //Get the MeshFilter component from the game object
        meshFilter = GetComponent<MeshFilter>();
        //Get the original mesh from the MeshFilter component and store it in originalMesh
        originalMesh = meshFilter.sharedMesh;

        //Declare the clonedMesh, name it, and set its properties to resemble those of the originalMesh, cloning it
        clonedMesh = new Mesh();
        clonedMesh.name = "clone";
        clonedMesh.vertices = originalMesh.vertices;
        clonedMesh.triangles = originalMesh.triangles;
        clonedMesh.normals = originalMesh.normals;
        clonedMesh.uv = originalMesh.uv;

        //Replace the mesh in the MeshFilter component with the cloned mesh so that the mesh can be edited without ruining the original
        meshFilter.mesh = clonedMesh;

        //Store the clonedMesh's vertices and triangles in the vertices and triangles arrays respectively
        vertices = clonedMesh.vertices;
        triangles = clonedMesh.triangles;
    }
}

