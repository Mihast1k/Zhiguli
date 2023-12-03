using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarUIHandler : MonoBehaviour
{
    [Header("Car details")]
    public Image carImage;

    Animator animator = null;

    void Awake(){
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetupCar(CarData carData){
        carImage.sprite = carData.CarUISprite;
    }

    public void StartCarEntranceAnimation(bool isAppearingOnRightSide){
        if(isAppearingOnRightSide){
            animator.Play("Car from right");

        }
        else animator.Play("Car from left");
    }
    public void StartCarExitAnimation(bool isExitingOnRightSide){
        if(isExitingOnRightSide){
            animator.Play("Car disappear right");
        }
        else animator.Play("Car disappear left");
    }

    public void OnCarExitAnimationCompleted(){
        Destroy(gameObject);
    }
}
