using UnityEngine;

public class Brick : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.y < 0f) // viewportPos.y > 1f
        {
            Destroy(gameObject);
        }
    }
}
