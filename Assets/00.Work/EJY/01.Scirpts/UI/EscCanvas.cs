using UnityEngine;

public class EscCanvas : UICanvas
{
    [SerializeField] private InputReader inputReader;

    protected override void Awake()
    {
        inputReader.OnESCEvent += HandleOnEscEvent;
    }

    private void OnDestroy()
    {
        inputReader.OnESCEvent -= HandleOnEscEvent;
    }

    private void HandleOnEscEvent()
    {
        if(_currentStatus == WindowStatus.Closed)
        {
            SetWindow(true);
            Time.timeScale = 0;
        }
        else
        {
            SetWindow(true);
            Time.timeScale = 1;
        }
    }
}
