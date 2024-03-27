using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boatpathingscript : MonoBehaviour
{
    NavMeshAgent nm;
    Rigidbody rb;

    public Transform Target;
    public Transform[] Square, Triangle, Star, WayPoints;
    public int Cur_Waypoint;
    public float speed, stop_distance;
    public float PauseTimer;
    private List<Transform[]> points = new List<Transform[]>();
    private static int score;
    private int pointNum, listLength;
    [SerializeField]
    private float cur_timer;


    void Start()
    {
        pointNum = 0;
        points.Add(Square);    //Adds shapes to the be randomized
        points.Add(Triangle);
        points.Add(Star);

        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        listLength = points.Count - 1;
        rb.freezeRotation = true;
        //Randomizes the order of the shapes to be traced out by the croc
        for (int i = 0; i <= listLength; i++)
        {
            int index = Random.Range(0, points.Count);
            for (int j = 0; j < points[index].Length; j++)
            {
                WayPoints[pointNum] = points[index][j];
                pointNum++;
            }
            points.RemoveAt(index);
        }
      
    }

    void Update()
    {


        nm.acceleration = speed;
        nm.stoppingDistance = stop_distance;

        float distance = Vector3.Distance(transform.position, Target.position);

        if (distance > stop_distance && WayPoints.Length > 0)
        {

            Target = WayPoints[Cur_Waypoint];
        }

       
        nm.SetDestination(Target.position);
    }
}
//WaterPro_DayTime