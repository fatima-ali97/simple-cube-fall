using System;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float move_speed = 2f; 
    public float  bound_y = 6.0f;

    public bool moving_platform_left, moving_platform_right, is_breakable, is_spike, is_platform;


    private Animator anim;

    private void Awake()
    {
        if (is_breakable)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        Move(); 
        
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;


        if (temp.y >= bound_y){
            gameObject.SetActive(false);
        }

    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.35f);
    }
    
    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Player")
        {
            if (is_spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.restartGame(); 
            }
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_breakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            if (is_platform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    { // will be called every single frame as long as the player is standing on the platform
        if (target.gameObject.tag == "Player")
        {
            if (moving_platform_left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if (moving_platform_right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }
}
