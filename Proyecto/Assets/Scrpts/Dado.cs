using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dado : MonoBehaviour {

    public float lanzar;
    public Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //rb.AddForce(transform.up * lanzar);
            //this.transform.Rotate(new Vector3(Time.deltaTime * 10, Time.deltaTime * 30, Time.deltaTime * 20));
        }

    }
}
