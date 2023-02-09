using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class matematikKontrol : MonoBehaviour
{
    [SerializeField] private List<GameObject> toplar = new List<GameObject>();
    [SerializeField] private TMP_Text sayac = null;
    [SerializeField] private GameObject yanmapanel;
    [SerializeField] private GameObject topPrefab;
    

    private int _kapiNum;   
    private int klonDeger;
    private GameObject sonTop;

    void Update()
    {
        UpdateSayacFonk();
        if (toplar.Count <= 0)
        {
            yanmapanel.SetActive(true);//top sayýsý 0sa paneli görünür yap
            Time.timeScale = 0.0f;//oyunu durdur(yani zamaný)
        }
        
    }
    private void UpdateSayacFonk()
    {
        sayac.text = toplar.Count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("TopX"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, toplar[toplar.Count - 1].transform.localPosition.z + 1f);
            toplar.Add(other.gameObject);
            //toplar[toplar.Count] iþlemini dizinin son elemanýna eriþmek içinkullandýk
        }
        
        {

        }
        if (other.gameObject.CompareTag("kapi+"))
        {
            //Debug.Log(_kapiNum);
            _kapiNum= other.gameObject.GetComponent<kapiKontrol>().GetKapiNum();
            ToplamaFonk();
        }
        if (other.gameObject.CompareTag("kapi*"))
        {

            _kapiNum = other.gameObject.GetComponent<kapiKontrol>().GetKapiNum();
            CarpmaFonk();
        }

        if (other.gameObject.CompareTag("kapi-"))
        {
            _kapiNum = other.gameObject.GetComponent<kapiKontrol>().GetKapiNum();
            CikarmaFonk();
        }
        if (other.gameObject.CompareTag("kapi%")){
            _kapiNum = other.gameObject.GetComponent<kapiKontrol>().GetKapiNum();
            BolmeFonk();
        }
        
         

    }
    
    private void OnTriggerStay(Collider other)//çarpýþma olduðu süreçte devamlý çalýþýr
    {
       
        if (other.gameObject.CompareTag("engel"))
        { //dizinin herhangi bir elemaný engele çarparsa azalt
            sonTop = toplar[toplar.Count-1];
            toplar.Remove(sonTop);//burada diziden kaldýrýyoruz
            Destroy(sonTop);//burada oluþan gameobjecti siliyoruz
            
            

        }


        
    }
    
    private void ToplamaFonk()
    {
        for (int i = 0; i < _kapiNum; i++)
        {
            GameObject yeniTop = Instantiate(topPrefab);
            topPrefab.gameObject.tag = "Klon";//devam et
            yeniTop.transform.SetParent(transform);
            yeniTop.GetComponent<SphereCollider>().enabled = false;
            yeniTop.transform.localPosition = new Vector3(0f, 0f, toplar[toplar.Count - 1].transform.localPosition.z + 1f);
            toplar.Add(yeniTop);
        }
    }
    private void CikarmaFonk()
    {
        if (toplar.Count>=0)
        {
            for (int i = _kapiNum; i > 0; i--)
            {
                sonTop = toplar[toplar.Count - 1];
                toplar.Remove(sonTop);
                Destroy(sonTop);

            }
        }
        else
        {
            Time.timeScale = 0f;
            yanmapanel.SetActive(true);
        }

    }
    private void CarpmaFonk()
    {
        klonDeger = (_kapiNum * toplar.Count)-toplar.Count;//kapi = 5 * top=3 = 15 ama 12 top ekleyeceðiz
        
        for (int i = 0; i < klonDeger; i++)
        {
            GameObject yeniTop = Instantiate(topPrefab);//yeni top oluþturduk
            yeniTop.transform.SetParent(transform);
            yeniTop.GetComponent<SphereCollider>().enabled = false;
            yeniTop.transform.localPosition = new Vector3(0f, 0f, toplar[toplar.Count - 1].transform.localPosition.z + 1f);
            toplar.Add(yeniTop);
        }
    }
    private void BolmeFonk()
    {
        if (toplar.Count>=0)
        {
            int deger = toplar.Count - (toplar.Count / _kapiNum);  //65 / 5 =13 
            for (int i = 1; i <= deger; i++)
            {
                sonTop = toplar[toplar.Count - 1];
                toplar.Remove(sonTop);
                Destroy(sonTop);

            }
        }
        else
        {
            Time.timeScale = 0f;
            yanmapanel.SetActive(true);
        }
    }
}
