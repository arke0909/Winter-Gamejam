using UnityEngine;

public enum WindowStatus
{
    Closed, Open
}

public abstract class UICanvas : MonoBehaviour
{
    protected WindowStatus _currentStatus;
    protected CanvasGroup _canvasGroup;

    protected virtual void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        SetWindow(false);
    }

    public void SetWindow(bool isOpen)
    {
        float alpha = isOpen ? 1.0f : 0.0f;
        _canvasGroup.alpha = alpha;
        _canvasGroup.interactable = isOpen;
        _canvasGroup.blocksRaycasts = isOpen;
    }
}
