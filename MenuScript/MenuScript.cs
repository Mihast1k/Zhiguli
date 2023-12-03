using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject panelSettings;

    public void StartPlay(){
        SceneManager.LoadScene("Start");

    }
    public void Back(){
        SceneManager.LoadScene("Menu");
    }
    public void Settings(){

    }
    public void Quit(){
        Application.Quit();

    }
    public void lavel1(){
        SceneManager.LoadScene("lvl1");
    }
    public void lavel2(){
        SceneManager.LoadScene("lvl2");
    }
    public void lavel3(){
        SceneManager.LoadScene("lvl3");
    }
    public void lavel4(){
        SceneManager.LoadScene("lvl4");
    }
    public void lavel5(){
        SceneManager.LoadScene("lvl5");
    }
    public void lavel6(){
        SceneManager.LoadScene("lvl6");
    }







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
