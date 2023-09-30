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

    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        acornCountText.text = "x" + currentAcorns.ToString();
    }

    public void IncreaseAcorns(int value)
    {
        currentAcorns += value;
        acornCountText.text = "x" + currentAcorns.ToString();
    }
}
