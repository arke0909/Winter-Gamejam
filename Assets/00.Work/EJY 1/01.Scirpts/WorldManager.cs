using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;
    public GameObject player;
   
    private void Awake()
    {
        instance = this;

    }

    public Vector3 GetVector3()
    {
        return player.transform.position;
    }
}
