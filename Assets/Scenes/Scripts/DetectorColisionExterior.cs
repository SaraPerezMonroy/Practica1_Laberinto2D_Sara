using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionExterior : MonoBehaviour
{
   [SerializeField]
   Material materialExteriorPorDefecto;
   [SerializeField]
   Material materialExteriorTocado;

   bool paredRoja = false;
   float tiempoEnRojo = 2f;

   private void Update()
   {
	   if (paredRoja == true)
	   {
		   tiempoEnRojo =  tiempoEnRojo - Time.deltaTime;
		   if (tiempoEnRojo < 0.0f)
		   {
			   gameObject.GetComponent<MeshRenderer>().material = materialExteriorPorDefecto;
			   paredRoja = false;
			   tiempoEnRojo = 2f;

		   }
	   }
   }

   // Se ejecuta al chocar un objeto con este GameObject
   private void OnCollisionEnter2D(Collision2D col)
   {
	   if(col.gameObject.tag == "Player")
	   {
	   Debug.Log(col.gameObject.name);
	   gameObject.GetComponent<MeshRenderer>().material = materialExteriorTocado;
	   paredRoja = true;

			
	   }
   }
}
