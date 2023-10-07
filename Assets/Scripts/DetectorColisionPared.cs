using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionPared : MonoBehaviour
{
   [SerializeField]
   Material materialParedPorDefecto;
   [SerializeField]
   Material materialParedTocada;

   bool paredRoja = false;
   float tiempoEnRojo = 1.5f;

   private void Update()
   {
	   if (paredRoja == true)
	   {
		   tiempoEnRojo =  tiempoEnRojo - Time.deltaTime;
		   if (tiempoEnRojo < 0.0f)
		   {
			   gameObject.GetComponent<MeshRenderer>().material = materialParedPorDefecto;
			   paredRoja = false;
			   tiempoEnRojo = 1.5f;

		   }
	   }
   }

   // Se ejecuta al chocar un objeto con este GameObject
   private void OnCollisionEnter2D(Collision2D col)
   {
	   if(col.gameObject.tag == "Player")
	   {
	   Debug.Log(col.gameObject.name);
	   gameObject.GetComponent<MeshRenderer>().material = materialParedTocada;
	   paredRoja = true;

			
	   }
   }
}
