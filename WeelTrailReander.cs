using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeelTrailReander : MonoBehaviour
{

    CarMove carMove;
    TrailRenderer trailRenderer;

    void Awake(){
        carMove = GetComponentInParent<CarMove>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting =false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(carMove.IsTireScreeching(out float lateraVelocity, out bool isBraking))
        
            trailRenderer.emitting = true ;

        else trailRenderer.emitting = false; 

        

    }
}
