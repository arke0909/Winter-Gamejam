using UnityEngine;

public abstract class EnemyDecision : MonoBehaviour
{
    protected EnemyBrain _brain;
    [SerializeField] private EnmyState nextStste;
    public EnmyState NextStste { get { return nextStste; } }

    internal void Init(EnemyBrain brain)
    {
        _brain = brain;
    }

    public abstract bool MakeDecision();
}
