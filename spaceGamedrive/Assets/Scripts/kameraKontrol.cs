using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraKontrol : MonoBehaviour
{
    [SerializeField] private Transform topHareketi;
    private Vector3 mesafe;
    [SerializeField] private float lerp;

    void Start()
    {
        mesafe = transform.position -topHareketi.position;
    }

   
    void LateUpdate()
    {
        Vector3 yeniPoz = Vector3.Lerp(transform.position, topHareketi.position + mesafe, lerp * Time.deltaTime);
        transform.position = yeniPoz;
    }
}
