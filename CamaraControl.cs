using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public GameObject jugador; // Almacenamos la referencia del jugador.

    private Vector3 offset; // almacenamos la distancia entre la cámara y el jugador.

    // Inicialización
    void Start () 
    {
        // Calcula la distancia entre la posición de la cámara (transform) y la del jugador.
        offset = transform.position - jugador.transform.position;
    }
    
    // LateUpdate garantiza que todos los elementos han sido procesados en Update.
    void LateUpdate () 
    {
        // Establece la posición de la cámara sumando la posición del jugador más el offset calculado.
        transform.position = jugador.transform.position + offset;
    }
}
