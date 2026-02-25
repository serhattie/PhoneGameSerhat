using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] InputSys inputSys;
    private DodgerAttributes attributes;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attributes = new DodgerAttributes();
    }

    void Update()
    {
        float moveDir = 0f;
        Vector2 screenPos;

        if (inputSys.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0f));
            if (touchPos.x < 0)
            {
                moveDir = -1f;
            }
            else
            {
                moveDir = 1f;
            }
        }

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

        if ((viewportPos.x <= 0f && moveDir < 0f) || (viewportPos.x >= 1f && moveDir > 0f))
        {
            moveDir = 0f;
        }

        rb.linearVelocity = new Vector2(moveDir * moveSpeed, rb.linearVelocity.y);
    }

    public DodgerAttributes GetAttributes()
    {
        return attributes;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            int newHealth = attributes.GetCurrentHealth() - 1;
            attributes.SetCurrentHealth(newHealth);

            if (attributes.GetCurrentHealth() <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}