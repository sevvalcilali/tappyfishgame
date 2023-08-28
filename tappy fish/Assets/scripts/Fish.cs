using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle;
    int maxangle = 20;
    int minangle = -60;
    public Score score;
    bool touchedground;
    public gamemenager Gamemenager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public obstaclespawner obstacleSpawner;
    [SerializeField] private AudioSource swim,hit,point;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        // rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();

    }

    private void FixedUpdate()
    {
        FishRotation();
    }
    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && gamemenager.gameOver == false)
        {
            swim.Play();
            if (gamemenager.gameStarted == false)
            {
                _rb.gravityScale = 4f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                Gamemenager.GameHasStarted();
            }
        else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }

            


        }
    }
    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxangle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if (angle >= minangle)
            {
                angle = angle - 2;
            }
        }
        if (touchedground == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            // Debug.Log("scored!..");
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("column") && gamemenager.gameOver == false)
        { 
            FishDieEffect();
            Gamemenager.GameOver();
        }
    }
    void FishDieEffect ()
    {
        hit.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (gamemenager.gameOver == false)
            {
                //game over
                FishDieEffect();
                Gamemenager.GameOver();
                GameOver();
            }
            else {
                //game over(fish)
                GameOver();
            }


        }
    }
    void GameOver()
    {
        touchedground = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}