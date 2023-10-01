using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public TMP_Text acornCountText;
    public int currentAcorns = 0;

    public Image[] healthMushrooms;
    public int currentHealth;

    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        acornCountText.text = "x" + currentAcorns.ToString();
        currentHealth = 3;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ManageHealth(1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ManageHealth(-1);
        }

        Debug.Log(currentHealth);
    }


    public void IncreaseAcorns(int value)
    {
        currentAcorns += value;
        acornCountText.text = "x" + currentAcorns.ToString();
    }

    public void ManageHealth(int value)
    {
        currentHealth -= value;

        if (currentHealth >= 0 && currentHealth <= 3)
        {
            for (int i = 0; i < healthMushrooms.Length; i++)
            {
                if (i < currentHealth)
                {
                    healthMushrooms[i].color = Color.white;
                }
                else
                {
                    healthMushrooms[i].color = Color.black;
                }
            }
        }
    }
}
