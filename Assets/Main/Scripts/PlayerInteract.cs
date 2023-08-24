using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
           InteractAnimal interactAnimal = collision.GetComponent<InteractAnimal>();
           interactAnimal.PopIn_Indirect();
      

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            InteractAnimal interactAnimal = collision.GetComponent<InteractAnimal>();
            interactAnimal.PopOut();


        }
    }

}
