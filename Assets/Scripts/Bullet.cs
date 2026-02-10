using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    Rigidbody2D m_rb;
    GameController m_gc;  
    AudioSource aus;
    public AudioClip hitSound;
    //public GameObject hitVfx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
        aus = FindAnyObjectByType<AudioSource>();
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            m_gc.ScoreIncreament();
            if(aus && hitSound != null )
            {
                aus.PlayOneShot(hitSound);
            }
            //if(hitVfx != null)
            //{
            //    Instantiate(hitVfx,col.transform.position,Quaternion.identity);
            //}
            Destroy(gameObject);
            Destroy(col.gameObject); 
            Debug.Log("Viên đạn đã va chạm với enemy");
        }
    }

}
