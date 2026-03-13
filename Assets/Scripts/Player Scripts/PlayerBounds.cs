using System;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    
    public float min_x = -2.6f, max_x = 2.6f, min_y = -5.6f, max_y = 2.6f;
    private bool out_of_bounds;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        CheckBounds(); 
    }

    void CheckBounds()
    {
       Vector2 temp = transform.position;
       
       if (temp.x > max_x)
           temp.x = max_x;
       else if (temp.x < min_x)
           temp.x = min_x;
    transform.position = temp; // to reset these values back to the current position ; 
       if (temp.y < min_y)
       {
           if (!out_of_bounds)
           {
               out_of_bounds = true;
               
               SoundManager.instance.DeathSound();
               GameManager.instance.restartGame();
           }
       }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            
           
            SoundManager.instance.LandSound();
            GameManager.instance.restartGame();
        }
    }
}
