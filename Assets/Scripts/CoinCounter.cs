using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    // Para las monedas que consigue el jugador
    public TMP_Text coinText;
    public int currentCoins = 0;

    // Variable para rastrear la cantidad total de monedas conseguidas
    private int totalCoins = 0;

    void Awake()
    {
        // Las monedas que tiene en el momento
        instance = this;
    }

    void Start()
    {
        coinText.text = "x " + currentCoins.ToString("00");
    }

    public void IncreaseCoins(int cantidad)
    {
        currentCoins += cantidad;
        totalCoins += cantidad; // Aumentar la cantidad total
        coinText.text = "x " + currentCoins.ToString("00"); // Con esto se va enseñando las monedas que se van ganando
    }

    // Método para obtener la cantidad total de monedas
    public int GetTotalCoins()
    {
        return totalCoins;
    }

 
}
