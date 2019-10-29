using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class HitManager : MonoBehaviour
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
            rb.MovePosition(CalcQuadraticBezierPoint(p0.position, p1.position, p2.position));
            
            index++;
            isKicked = true;
            
        }
        else
        {
            rb.AddForce(CalcQuadraticBezierPoint(p0.position, p1.position, p2.position) * 20f);
            index = 1;
            isKicked = false;
        }
    }

    private float CalcT()
    {
        return index / (float)numPoints;
    }

    private Vector3 CalcQuadraticBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float t = CalcT();
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }
}*/

public class HitManager : MonoBehaviour
{
    Rigidbody rb;
    public int count;
    public Transform p0, p1, p2;
    public bool isKicked = false;
    private int numPoints = 50;
    private float index = 1;
    private Vector3 current;
    private Vector3 next;
    private float force = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (rb.position == p1.position)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce((p2.position - p1.position) * force);

        }
        /* else if (rb.position.Equals(p2.position))
         {
             rb.useGravity = true;
             isKicked = false;
         }*/
        /* if (isKicked && (index < numPoints + 1))
         {

             index++;
             isKicked = true;

         }
         else
         {
             rb.AddForce(CalcQuadraticBezierPoint(p0.position, p1.position, p2.position) * 20f);
             index = 1;
             isKicked = false;
         }*/
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Net"))
        {
            rb.useGravity = true;
            isKicked = false;
            count++;
        }
    }

    void OnMouseDown()
    {
        //current = rb.position;

        rb.useGravity = false;
        rb.AddForce(p1.position * force);
        isKicked = true;
    }

    /* IEnumerator MoveWithDelay()
     {
         yield return new WaitForEndOfFrame();

     }*/

    private float CalcT()
    {
        return index / (float)numPoints;
    }

    private Vector3 CalcQuadraticBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float t = CalcT();
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }
}