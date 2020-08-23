﻿using UnityEngine;

public class PlayerLogicScript : MonoBehaviour
{
    public GameObject deathEffect;
    public Color[] colors;
    private int currentColorIndex = -1;
    private SpriteRenderer sr;
    private string[] colorLabels = { "cyan", "yellow", "red", "magenta" };

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        RandomColor();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("collectible"))
        {
            RandomColor();
            Destroy(other.gameObject);
            AudioManagerScript.Instance.PlayPickupSound();
            return;
        }
        else if (other.CompareTag("goal")) GameManagerScript.Instance.Goal(other, this);
        else if (!gameObject.CompareTag(other.tag)) GameManagerScript.Instance.GameOver(true);
    }

    public void RandomColor()
    {
        int index = Random.Range(0, colors.Length);
        if (currentColorIndex == index)
            if (index == colors.Length - 1) index--;
            else index++;
        sr.color = colors[index];
        gameObject.tag = colorLabels[index];
        currentColorIndex = index;
    }
    void OnBecameInvisible() => GameManagerScript.Instance.GameOver(false);
}
