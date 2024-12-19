using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    private Vector3 moveDirection;

    void Update()
    {
        // �Է¹��� ����
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        // �̵�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
