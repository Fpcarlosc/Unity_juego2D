using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesaria para trabajar con la clase Text.

public class JugadorControl : MonoBehaviour
{
    public float velocidad; // Velocidad del jugador.
    public Text contarTexto; // Texto que muestra el numero de objetos conseguidos.
    public Text ganarTexto; // Texto que muestra el mensaje al ganar el juego

    private Rigidbody2D rb2d; // Componente para trabajar con físicas.
    private int contador; // Contador del número de objaetos conseguidos.

    // Inicilización
    void Start()
    {
        // Obtenemos la referencia al componente Rigidbody2D.
        rb2d = GetComponent<Rigidbody2D> ();

        // Inicializamos el contador a 0.
        contador = 0;

        // Inicializamos el texto del mensaje al ganar el juego a vacío.
        ganarTexto.text = "";

        // Llamamos al método para mostrar la información.
        Mostrarinformacion ();
    }

    // FixedUpdate es adecuado para trabajar con físicas ya que es independiente del frame rate. 
    // No utilizar el método Update para ello.
    void FixedUpdate()
    {
        // Movimiento horizontal.
        float movimientoH = Input.GetAxis ("Horizontal"); 

        // Movimiento vertical.
        float movimientoV = Input.GetAxis ("Vertical"); 

        // Almacenamos en un vector de 2 dimensiones el movimiento del jugador.
        Vector2 movimiento = new Vector2 (movimientoH, movimientoV); 

        // Aplicamos la fuerza en función del movimiento y velocidad del jugador.
        rb2d.AddForce (movimiento * velocidad); 
    }

    // OnTriggerEnter2D es llamado cuando este objeto se solapa con otro Collider.
    void OnTriggerEnter2D(Collider2D otro) 
    {
        // Comprobamos si el Collider solapado tiene como etiqueta "PickUp", si es así lo desactivamos, 
        // contamos un objeto más en el contador y lo mostramos.
        if (otro.gameObject.CompareTag("PickUp"))
        {
                otro.gameObject.SetActive(false);

                contador = contador + 1;

                Mostrarinformacion();
        }
    }

    // Método que muestra la inforamción sobre el número de objetos conseguidos.
    void Mostrarinformacion()
    {
        // Establecemos el texto con el número de obejtos conseguidos.
        contarTexto.text = "Contador: " + contador.ToString ();

        // Si hemos conseguido las 12 hemos ganado
        if (contador >= 12)
            ganarTexto.text = "¡Has ganado!";
    }
}
