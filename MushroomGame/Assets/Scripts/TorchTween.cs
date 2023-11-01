using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchTween : MonoBehaviour
{
    [SerializeField] private Light2D torchLight;

    private bool isIncreasing = true;
    private float timeElapsed;
    private float duration = 2f;
    [SerializeField] private float lightRadiusSmall = .35f;
    [SerializeField] private float lightRadiusLarge = 2.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isIncreasing)
        {
            if (timeElapsed < duration)
            {
                torchLight.intensity = Mathf.Lerp(lightRadiusSmall, lightRadiusLarge, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                torchLight.intensity = lightRadiusLarge;
                isIncreasing = !isIncreasing;
                timeElapsed = 0;
            }
        }

        if (!isIncreasing)
        {
            if (timeElapsed < duration)
            {
                torchLight.intensity = Mathf.Lerp(lightRadiusLarge, lightRadiusSmall, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                torchLight.intensity = lightRadiusSmall;
                isIncreasing = !isIncreasing;
                timeElapsed = 0;
            }
        }

        Debug.Log(isIncreasing + ", " + timeElapsed);
    }
}
