using UnityEngine;

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
        else if (other.CompareTag("goal"))
        {
            UIManagerScript.Instance.IncreaseScore();
            GameManagerScript.Instance.CreateObstacle();
            AudioManagerScript.Instance.PlaySuccessSound();
            if (Random.Range(0, 2) == 0) GameManagerScript.Instance.CreateCollectible();
            (other.GetComponent("Halo") as Behaviour).enabled = true;
            switch (Random.Range(0, 3))
            {
                case 0:
                    other.GetComponent<ColorCircleScript>().ReverseSpinningDirection();
                    StartCoroutine(UIManagerScript.Instance.ShowFloatingText("Reversed\nDirection!"));
                    break;
                case 1:
                    RandomColor();
                    StartCoroutine(UIManagerScript.Instance.ShowFloatingText("Color\nChanged!"));
                    break;
                default:
                    other.GetComponent<ColorCircleScript>().ChangeCircleSize();
                    StartCoroutine(UIManagerScript.Instance.ShowFloatingText("Size\nIncreased!"));
                    break;
            }
            other.enabled = false;
        }
        else if (!gameObject.CompareTag(other.tag)) GameManagerScript.Instance.GameOver(true);
    }

    void RandomColor()
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
