using UnityEngine;

public class Confiner : MonoBehaviour
{
    [SerializeField] private Collider2D _confiningCollider;
    [SerializeField] private Collider2D _targetCollider;

    private void LateUpdate()
    {
        KeepTargetInsideBounds();
    }

    private void KeepTargetInsideBounds()
    {
        Bounds confinerBounds = _confiningCollider.bounds; 
        Bounds targetBounds = _targetCollider.bounds; 
        Vector3 targetPosition = _targetCollider.transform.position;

        // ���� ���� ���� ��ġ ����
        float clampedX = Mathf.Clamp(
            targetPosition.x,
            confinerBounds.min.x + (targetBounds.extents.x),
            confinerBounds.max.x - (targetBounds.extents.x)
        );

        float clampedY = Mathf.Clamp(
            targetPosition.y,
            confinerBounds.min.y + (targetBounds.extents.y),
            confinerBounds.max.y - (targetBounds.extents.y)
        );

        _targetCollider.transform.position = new Vector3(clampedX, clampedY, targetPosition.z);
    }
}
