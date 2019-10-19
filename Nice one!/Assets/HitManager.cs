using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField]
    public float Force = 1f;
    Rigidbody rb;
    public int count;
    GameObject net;
    BoxCollider netCollider;

    bool bKicked = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        net = GameObject.FindGameObjectWithTag("Net");
        netCollider = net.GetComponent(typeof (BoxCollider)) as BoxCollider;
    }

    // Update is called once per frame
     void Update () 
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
