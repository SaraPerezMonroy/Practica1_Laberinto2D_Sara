using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 40f;
    float blinkSpeed = 1f;
    bool estaJugando = true;

    [SerializeField]
    TextMeshProUGUI countdownText;

    [SerializeField]
    GameObject pantallaPerder;

    [SerializeField]
    TextMeshProUGUI textLabelSegundos;

    [SerializeField]
    Color color1 = Color.white;

    [SerializeField]
    Color color2 = Color.red;

    [SerializeField]
    GameObject pantallaFinal;

    [SerializeField]
    private AudioSource Derrota;




    // Empezamos la corutina aquí porque si la ponemos dentro del if da error
    void Start()
    {
        currentTime = startingTime;
        StartCoroutine(BlinkText());
    }

    void Update()
    {
        // Ponemos el if estaJugando para que si salta la pantalla de victoria, deje de jugar y deje de contar tiempo
        if (estaJugando)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                pantallaPerder.SetActive(true);
                currentTime = 0;
                estaJugando = false; 
                Derrota.Play();
            }
        }

        // Para ver si la pantallaFinal está activa y, si lo está, que pare de jugar
        if (pantallaFinal.activeSelf)
        {
            estaJugando = false; 
        }
    }

    // Esto sirve para que el texto parpadee
    IEnumerator BlinkText()
    {
        while (true)
        {
            textLabelSegundos.color = color1;
            yield return new WaitForSeconds(blinkSpeed);
            textLabelSegundos.color = color2;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}
