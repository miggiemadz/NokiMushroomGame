using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using Unity.Properties;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public GameObject deathScrene;

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
            ManageHealth(-1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ManageHealth(1);
        }

        if (currentHealth <= 0)
        {
            deathScrene.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }


    public void IncreaseAcorns(int value)
    {
        currentAcorns += value;
        acornCountText.text = "x" + currentAcorns.ToString();
    }

    public void ManageHealth(int value)
    {
        if (value > 0 && currentHealth < maxHealth)
        {
            currentHealth += value;
        }
        if (value < 0 && currentHealth > 0)
        {
            currentHealth += value;
        }

        if (currentHealth % 5  == 0)
        {
            if  (value > 0)
            {
                healthMushrooms[mushroomDecayCount].color = Color.white;
                mushroomDecayCount += value;
                mushroomDecayColor = 0;
            }
            else if (value < 0)
            {
                healthMushrooms[mushroomDecayCount].color = Color.black;
                mushroomDecayColor = 255;
                mushroomDecayCount += value;
            }
        }
        else
        {
            if (value > 0)
            {
                if (mushroomDecayColor == 255)
                {
                    mushroomDecayCount += value;
                    mushroomDecayColor = 0;
                }
                mushroomDecayColor += 51;
                healthMushrooms[mushroomDecayCount].color = new Color32(mushroomDecayColor, mushroomDecayColor, mushroomDecayColor, 255);
            }
            else if (value < 0)
            {
                if(mushroomDecayColor == 0)
                {
                    mushroomDecayCount += value;
                    mushroomDecayColor = 255;
                }
                mushroomDecayColor -= 51;
                healthMushrooms[mushroomDecayCount].color = new Color32(mushroomDecayColor, mushroomDecayColor, mushroomDecayColor, 255);
            }
        }

        Debug.Log(currentHealth + ", " + mushroomDecayCount + ", " + mushroomDecayColor);
    }
}
