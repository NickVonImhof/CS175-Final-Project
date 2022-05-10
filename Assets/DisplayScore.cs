using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshPro text_score;

    // Update is called once per frame
    void Update()
    {
        text_score.text = "Highscore: " + Mathf.Floor(PlayerPrefs.GetInt("HighScore") / 1000);
    }
}
