using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCar : MonoBehaviour
{
    [Header("Car prefab")]
    public GameObject carPrefab;

    [Header("Spawn on")]
    public Transform spawnTransform;

    bool isChangingCar = false;
    //для того чтобы понимать меняем мы автомобили или нет

    CarData[] carDatas;

    int selectedCarIndex = 0;
    
    int selectLevel =1;

    CarUIHandler carUIHandler = null;

    // Start is called before the first frame update
    void Start()
    {
        carDatas = Resources.LoadAll<CarData>("CarData/");
        //мы загружам данные о дргуих автомобилях в наш массив
        StartCoroutine(SpawnCarSO(true));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
           OnPreviousCar();
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            OnNextCar();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            OnSelectCar();
        }
    }

    public void OnPreviousCar(){

        if(isChangingCar)
            return;

        selectedCarIndex--;
        if(selectedCarIndex < 0){
            selectedCarIndex = carDatas.Length - 1;
        }
         StartCoroutine(SpawnCarSO(true));

    }
    public void OnNextCar(){
         if(isChangingCar)
            return;

        selectedCarIndex++;
        if(selectedCarIndex > carDatas.Length - 1){
            selectedCarIndex = 0;
        }

        StartCoroutine(SpawnCarSO(false));

    }

    public void OnSelectCar(){
        PlayerPrefs.SetInt("P1SelectCarID1",carDatas[selectedCarIndex].CarUniqueID);
        PlayerPrefs.Save();

        

        if(selectLevel == 1){
         SceneManager.LoadScene("lvl1");
        }
        if(selectLevel == 2){
         SceneManager.LoadScene("lvl2");
        }
        if(selectLevel == 3){
         SceneManager.LoadScene("lvl3");
        }
        if(selectLevel == 4){
         SceneManager.LoadScene("lvl4");
        }
        if(selectLevel == 5){
         SceneManager.LoadScene("lvl5");
        }
        if(selectLevel == 6){
         SceneManager.LoadScene("lvl6");
        }

    }

    IEnumerator SpawnCarSO(bool isCarAppearingOnRightSide){

        isChangingCar = true;

        if (carUIHandler != null)
            carUIHandler.StartCarExitAnimation(!isCarAppearingOnRightSide);
        //если carUIHandler не "0" то мы запускаем анимацию выхода с другой стороны
        GameObject instantiateCar = Instantiate(carPrefab,spawnTransform);

        carUIHandler = instantiateCar.GetComponent<CarUIHandler>();
        carUIHandler.SetupCar(carDatas[selectedCarIndex]);
        carUIHandler.StartCarEntranceAnimation(isCarAppearingOnRightSide);
        //запуск скрипка который запускает анимации 

        yield return new WaitForSeconds(0.6f);
        // yiels это оператор для предоставления следующего значения или сигнала о завершении итерации.

        isChangingCar = false;
    }

    public void lvl1(){
        selectLevel = 1;
    }
    public void lvl2(){
        selectLevel = 2;
    }
    public void lvl3(){
        selectLevel = 3;
    }
    public void lvl4(){
        selectLevel = 4;
    }
    public void lvl5(){
        selectLevel = 5;
    }
    public void lvl6(){
        selectLevel = 6;
    }

    
}
