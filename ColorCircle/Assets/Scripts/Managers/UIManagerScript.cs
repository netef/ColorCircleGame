using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance { get; private set; }
    public GameObject scoreText;
    public GameObject explenationText;
    private int score = 0;

    void Awake() => Instance = this;
    public void IncreaseScore()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = ++score + "";
        if (score == 5) GameManagerScript.Instance.IncreaseDifficulty();
        if (score == 10) GameManagerScript.Instance.IncreaseDifficulty();
    }
    public IEnumerator ShowFloatingText(string text)
    {
        explenationText.GetComponent<TextMeshProUGUI>().text = text;
        explenationText.SetActive(true);
        yield return new WaitForSeconds(1);
        explenationText.SetActive(false);
    }


}
