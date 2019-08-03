using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_Y = 6f;
    public float rotate_speed;
    public float moving_platform_speed = 1.5f;

    public Vector3 scale;

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;
    private Rigidbody2D pBody;
    
    void Awake()
    {
        pBody = GetComponent<Rigidbody2D>();

        if (!moving_Platform_Left && !moving_Platform_Right)
        {
            if (Random.Range(0, 3) > 0)
            {
                rotate_speed = Random.Range(50f, 150f);
                pBody.angularVelocity = rotate_speed;
            }
        }

        if (!is_Spike)
        {
            if (moving_Platform_Right || moving_Platform_Left) scale = new Vector3(Random.Range(0.3f, 0.7f), 0.5f, 0f);
            else scale = new Vector3(Random.Range(0.15f, 1.5f), Random.Range(0.15f, 1.5f), 0f);
            
            transform.localScale = scale;
        }

        if (is_Breakable) anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.35f);
    }

    void DeactivateGameObject()
    {
        if (PauseMenu.SoundIsOn)
        {
            SoundManager.instance.IceBreakSound();
        }
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (is_Spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                if (PauseMenu.SoundIsOn)
                {
                    SoundManager.instance.GameOverSound();
                }
                GameManager.instance.RestartGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            GameObject.Find("Score Manager").GetComponent<Score>().AddToScore(1);
            if (is_Breakable)
            {
                if (PauseMenu.SoundIsOn)
                {
                    SoundManager.instance.LandSound();
                }
                anim.Play("Break");
            }

            if (is_Platform)
            {
                if (PauseMenu.SoundIsOn)
                {
                    SoundManager.instance.LandSound();
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-moving_platform_speed);
            }
            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(moving_platform_speed);
            }
        }
    }
}
