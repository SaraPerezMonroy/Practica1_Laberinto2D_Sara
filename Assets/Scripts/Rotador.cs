using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{


    float rotacionZ = 150f;

    [SerializeField]
    Material materialObstaculoTocado;   

    [SerializeField]
    Material materialObstaculo;   

    bool giratoriaRoja = false;
    float tiempoEnRojo = 2f;

    // Rotación
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotacionZ * Time.deltaTime);
        if (giratoriaRoja)
        {
            tiempoEnRojo -= Time.deltaTime;
            if (tiempoEnRojo < 0.0f)
            {
                RestaurarEstadoInicial();
            }
        }
    }
     // Colisión para activar el efecto de cambiar el color y la corutina del movimiento
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.name);
            ActivarEfectoPared();
            StartCoroutine(DetenerYReanudarMovimiento(col.gameObject));
        }
    }

    // Efecto de cambiar el color
    private void ActivarEfectoPared()
    {
        gameObject.GetComponent<MeshRenderer>().material = materialObstaculoTocado;
        giratoriaRoja = true;
    }

    // Esto es cómo está al principio, la pared sin rojo y el tiempo
    private void RestaurarEstadoInicial()
    {
        gameObject.GetComponent<MeshRenderer>().material = materialObstaculo;
        giratoriaRoja = false;
        tiempoEnRojo = 2f;
    }

    // Un IEnumerator para iterar sobre colecciones de elementos
    // También corutina para usar en distintos fotogramas
    private IEnumerator DetenerYReanudarMovimiento(GameObject jugador)
    {
        // Desactivar movimiento del jugador
        MovimientoJugador movimientoJugador = jugador.GetComponent<MovimientoJugador>();
        if (movimientoJugador != null)
        {
            movimientoJugador.enabled = false;
        }

        // Esperar 2 segundos, dentro de las expresiones corutinas se pone así
        yield return new WaitForSeconds(2f);

        // Reactivar movimiento del jugador
        if (movimientoJugador != null)
        {
            movimientoJugador.enabled = true;
        }

        // Restaurar estado inicial de la pared
        RestaurarEstadoInicial();
    }
}