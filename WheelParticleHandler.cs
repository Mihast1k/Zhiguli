using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelParticleHandler : MonoBehaviour
{
    float particleEmissiomRate =0;
    CarMove carMove;
    ParticleSystem particleSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;
    
    void Awake(){
        carMove = GetComponentInParent<CarMove>();
        particleSystemSmoke = GetComponent<ParticleSystem>();
        particleSystemEmissionModule = particleSystemSmoke.emission;
        particleSystemEmissionModule.rateOverTime = 0;

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        particleEmissiomRate = Mathf.Lerp(particleEmissiomRate,0, Time.deltaTime*5);
        particleSystemEmissionModule.rateOverTime = particleEmissiomRate;

        if(carMove.IsTireScreeching(out float lateraVelocity, out bool isBraking))
        {
            if(isBraking){
                particleEmissiomRate =30;
            }
            else particleEmissiomRate = Mathf.Abs(lateraVelocity)*2;
        }





    }
}
