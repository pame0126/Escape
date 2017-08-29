using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Personaje")
        {
            Debug.Log("Salida");
        }
    }
}
