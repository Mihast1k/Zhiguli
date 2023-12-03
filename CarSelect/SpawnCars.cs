using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        CarData[] carDatas = Resources.LoadAll<CarData>("CarData/");

        for (int i = 0; i<spawnPoints.Length;i++){

            Transform spawnPoint = spawnPoints[i].transform;

            int playerSelectedCarID = PlayerPrefs.GetInt($"P{i+1}SelectCarID1");

            foreach(CarData carData in carDatas){

                if(carData.CarUniqueID == playerSelectedCarID){
                    GameObject playerCar = Instantiate(carData.CarPrefab,spawnPoint.position,spawnPoint.rotation);
                    break;
                }

            }
            //Тут просмотр данных о наших автомобилях в carDatas
        }

    }
}
