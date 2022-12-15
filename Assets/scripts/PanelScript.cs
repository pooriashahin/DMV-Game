using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PanelScript : MonoBehaviour
{
   public GameObject Panel;
   public GameObject Car;
   public GameObject Sign;
   public GameObject GearsCanvas;
 
   public void vanishGear(){
       if(GearsCanvas!= null){
           //bool isActive = GearsCanvas.activeSelf;
           GearsCanvas.SetActive(false);
       }
   }
   public void vanishCar(){
       if(Car!= null){
           Car.SetActive(false);
       }
   }
   public void appearPanel(){ //turns panel off/on
       if(Panel!= null){
          // bool isActive = Panel.activeSelf;
          Debug.Log("pannel should appear");
           Panel.SetActive(true);
           vanishCar();
           vanishGear();
       }
   }   
   private void OnTriggerEnter2D(Collider2D collider){
    if (collider.gameObject.tag == "Car") {
        Sign.GetComponent<BoxCollider2D>().enabled = false;
       Debug.Log("Trigger Panel!");
       appearPanel();
    }
      
    //    StartCoroutine(EnableBox(60.0F));
   }
//    IEnumerator EnableBox(float waitTime) {
//         if(Panel.activeInHierarchy)
//         yield return new WaitForSeconds(waitTime);
//         Panel.SetActive(false);

//    }
  
  
}
