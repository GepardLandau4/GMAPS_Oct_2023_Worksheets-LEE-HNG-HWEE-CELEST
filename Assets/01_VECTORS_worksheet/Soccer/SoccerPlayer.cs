using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;


    float angle = 0f;

    private void Start()
    {
       OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();

       //ask about this
       //if (IsCaptain)
       //{
           //FindMinimum();
       //}
       //OtherPlayers = FindObjectsOfType<SoccerPlayer>();
       //SoccerPlayer[] temporary = new SoccerPlayer[OtherPlayers.Length - 1];
       //int i = 0;
       //foreach (SoccerPlayer player in OtherPlayers)
       //{
            //if (player != this)
            //{
                //temporary[i] = player;
                //i++;
            //}
       //}
       //OtherPlayers = temporary;
       //print(i);
    }

    /*
    void FindMinimum()
    {
        
        float minimum = 30f;
        for(int i = 0; i < 10; i++)
        {
            float height = Random.Range(5f, 20f);
            Debug.Log(height);
            if(height < minimum)
            {
                minimum = height;
            }
        }
        //Debug.Log("The minimum height is", minimum);
    }
    */

    float Magnitude(Vector3 vector)
    {
        return (float)Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
    }

    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        vector.x /= mag;
        vector.y /= mag;
        vector.z /= mag;

        return vector;
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return ((vectorA.x * vectorB.x) + (vectorA.y * vectorB.y) + (vectorA.z * vectorB.z));
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position;
            toPlayer = Normalise(toPlayer);

            float dot = Dot(toPlayer, transform.forward);
            float angle = Mathf.Acos(dot);
            angle = angle * (180 / Mathf.PI);
            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }
        
        return closest;
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            //ask lecturer about this
            Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.black);
        }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);
        //DrawVectors();
        if(IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}


