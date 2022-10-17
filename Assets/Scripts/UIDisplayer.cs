using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplayer : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthBar;
    [SerializeField] Health playerHealth;


    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    public void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }



    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000"); // score yandaki gibi sýfýrlarla baþlar.
    }
}
