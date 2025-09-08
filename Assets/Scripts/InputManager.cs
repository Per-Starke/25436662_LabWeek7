using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject item; 
    private Tweener tweener;

    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tweener.AddTween(
                item.transform,
                item.transform.position,
                new Vector3(-2.0f, 0.5f, 0.0f),
                1.5f
            );
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            tweener.AddTween(
                item.transform,
                item.transform.position,
                new Vector3(2.0f, 0.5f, 0.0f),
                1.5f
            );
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            tweener.AddTween(
                item.transform,
                item.transform.position,
                new Vector3(0.0f, 0.5f, -2.0f),
                0.5f
            );
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            tweener.AddTween(
                item.transform,
                item.transform.position,
                new Vector3(0.0f, 0.5f, 2.0f),
                0.5f
            );
        }
    }
}

