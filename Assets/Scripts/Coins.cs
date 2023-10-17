using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value;


    // Sonido, en este caso no se utiliza. El sonido se le ha puesto al script de player, porque si se reproduce el sonido en el OnTriggerEnter, reproduce el sonido hasta que el objeto se elimina
    [SerializeField]
    private AudioSource nom;


    void Start()
    {
            value = 05;

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);
        }
    }
}
