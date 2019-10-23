using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    Rigidbody rb;
    public int count;
    public Transform p0, p1, p2;
    public bool isKicked = false;
    private int numPoints = 50;
    private float index = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rb.MovePosition(Vector3.zero);
            rb.velocity = Vector3.zero;
            isKicked = false;
        }
        
    }

    void FixedUpdate()
    {
        if (isKicked)
        {
            StartCoroutine(MoveWithDelay());
            isKicked = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Net"))
        {
            count++;
            isKicked = false;
            rb.useGravity = true;
            rb.AddForce(CalcQuadraticBezierPoint(1f, p0.position, p1.position, p2.position) * 20f);
        }
    }

    void OnMouseDown()
    {
        rb.useGravity = false;
        isKicked = true;
    }

    IEnumerator MoveWithDelay()
    {
        yield return new WaitForEndOfFrame();
        if (index < numPoints + 1)
        {
            rb.MovePosition(CalcT());
            index++;
            isKicked = true;
        }
        else
        {
            index = 1;
            isKicked = false;
        }
    }

    private Vector3 CalcT()
    {
        float t = index / (float)numPoints;
        return CalcQuadraticBezierPoint(t, p0.position, p1.position, p2.position);
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
