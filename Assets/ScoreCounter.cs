using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }
    void Update()
    {
        uiText.text = score.ToString("#,0");
    }
}
