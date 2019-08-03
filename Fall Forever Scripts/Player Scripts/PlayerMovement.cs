using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 5f;
    public float jumpSpeed = 8f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    public void LeftTap()
    {
        myBody.velocity = new Vector2(-moveSpeed, jumpSpeed);
        if (PauseMenu.SoundIsOn)
        {
            SoundManager.instance.BounceSound();
        }
    }

    public void RightTap()
    {
        myBody.velocity = new Vector2(moveSpeed, jumpSpeed);
            if (PauseMenu.SoundIsOn)
            {
                SoundManager.instance.BounceSound();
            }
    }

    public void PlatformMove(float deltaX)
    {
        myBody.velocity = new Vector2(myBody.velocity.x + deltaX, myBody.velocity.y);
    }
    
}
