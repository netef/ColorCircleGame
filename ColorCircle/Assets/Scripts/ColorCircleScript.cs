using UnityEngine;

public class ColorCircleScript : MonoBehaviour
{
    void Update() => transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
}
