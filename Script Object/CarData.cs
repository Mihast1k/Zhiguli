using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Car Data",menuName = "Car Data", order = 51)]

public class CarData : ScriptableObject
{
    [SerializeField]
    //1
    private int carUniqueID = 0;

    [SerializeField]
     //2
    private Sprite carUISprite;

    [SerializeField]
     //3
    private GameObject carPrefab;

    public int CarUniqueID{
        get {return carUniqueID;}
    }
    //мы используем доступный int CarUniqueID и возвращаем уникальный ID машины

    public Sprite CarUISprite{
        get {return carUISprite;}
    }
    public GameObject CarPrefab{
        get {return carPrefab;}
    }
}
