using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    private Vector3 moveDirection;

    void Update()
    {
        // 입력받은 방향
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        // 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
