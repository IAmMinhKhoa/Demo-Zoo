using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    
    public GameObject GO_BtnInfor;
    protected InteractAnimal interactAnimal;
    private void Start()
    {
        GO_BtnInfor.GetComponent<Button>().onClick.AddListener(ActiveTableInforAnimal);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
           interactAnimal = collision.GetComponent<InteractAnimal>();
           interactAnimal.PopIn_Indirect();
           ActiveObject(GO_BtnInfor, true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            interactAnimal = collision.GetComponent<InteractAnimal>();
            interactAnimal.PopOut();
            ActiveObject(GO_BtnInfor, false);
            interactAnimal = null;
        }
    }

    protected void ActiveObject(GameObject GO,bool status)
    {
        GO.SetActive(status);
    }
    protected void ActiveTableInforAnimal()
    {
        interactAnimal.ActiveTableInfor(true);

    }
}
