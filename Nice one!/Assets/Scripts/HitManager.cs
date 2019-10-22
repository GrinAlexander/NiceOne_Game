using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField]
    public float Force = 1f;
    Rigidbody rb;
    public int count;
    public Transform p0, p1, p2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Net")
        {
            count++;
        }
    }

    private void OnMouseDown()
    {
        var positions = Bezier.positions;
        foreach (var item in positions)
        {
            Debug.LogError(item);
        }
    }
}
