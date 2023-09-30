using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorns : MonoBehaviour
{
    private bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
