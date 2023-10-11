using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BotonReiniciar : MonoBehaviour
{
    void Start()    {       
    }

    void Update()    {
    }

    // Para poder reiniciar el juego
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
