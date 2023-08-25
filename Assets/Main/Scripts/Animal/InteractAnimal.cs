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
    //Direct tructiep
    public void PopIn_Direct()//use when finger touch direct into a aniaml cages
    {
        ActiveAnimator(animator_Animal, "Interact", true);
        ActiveTableInfor(true);
    }
    public void PopIn_Indirect()//use when player go into trigger cage.
    {
        ActiveAnimator(animator_Animal, "Interact", true);

    }
    public void PopOut() //use when not touch a animal cages 
    {
        ActiveAnimator(animator_Animal, "Interact", false);
        ActiveTableInfor(false);
    }


    public void  ActiveTableInfor(bool active)
    {
        tableInforAnimal.SetActive(active);
    }
    
    public void ActiveAnimator(Animator animate,string nameAnimate, bool status)
    {
        animate.SetBool(nameAnimate, status);
    }

}
