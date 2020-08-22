using UnityEngine;

public class ColorCircleScript : MonoBehaviour
{
    public float rotationVelocity = 100;
    void Update() => transform.Rotate(new Vector3(0, 0, rotationVelocity * Time.deltaTime));
    void OnBecameInvisible() => Destroy(gameObject);
    public void ReverseSpinningDirection() => rotationVelocity *= -1;
    public void ChangeCircleSize() => transform.localScale *= 1.2f;
}
