using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public int Force = 50;
    public int count;
    GameObject net;
    BoxCollider2D netCollider;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        net = GameObject.FindGameObjectWithTag("Net");
        netCollider = net.GetComponent(typeof (BoxCollider2D)) as BoxCollider2D;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Rigidbody rigidbody = gameObject.GetComponent(typeof (Rigidbody)) as Rigidbody;
        rigidbody.AddForce(transform.forward * Force);
        rigidbody.useGravity = true;
    }
    void OnTriggerEnter(Collider col)
    {

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Net")
        {
            count++;
        }
    }
}
