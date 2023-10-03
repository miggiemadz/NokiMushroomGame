using System;
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
    public int maxHealth;
    public int mushroomDecayCount;
    public Byte mushroomDecayColor;

    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        acornCountText.text = "x" + currentAcorns.ToString();
        mushroomDecayCount = healthMushrooms.Length - 1;
        maxHealth = healthMushrooms.Length * 5;
        currentHealth = maxHealth;
        mushroomDecayColor = 255;
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

        if (currentHealth >= 0 && currentHealth % 5 == 0 && currentHealth < maxHealth)
        {
            healthMushrooms[mushroomDecayCount].color = Color.black;
            mushroomDecayCount -= 1;
            mushroomDecayColor = 255;
        }
        else if (currentHealth >= 0 && currentHealth % 5 != 0 && currentHealth < maxHealth)
        {
            mushroomDecayColor -= 51;
            healthMushrooms[mushroomDecayCount].color = new Color32(mushroomDecayColor, mushroomDecayColor, mushroomDecayColor, 255);
        }
    }
}
