using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kapiKontrol : MonoBehaviour
{
    [SerializeField] private TMP_Text kapiText=null; 
    [SerializeField] private enum KapiTipi
    {
        topla,
        cikar,
        carp,
        bol
    }
    [SerializeField] private KapiTipi kapiTipi;
    [SerializeField] private int kapiNum;
    public int GetKapiNum()
    {
        return kapiNum;
    }

    void Start()
    {
        RandomKapiNum();
    }

    private void RandomKapiNum()
    {
        switch (kapiTipi)
        {
            case KapiTipi.topla: kapiNum = Random.Range(1, 10);
                kapiText.text = kapiNum.ToString(); 
                break;
            case KapiTipi.cikar:
                kapiNum = Random.Range(1, 5);
                kapiText.text = kapiNum.ToString();
                break;
            case KapiTipi.bol:
                kapiNum = Random.Range(1, 10);
                kapiText.text = kapiNum.ToString();
                break;
            case KapiTipi.carp:
                kapiNum = Random.Range(1, 10);
                kapiText.text = kapiNum.ToString();
                break;
        }             
    }
    
}
