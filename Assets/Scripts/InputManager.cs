using UnityEngine;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject item; 
    private Tweener tweener;
    private List<GameObject> itemList = new List<GameObject>();

    void Start()
    {
        tweener = GetComponent<Tweener>();
        itemList.Add(item);
    }

    void Update()
    {
        // Spacebar - clone the box
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone = Instantiate(item, new Vector3(0f, 0.5f, 0f), Quaternion.identity);
            itemList.Add(clone);
        }

        // movement keys - try to tween one box
        if (Input.GetKeyDown(KeyCode.A))
        {
            TryTween(new Vector3(-2.0f, 0.5f, 0.0f), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TryTween(new Vector3(2.0f, 0.5f, 0.0f), 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TryTween(new Vector3(0.0f, 0.5f, -2.0f), 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TryTween(new Vector3(0.0f, 0.5f, 2.0f), 0.5f);
        }
    }

    // loop over all items and try to start a tween
    private void TryTween(Vector3 endPos, float duration)
    {
        foreach (var obj in itemList)
        {
            if (tweener.AddTween(obj.transform, obj.transform.position, endPos, duration))
            {
                break; // only assign one tween
            }
        }
    }
}