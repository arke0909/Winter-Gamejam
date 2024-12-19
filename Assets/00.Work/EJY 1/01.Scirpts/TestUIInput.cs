using UnityEngine;

public class TestUIInput : MonoBehaviour
{
    [SerializeField] GameObject setting;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            setting.SetActive(true  );
    }
}
