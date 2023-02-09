using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class topKontrol : MonoBehaviour
{   
    [SerializeField] private float hareketHizi;
    [SerializeField] private float yatayHareketHizi;

    Transform myTransform,camTransform;
    private float yatayDeger;//horizontal
    float yeniX;
    private void Start()
    {
        myTransform = transform;
        camTransform = Camera.main.transform;
    }
    void Update()
    {
        yatayHareket();
        ileriHareket();
        
    }

    //private void OnMouseDrag()
    //{
       
    //    myTransform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, -camTransform.position.z));

    //}
        private void yatayHareket()
    {

        if (Input.GetMouseButton(0))//mousenin sol tuþu (0.index)
        {
            yatayDeger = -Input.GetAxisRaw("Mouse X");//yatay olarak x ekseninde hareket eden mouse
        }
        else
        {
            yatayDeger = 0;
        }
        yeniX = transform.position.x + yatayDeger * yatayHareketHizi * Time.deltaTime;
        yeniX = Mathf.Clamp(yeniX, -3, 8);//a ila b arasýndaki deðerleri  alabilir

        transform.position = new Vector3(yeniX,
            transform.position.y,
            transform.position.z
        );
       // vector3 ile x'in yeni pozisyonu belirledik

    }
    private void ileriHareket()
    {
        transform.Translate(-Vector3.forward * hareketHizi *  Time.deltaTime);
    }
  
}
