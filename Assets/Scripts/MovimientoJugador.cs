using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadMovimiento = 2.8f;
    private bool miraDerecha = true;
    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody2D rb;

   
    [SerializeField]
    private Animator anim;



    void Start()
    {
        transform.position = new Vector2(-8.22f, -4.25f);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Inicializa el AudioSource
    }

    void Update()
    {
        float movimientoEjeX = Input.GetAxis("Horizontal") * velocidadMovimiento * Time.deltaTime;
        float movimientoEjeY = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;

        // Mueve el jugador
        Vector2 movimiento = new Vector2(movimientoEjeX, movimientoEjeY);
        transform.Translate(movimiento);

        // Animación de movimiento
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)
        || Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
         anim.SetBool("running", true);
        }
        else
        {
         anim.SetBool("running", false);
        }


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

    // Se llama cuando el jugador toca un collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            // Reproduce el sonido "nom" cuando toca un objeto con el tag "Coin"
            if (audioSource != null)
            {
                audioSource.Play();
            }

        }

    }
   
        
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            animator.SetBool("hurt", true);
            StartCoroutine(RecuperarseDespuesDeDelay(2f));
           // Debug.Log("funciona");
        }
    }

    IEnumerator RecuperarseDespuesDeDelay(float delay)
    {
        // Esperar el tiempo especificado.
        yield return new WaitForSeconds(delay);

        // Restablecer la animación a "Idle".
        animator.SetBool("hurt", false);
    }


}
