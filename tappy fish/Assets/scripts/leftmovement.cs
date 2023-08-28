using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftmovement : MonoBehaviour

{
    public float speed;
    BoxCollider2D box;
    float groundwidth;
    float obstacleWidht;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundwidth = box.size.x;
        }
        else if (gameObject.CompareTag("obstacle"))
        {
          obstacleWidht = GameObject.FindGameObjectWithTag("column").GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemenager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        
        if (gameObject.CompareTag("ground"))
        {
            if (transform.position.x <= -groundwidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundwidth, transform.position.y);
            }
        }
        else if (transform.position.x < gamemenager.bottomLeft.x -  obstacleWidht)
        {
            Destroy(gameObject);
        }
    }
}
