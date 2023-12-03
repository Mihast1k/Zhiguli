using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    CarMove TopDownCarController;

    // Start is called before the first frame update
    void Awake()
    {
        TopDownCarController = GetComponent<CarMove>();
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        TopDownCarController.SetInputVector(inputVector);
    }
}
