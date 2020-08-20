﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }
    public GameObject[] obstacles;
    public GameObject[] collectibles;
    public GameObject player;
    public GameObject deathEffect;
    void Awake() => Instance = this;

    public void CreateObstacle()
    {
        switch (Random.Range(0, obstacles.Length))
        {
            case 0:
                Instantiate(obstacles[0], player.transform.position + Vector3.up * 10, Quaternion.identity);
                break;
            default:
                Instantiate(obstacles[obstacles.Length - 1], player.transform.position + Vector3.up * 10, Quaternion.identity);
                break;
        }
    }
    public void CreateCollectible()
    {
        switch (Random.Range(0, collectibles.Length))
        {
            case 0:
                Instantiate(collectibles[0], player.transform.position + Vector3.up * 7, Quaternion.identity);
                break;
            default:
                Instantiate(collectibles[collectibles.Length - 1], player.transform.position + Vector3.up * 7, Quaternion.identity);
                break;
        }
    }

    public void GameOver(bool showEffect)
    {
        if (showEffect)
            Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        Destroy(player.gameObject);
        AudioManagerScript.Instance.PlayDieSound();
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(3);
        DestroyImmediate(UIManagerScript.Instance.gameObject);
        DestroyImmediate(AudioManagerScript.Instance.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DestroyImmediate(gameObject);
    }
}
