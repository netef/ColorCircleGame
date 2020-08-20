using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManagerScript : MonoBehaviour
{

    private static UIManagerScript instance = null;
    public GameObject scoreText;
    private int score = 0;
    public static UIManagerScript GetInstance()
    {
        if (instance == null) instance = new UIManagerScript();
        return instance;
    }

    public void IncreaseScore()
    {
        Debug.Log("good");
        scoreText.GetComponent<TextMeshPro>().text = "Score: " + score;
    }
}
