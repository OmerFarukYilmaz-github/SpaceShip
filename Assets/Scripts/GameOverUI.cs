using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    public void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Your Score:\n"+scoreKeeper.GetScore().ToString();
    }

}
