using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarSfxHandler : MonoBehaviour
{
    [Header("Audio sources")]
    public AudioSource tiresScreeachingAudioSource;
    public AudioSource engineAudioSourse;
    public AudioSource carHitAudioAudioSource;
    

    public float desiredEnginePitch = 0.5f;
    public float tireScrechPitch = 0.5f;

    CarMove carMove;


    void Awake(){
        carMove = GetComponentInParent<CarMove>();
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UndateEngineSFX();
        UpdateTiresSreechingSFX();
    }

    void UndateEngineSFX(){
        float velocityMagnitude = carMove.GetVelocityMagnitude();
        float desiredEngineVolume = velocityMagnitude * 0.05f;
        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f,1.0f);
        engineAudioSourse.volume = Mathf.Lerp(engineAudioSourse.volume, desiredEngineVolume, Time.deltaTime *10);
        desiredEnginePitch = velocityMagnitude * 0.2f;
        desiredEnginePitch = Mathf.Clamp(desiredEnginePitch, 0.5f,2f);
        engineAudioSourse.pitch = Mathf.Lerp(engineAudioSourse.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }
    void UpdateTiresSreechingSFX(){
        if(carMove.IsTireScreeching(out float lateraVelocity, out bool isBraking)){
            if(isBraking){

                tiresScreeachingAudioSource.volume = Mathf.Lerp(tiresScreeachingAudioSource.volume, 1.0f, Time.deltaTime * 10);
                tireScrechPitch = Mathf.Lerp(tireScrechPitch, 0.5f,Time.deltaTime*10);
            }
            else{
                tiresScreeachingAudioSource.volume = Mathf.Abs(lateraVelocity)* 0.05f;
                tireScrechPitch = Mathf.Abs(lateraVelocity)* 0.1f;
            }
        }
        else tiresScreeachingAudioSource.volume = Mathf.Lerp(tiresScreeachingAudioSource.volume,0,Time.deltaTime*10);   
    }

    void OnCollisionEnter2D(Collision2D collision2D){

        float relativeVelocity = collision2D.relativeVelocity.magnitude;
        float volume = relativeVelocity * 0.1f;

        carHitAudioAudioSource.pitch = Random.Range(0.95f,1.05f);

        carHitAudioAudioSource.volume = volume;

        if(!carHitAudioAudioSource.isPlaying)
            carHitAudioAudioSource.Play();
        
    }

}
