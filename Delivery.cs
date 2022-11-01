using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
     [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
     [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
     [SerializeField] float destrydelay = 0.5f;//destruir objeto tempo
     SpriteRenderer spriteRenderer;
     void Start() 
     {
          spriteRenderer = GetComponent<SpriteRenderer>();
     }
     bool hasPackage;
     private void OnCollisionEnter2D(Collision2D other)//bater
     {
          Debug.Log("Bateu em");
     }
     private void OnTriggerEnter2D(Collider2D other)//passar por cima
     {
          if(other.tag == "Package" && !hasPackage)
          {
               Debug.Log("Package picked up");
               hasPackage = true;
               spriteRenderer.color = hasPackageColor;
               Destroy(other.gameObject, destrydelay);//destruir objeto
          }
          if(other.tag == "Costumer" && hasPackage)
          {
               Debug.Log("Package Delivery");
               hasPackage = false;
               spriteRenderer.color = noPackageColor;
          }
     }
}
