using UnityEngine;

public class UISetting : MonoSingleton<UISetting>
{
    
    private void Awake()
    {
        DontDestroyOnLoad(this);

    }
}
