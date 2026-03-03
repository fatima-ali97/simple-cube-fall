using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D mybody; 
    public float moveSpeed=1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() // used to move gameObjects with a rigid body
    { Move();
        
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            mybody.velocity = new Vector2(moveSpeed, mybody.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            mybody.velocity = new Vector2(-moveSpeed, mybody.velocity.y);
        }
       
    }

    public void PlatformMove(float x)
    {
        mybody.velocity = new Vector2(x, mybody.velocity.y);
    }
}
