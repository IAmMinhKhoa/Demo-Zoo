using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{

    private Vector3 initialScale;
   


    private IEnumerator ScaleUpObject(GameObject obj, float scaleFactor, float duration)
    {
        Vector3 initialScale = obj.transform.localScale;
        Vector3 targetScale = initialScale * scaleFactor;
        float timer = 0f;
        
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
         
            yield return null;
        }

        obj.transform.localScale = targetScale;
    }

    private IEnumerator ScaleDownObject(GameObject obj, Vector3 initialScale, float duration)
    {
        Vector3 targetScale = obj.transform.localScale;
        float timer = 0f;
        Debug.Log(initialScale);
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            obj.transform.localScale = Vector3.Lerp(targetScale, initialScale, t);
            yield return null;
        }

        obj.transform.localScale = initialScale;
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal_Elephant"))
        {
            Animal interactAnimal= collision.GetComponent<Animal>();
            initialScale = interactAnimal.GO_Animal.transform.localScale;
            StartCoroutine(ScaleUpObject(collision.GetComponent<Animal>().GO_Animal, interactAnimal.scaleUp, 0.05f));
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal_Elephant"))
        {
            StopAllCoroutines();  // Stop any ongoing scaling coroutines
            StartCoroutine(ScaleDownObject(collision.GetComponent<Animal>().GO_Animal, initialScale, 0.05f));
        }
    }

}
