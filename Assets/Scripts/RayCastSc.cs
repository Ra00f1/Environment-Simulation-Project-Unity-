using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class RayCastSc : MonoBehaviour
{
    public int NumberOfRays;
    public int layerMask;
    private int degerees;

    private Vector3 Direction;

    public Color Color1;
    public Color Color2;

    void Start()
    {
    }
    public void Cast()
    {
        degerees = 360 / NumberOfRays;
        layerMask = ~LayerMask.NameToLayer("Ground");

        for (int i = 0; i < NumberOfRays; i++)
        {
            float sin = Mathf.Sin(Mathf.Deg2Rad * (degerees * i)) * 2;
            if (sin > 0)
                sin = -sin + 1;

            float cos = Mathf.Cos(Mathf.Deg2Rad * (degerees * i)) * 2;
            //if (cos < 0)
            //    cos = -cos;

            RaycastHit hit;
            Direction = new Vector3(0, sin, cos);

            if (Physics.Raycast(transform.position, Direction, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, Direction * hit.distance, Color.yellow);

            }
        }
    }
}