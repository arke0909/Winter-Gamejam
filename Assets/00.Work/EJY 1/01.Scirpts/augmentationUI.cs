using UnityEngine;

public class augmentationUI : MonoBehaviour
{
    RectTransform rect;
    Item[] items;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
        Hide();
    }

    public void Show()
    {
        rect.localScale = Vector3.one;
        NextLevel();
        Time.timeScale = 0f;
    }
    public void Hide()
    {
        Time.timeScale = 1f;
        rect.localScale = Vector3.zero;
    }
    // private void Update() // Only test
    // {
    //     if (Input.GetKeyDown(KeyCode.G))
    //         Show();
    //     if(Input.GetKeyDown(KeyCode.S))
    //         Hide();
    // }

    void NextLevel()
    {
        foreach(Item item in items)
        {
            item.gameObject.SetActive(false);
        }

        int[] ran = new int[3];
        while(true)
        {
            ran[0] = Random.Range(0, items.Length);
            ran[1] = Random.Range(0, items.Length);
            ran[2] = Random.Range(0, items.Length);
            if (ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2]) 
                break;
        }

        for(int i = 0; i < ran.Length; i++)
        {
            Item rItem = items[ran[i]];
            

            
            if(rItem.level >= 5)
            {
                rItem.gameObject.SetActive(false);
                //������ �����϶� �־���ϴµ� ��������.. �𸣰���
            }
            else
            {
                rItem.gameObject.SetActive(true);
            }
        }
    }
}
