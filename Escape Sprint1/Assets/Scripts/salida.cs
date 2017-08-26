using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salida : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Personaje")
        {
            Debug.Log("Salida");
        }
    }
}
