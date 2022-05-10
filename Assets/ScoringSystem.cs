
/*
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour{

    public TextMeshProUGUI scoreText;
    public int score;
    public float frameScore;
    public int highestScore;

    void Start() {
        score = 0;
        frameScore = 1f;
    }

    void Update(){

        frameScore += 1.001f;
        score += (int) frameScore;
        scoreText.GetComponent<Text>().text = "Score: " + score;
        

    }
    void OnDestroy(){
        if (score > highestScore){
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score;
    public float frameScore;
    public int highestScore;

    void Start()
    {
        score = 0;
        frameScore = 1f;
        highestScore = PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {

        frameScore += 1.001f;
        score += (int)frameScore;
        scoreText.text = "Score: " + Mathf.Floor(score / 1000);


    }
    void OnDestroy()
    {
        if (score > highestScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}