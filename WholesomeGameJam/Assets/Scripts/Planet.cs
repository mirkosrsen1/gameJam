using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Transform point;
    public float Speed = 5;
    public float StartDistanceFromSun;
    public int Population;
    public float Scale;

    public float PopulationScaleFactor = 10000;
    public float Offset;
    private void Awake()
    {
        Scale = transform.localScale.x;
        transform.position = new Vector3(point.transform.position.x - StartDistanceFromSun, 0, 0);
        transform.position = RotatePointAroundPivot(transform.position, point.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0,360))));
    }

    public void Start()
    {
        Sun.Inst.AllPlanets.Add(this);
    }

    void Update()
    {
        Offset = (((float)Population / PopulationScaleFactor));
        var modOffset = Offset - Sun.Inst.Offset;

        Vector3 direction = Vector3.zero;
        if(modOffset > 0)
        {
            direction = transform.position - point.transform.position;
        }
        else if(modOffset < 0)
        {
            direction = point.transform.position - transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (direction * modOffset), modOffset * Time.deltaTime);

        if(modOffset * Scale > transform.localScale.x)
        {
            transform.localScale = Vector3.one *(Scale * modOffset);
        }


        transform.position = RotatePointAroundPivot(transform.position, point.position, Quaternion.Euler(new Vector3(0,0, Speed * Time.deltaTime)));
        Population++;
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }
}
