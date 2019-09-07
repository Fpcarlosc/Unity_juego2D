using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    // Utilizamos Update ya que no usamos fuerzas. 
    // Este método es llamado en cada frame.
    void Update () 
    {
        // Rotamos el "transform" del gameobject utilizando el método Rotate en el eje z y teniendo en cuenta el tiempo desde el último frame.
        transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
    }
}
