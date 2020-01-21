using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Sprite[] lifes;
    public Image DisplayImage;
    public int score;
    public Text score_text;

    public void UpdateLive(int currentLives)
    {
        DisplayImage.sprite = lifes[currentLives];
    }
    public void UpdateScore()
    {
        score++;
        score_text.text = "Score : " + score;
    }
}
