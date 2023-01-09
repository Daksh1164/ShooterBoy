using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    CannonController cannonController;
    LineRenderer lineRenderer;

    // Number of points on the line
    public int numPoints = 20;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;
    void Start()
    {
        cannonController = GetComponent<CannonController>();
        lineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lineRenderer.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {

            lineRenderer.positionCount = (int)numPoints;
            List<Vector2> points = new List<Vector2>();
            Vector2 startingPosition = cannonController.ShotPoint.position;
            //Vector2 startingVelocity = cannonController.ShotPoint.up * cannonController.BlastPower;
            Vector2 startingVelocity = Gun.instance.diff * 1.25f;

            for (float t = 0; t < numPoints; t += timeBetweenPoints)
            {
                Vector3 newPoint = startingPosition + t * startingVelocity;
                newPoint.y = startingPosition.y + startingVelocity.y * t + (-0.15f)*t*t ;
                points.Add(newPoint);

                if (Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
                {
                    lineRenderer.positionCount = points.Count;
                    break;
                }
            }

            lineRenderer.SetPositions(ConvertTo3DArray(points.ToArray()));
        }

        if(Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }
    }

    public Vector3[] ConvertTo3DArray(Vector2[] array)
    {
        Vector3[] a = new Vector3[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            a[i] = new Vector3(array[i].x, array[i].y, 0);
        }
        return a;
    }
}
