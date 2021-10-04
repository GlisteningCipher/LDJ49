using UnityEngine;

public class BackgroundSway : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float horizontalSway = 10f;
    [SerializeField] float horizontalDuration = 10f;
    [SerializeField] float verticalSway = 5f;
    [SerializeField] float verticalDuration = 7f;

    Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float x = Mathf.Cos(Time.time * Mathf.PI * 2 / horizontalDuration) * horizontalSway / 2;
        float y = Mathf.Sin(Time.time * Mathf.PI * 2 / verticalDuration) * verticalSway / 2;
        transform.position = originalPosition + new Vector3(x, y);
    }
}
