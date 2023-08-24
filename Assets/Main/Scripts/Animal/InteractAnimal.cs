using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAnimal : MonoBehaviour
{
    protected Animator animator_Animal;
    public GameObject img_infor;
    public GameObject btn_infor;
    private void Start()
    {
        animator_Animal = GetComponent<Animator>();   
    }

    //Indirect giantiep
    //direct tructiep
    public void PopIn_Direct()
    {
        animator_Animal.SetBool("Interact", true);
        img_infor.SetActive(true);
    }
    public void PopIn_Indirect()
    {
        animator_Animal.SetBool("Interact", true);
        btn_infor.SetActive(true);
    }
    public void PopOut()
    {
        animator_Animal.SetBool("Interact", false);
        btn_infor.SetActive(false);
        img_infor.SetActive(false);
    }

}
