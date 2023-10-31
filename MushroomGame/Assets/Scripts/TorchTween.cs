using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchTween : MonoBehaviour
{
    [SerializeField] private Light2D torchLight;

    private float lightRadiusSmall = .35f;
    private float lightRadiusLarge = 2f;
    [SerializeField] private float bloomTime;
    private float lightStrength;
    private float torchIntensity;

    void Start()
    {
        torchLight.intensity = lightRadiusSmall;
        
    }

    // Update is called once per frame
    void Update()
    {
        Tween();

    }

    private void Tween()
    {
        LeanTween.value(lightRadiusSmall, lightRadiusLarge, bloomTime);
    }
}
