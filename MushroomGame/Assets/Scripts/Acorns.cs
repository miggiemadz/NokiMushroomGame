using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Acorns : MonoBehaviour
{
    private bool isCollected = false;
    public GameObject Noki;
    private float nutPosition;
    public float nutTweenHeight;
    public float nutTweenTime;

    private void Start()
    {
        nutPosition = gameObject.transform.position.y;
        Tween();
    }

    void Update()
    {
        if (isCollected)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollected = true;
    }

    private void Tween()
    {
        LeanTween.moveLocalY(gameObject, nutPosition - nutTweenHeight, nutTweenTime).setLoopPingPong();
    }
}
