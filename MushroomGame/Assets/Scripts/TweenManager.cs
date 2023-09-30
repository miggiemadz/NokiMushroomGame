using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenManager : MonoBehaviour
{
    [SerializeField] GameObject Nuts;

    // Start is called before the first frame update
    void Start()
    {
        TweenNuts();
    }


    void TweenNuts()
    {
        LeanTween.moveY(Nuts, -.2f, .7f).setLoopPingPong();
    }
}
