using UnityEngine;

public class Scripts : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D m_rb;
    GameController m_gc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //vector2.down = (0,-1)
        m_rb.linearVelocity = Vector2.down * moveSpeed ;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("DeathZone"))
        {
            m_gc.SetGameOverState(true);
            Destroy(gameObject);
            Debug.Log("Enemy đã va chạm với Deathzone!!! Trò chơi kết thúc!!!");
        }
    }
}
