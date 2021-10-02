using UnityEngine;
using DG.Tweening;

public class Window : MonoBehaviour
{
    const float TWEEN_DURATION = 0.1f;
    [SerializeField] bool openOnAwake = false;

    void Awake()
    {
        if (openOnAwake) transform.localScale = Vector3.one;
        else transform.localScale = new Vector3(1, 0, 1);
    }

    public void Open()
    {
        transform.DOScaleY(1f, TWEEN_DURATION);
    }

    public void Close()
    {
        transform.DOScaleY(0f, TWEEN_DURATION);
    }
}
