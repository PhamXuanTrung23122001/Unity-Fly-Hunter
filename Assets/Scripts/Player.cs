using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
