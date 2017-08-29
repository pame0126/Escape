using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propiedades : MonoBehaviour {

    private bool rotar = true;
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))//Click Derecho
        {
            rotar = false;
        }
        if (Input.GetMouseButtonDown(2))//Click Medio - Rueda
        {
            rotar = true;
        }
    }

    
    void OnMouseDown()
    {
        if (rotar)
        {
            GetComponent<Transform>().Rotate(0, 0, 90);
        }
    }
}
