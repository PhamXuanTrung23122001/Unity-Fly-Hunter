using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public GameObject bullet;

    public Transform shootingPoint;

    public AudioSource aus;
    public AudioClip shootingSound;


    GameController m_gc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        //vector3.right = (1,0,0)
        if((xDirection < 0 && transform.position.x <= -8.3f) || xDirection > 0 && transform.position.x >= 8.3f)
        {
            return;
        }
        transform.position += Vector3.right * moveSpeed * xDirection * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if(bullet != null && shootingPoint != null)
        {
            if(aus && shootingPoint !=null)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(bullet, shootingPoint.position, Quaternion.Euler(0,0,90));
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            m_gc.SetGameOverState(true);
            Destroy(col.gameObject);
            Debug.Log("Enemy đã va chạm vào player, trò chơi kết thúc");
        }
    }
}
