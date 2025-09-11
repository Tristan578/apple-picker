using UnityEngine;
using System.Collections;
using UnityEngine;
using TMPro; 

public class HighScore : MonoBehaviour
{
    //The type is TMP_Text (capital T)
    static private TMP_Text _UI_TEXT;
    static private int _SCORE = 0;

    void Awake()
    {
        //Use GetComponent<TMP_Text>()
        _UI_TEXT = GetComponent<TMP_Text>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        // PlayerPrefs.SetInt is Handled by the SCORE property
    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs.")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1000");
        }
    }
}