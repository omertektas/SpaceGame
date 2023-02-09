using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//sahnelerle ilgili iþlemler için gerekli 

public class butonKontrol : MonoBehaviour
{   
    [SerializeField] private GameObject baslatPaneli;
    [SerializeField] private GameObject yanmaPaneli;
    [SerializeField] private GameObject beklemePaneli;
    public void baslatButon()
    {
        baslatPaneli.SetActive(false);
        Time.timeScale = 1.0f;
        

    }
    public void tekrarBaslat()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish"))
        {          
            SceneManager.LoadScene("SampleScene2c");
        }
        if (other.gameObject.CompareTag("finish2"))
        {
            SceneManager.LoadScene("SampleScene3c");
        }
        if (other.gameObject.CompareTag("finish3"))
        {
            SceneManager.LoadScene("SampleScene4c");
        }
        if (other.gameObject.CompareTag("finish4"))
        {
            SceneManager.LoadScene("SampleScene5c");
        }
        if (other.gameObject.CompareTag("durdur"))//sonradan sil
        {
            Time.timeScale = 0.0f;
        }
    }
    
   
    public void durdur()
    {
        Time.timeScale = 0.0f;
        beklemePaneli.SetActive(true);
    }
    public void devamEt()
    {
        beklemePaneli.SetActive(false);
        Time.timeScale=1.0f;
    }
    public void cikis()
    {
        Application.Quit();
    }

    //AGAÝN 
    public void bolum1()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void bolum2()
    {
        SceneManager.LoadScene("SampleScene2c");
    }
    public void bolum3()
    {
        SceneManager.LoadScene("SampleScene3c");
    }
    public void bolum4()
    {
        SceneManager.LoadScene("SampleScene4c");
    }
    public void bolum5()
    {
        SceneManager.LoadScene("SampleScene5c");
    }
    
}

