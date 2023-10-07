using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadMovimiento = 2.8f;
    private bool miraDerecha = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(-8.22f, -4.25f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoEjeX = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;
        float movimientoEjeY = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;
                 
        // Mueve el jugador
        Vector2 movimiento = new Vector2(movimientoEjeX, movimientoEjeY);
        transform.Translate(movimiento);
       
        // Animación de movimiento
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoEjeX));
        animator.SetFloat("Vertical", movimientoEjeY);


        // Gira el jugador según la dirección del movimiento
        if (movimientoEjeX < 0 && miraDerecha)
        {
            // Si está mirando a la derecha pero se está moviendo hacia la izquierda
            Flip();
        }
        else if (movimientoEjeX > 0 && !miraDerecha)
        {
            // Si está mirando a la izquierda pero se está moviendo hacia la derecha
            Flip();
        }
    }

    // Voltea la orientación del jugador
    void Flip()
    {
        miraDerecha = !miraDerecha;

        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
