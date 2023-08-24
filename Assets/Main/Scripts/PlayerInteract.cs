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
            Animator animator_Animal= collision.GetComponent<Animator>();
            animator_Animal.SetBool("Interact",true);
      

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            Animator animator_Animal = collision.GetComponent<Animator>();
            animator_Animal.SetBool("Interact",false);

        }
    }

}
