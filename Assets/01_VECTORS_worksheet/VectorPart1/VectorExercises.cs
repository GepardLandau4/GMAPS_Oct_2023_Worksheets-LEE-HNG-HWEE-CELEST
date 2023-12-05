using UnityEngine;


public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector3 startPt;
    private Vector3 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    

    private void Start()
    {
        CalculateGameDimensions();
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;


    }

    void Question2a()
    {
        //Declare 2 vector2s to represent the positions of the start and end points of the line that will be drawn
        startPt = new Vector2(0,0);
        endPt = new Vector2(2,3);

        //Call the the GetLine function to store a line with the previously stated start and end points in a variable, and enable the line to be drawn
        //drawing so that the line will show up 
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        //Calculate the magnitude of the line drawn and display it on the console by calculating the vector of the line first, and then 
        //using the function to calculate the magnitude
        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        //The for loop will activate n times
        for (int i = 0; i < n; i++)
        {
            //Declare the float variables that state 
            //float maxX = 5;
            //float maxY = 5;

            //Declare 2 vector2s to represent the positions of the start and end points of the line that will be drawn, this time
            //random.range is used so that the X and Y values of the start and end points will be a random number between 5 and -5
            startPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(new Vector3(0, 0, 0), new Vector3(5, 5, 0), Color.red, 60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //startPt = new Vector2(
                //Random.Range(-maxX, maxX), 
                //Random.Range(-maxY, maxY));

            // Your code here
            endPt = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(-5, 5));

            DebugExtension.DebugArrow(new Vector3(0, 0, 0), endPt, Color.white, 60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3f, 5f);
        HVector2D b = new HVector2D(-4f, 2f);
        HVector2D c = a - b;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        DebugExtension.DebugArrow(a.ToUnityVector3(), (b * -1).ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of a = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of a = " + c.Magnitude().ToString("F2"));
        
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3f, 5f);
        HVector2D b = a / 2;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(1f, 0f, 0f), b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3f, 5f);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        a.Normalize();
        DebugExtension.DebugArrow(new Vector3(1f, 0f, 0f), a.ToUnityVector3(), Color.green, 60f);
        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        HVector2D v2 = c - a;

        HVector2D proj = v2.Projection(b);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
    
}
