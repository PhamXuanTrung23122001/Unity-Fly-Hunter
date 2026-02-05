using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    Rigidbody2D m_rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,timeToDestroy);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //vector2.up = (0,1)
        m_rb.linearVelocity = Vector2.up * speed;

    }
    void Update()
    {

    }

}
