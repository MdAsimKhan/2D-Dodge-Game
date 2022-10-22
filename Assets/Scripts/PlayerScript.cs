using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 4f;
    public Text LifeText;
    public float minX = Screen.width / 2, maxX = Screen.width / 2;
    public AudioSource bgm, death;
    public AudioClip clip;
    public Sprite newSprite;
    float speedCopy;
    int life = 3;
    bool dontMove = true, moveLeft = false;
    int score = CollectorScript.Score;
    Vector2 currentPos;
    private void Start()
    {
        currentPos = transform.position;
        speedCopy = speed;
    }

    private void Update()
    {
        HandleMove();
    }

    void HandleMove()
    {
        if (dontMove)
            StopMoving();
        else
        {
            if (moveLeft)
                MoveLeft();
            else if (!moveLeft)
                MoveRight();
        }
    }

    void StopMoving()
    {
        speed = 0f;
    }

    public void AllowMovement(bool movement)
    {
        speed = speedCopy;
        dontMove = false;
        moveLeft = movement;
    }

    public void DontAllowMovement()
    {
        dontMove = true;
    }

    void MoveLeft()
    {
        currentPos.x -= speed * Time.deltaTime;
        if (currentPos.x > maxX)
            currentPos.x = maxX;
        if (currentPos.x < minX)
            currentPos.x = minX;
        transform.position = currentPos;
    }

    void MoveRight()
    {
        currentPos.x += speed * Time.deltaTime;
        if (currentPos.x > maxX)
            currentPos.x = maxX;
        if (currentPos.x < minX)
            currentPos.x = minX;
        transform.position = currentPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("demon"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            collision.gameObject.transform.localScale = new Vector3(0f,0f,0f);
            if (life > 0)
            {
                death.PlayOneShot(clip, 1f);
                life -= 1;
                LifeText.text = "Life: " + life;
                score--;
            }
            if (life == 0)
            {
                if(score < 0)
                {
                    score = 0;
                }
                bgm.Stop();
                death.PlayOneShot(clip, 1f);
                SceneManager.LoadScene("Scorecard");
            }
            collision.tag = "Untagged";
        }
    }
}
