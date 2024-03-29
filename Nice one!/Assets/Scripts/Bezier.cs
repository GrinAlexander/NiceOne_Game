﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform p0, p1, p2;
    private int numPoints = 50;
    [SerializeField]
    public static Vector3[] positions = new Vector3[50];
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = numPoints;  
    }

    // Update is called once per frame
    void Update()
    {
        DrawQuadraticCurve();
    }

    private void DrawQuadraticCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalcQuadraticBezierPoint(t, p0.position, p1.position, p2.position);
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalcQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }
}
