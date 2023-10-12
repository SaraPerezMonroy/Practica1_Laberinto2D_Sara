using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorMeta : MonoBehaviour
{
    [SerializeField]
    GameObject pantallaFinal;

    [SerializeField]
    TextMeshProUGUI textLabelTime;

    [SerializeField]
    TextMeshProUGUI textLabelFelicidades;

    float tiempoDePartida = 0.0f;
    bool estaJugando = true;

    [SerializeField]
    private AudioSource Victoria;

    void Start()
    {
        // Encuentra el objeto que tiene el script CoinCounter
    }

    void Update()
    {
        if (estaJugando == true)
        {
            tiempoDePartida = tiempoDePartida + Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("El jugador llegó a la meta");
            pantallaFinal.SetActive(true);
            other.GetComponent<MovimientoJugador>().enabled = false;
            estaJugando = false;
            textLabelTime.text = tiempoDePartida.ToString("0.0") + " segundos";
            Victoria.Play();

            CoinCounter coinCounter = FindObjectOfType<CoinCounter>();
            int totalCoins = coinCounter.GetTotalCoins();

            // Verifica las condiciones y establece el mensaje en textLabelFelicidades
            if (totalCoins == 30)
            {
                textLabelFelicidades.text = "Felicidades! Has recolectado todas las bellotas!!!";
            }
            else if (totalCoins >= 5)
            {
                textLabelFelicidades.text = "Has ganado!! Puedes conseguir mas bellotas?";
            }
            else
            {
                textLabelFelicidades.text = "Llegaste a la meta, pero moriras de hambre";
            }
        }
    }
}
