using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance { get; private set; }
    public GameObject scoreText;
    private static int score = 0;

    void Awake()
    {
        Instance = this;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }

    public void IncreaseScore() => scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + ++score;

}
