using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected bool _alreadyCollected;
    protected bool _canCollectable;
    public abstract void Collect(Transform transform, float magneticPower);
}
