using UnityEngine;

public class Area : MonoBehaviour
{
    public GameObject g;

    private void Update()
    {
        transform.position = g.transform.position;
    }
}
