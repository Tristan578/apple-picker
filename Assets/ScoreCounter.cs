using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    public TMP_Text uiText;

    void Update()
    {
        // null check
        if (uiText != null)
        {
            uiText.text = score.ToString("#,0");
        }
    }
}
