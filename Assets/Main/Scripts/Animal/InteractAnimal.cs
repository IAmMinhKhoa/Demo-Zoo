using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractAnimal : MonoBehaviour
{
    protected Animator animator_Animal;
 
    [SerializeField] protected GameObject tableInforAnimal;
    [SerializeField] protected Button btn_Exits;
    private void Start()
    {
        animator_Animal = GetComponent<Animator>();
        btn_Exits.onClick.AddListener(() => ActiveTableInfor(false));
    }

    //Indirect giantiep
    //direct tructiep
    public void PopIn_Direct()
    {
        animator_Animal.SetBool("Interact", true);
        ActiveTableInfor(true);
    }
    public void PopIn_Indirect()
    {
        animator_Animal.SetBool("Interact", true);
      
    }
    public void PopOut()
    {
        animator_Animal.SetBool("Interact", false);
        ActiveTableInfor(false);
    }


    public void  ActiveTableInfor(bool active)
    {
        tableInforAnimal.SetActive(active);
    }
  

}
