using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class StageUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int nextSceneIndex;
    
    private Image image;
    
    public UnityEvent OnClick;
    
    [field: SerializeField] public bool IsOpen { get; private set; }

    public void Initialize()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.7f);
        IsOpen = false;
    }

    public void Open()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        IsOpen = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsOpen == false) return;

        OnClick?.Invoke();
        Debug.Log(nextSceneIndex);
        // SceneManager.LoadScene(nextSCeneIndex);
    }
}
