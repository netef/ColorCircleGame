using UnityEngine;

public class PlayerLogicScript : MonoBehaviour
{
    public GameObject deathEffect;
    public Color[] colors;
    private SpriteRenderer sr;

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
            return;
        }
        else if (other.CompareTag("goal"))
        {
            UIManagerScript.Instance.IncreaseScore();
            GameManagerScript.Instance.CreateObstacle();
            if (Random.Range(0, 2) == 0)
                GameManagerScript.Instance.CreateCollectible();
            other.enabled = false;
        }
        else if (!gameObject.CompareTag(other.tag)) GameOver();
    }
    void GameOver()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void RandomColor()
    {
        // dont allow same color
        switch (Random.Range(0, 4))
        {
            case 0:
                sr.color = colors[0];
                gameObject.tag = "cyan";
                break;
            case 1:
                sr.color = colors[1];
                gameObject.tag = "yellow";
                break;
            case 2:
                sr.color = colors[2];
                gameObject.tag = "red";
                break;
            default:
                sr.color = colors[3];
                gameObject.tag = "magenta";
                break;
        }
    }
}
