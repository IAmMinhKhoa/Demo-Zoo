using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyToTime : MonoBehaviour
{
    public float destroyTime = 2f; // Th?i gian h?y ??i t??ng (s? giây)

    void Start()
    {
        // G?i hàm DestroyObject sau kho?ng th?i gian destroyTime
        Invoke("DestroyObject", destroyTime);
    }

    void DestroyObject()
    {
        // H?y ??i t??ng
        Destroy(gameObject);
    }
}
