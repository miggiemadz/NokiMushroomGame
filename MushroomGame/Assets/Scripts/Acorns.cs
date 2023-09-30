using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Acorns : MonoBehaviour
{
    public GameObject Noki;
    private float nutPosition;
    public float nutTweenHeight;
    public float nutTweenTime;
    public int acornsCount;

    private void Start()
    {
        nutPosition = gameObject.transform.position.y;
        Tween();
    }

    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameUI.instance.IncreaseAcorns(acornsCount);
        }
    }

    private void Tween()
    {
        LeanTween.moveLocalY(gameObject, nutPosition - nutTweenHeight, nutTweenTime).setLoopPingPong();
    }
}
