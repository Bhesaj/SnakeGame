using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handlerovement : MonoBehaviour
{
    public Rigidbody2D rb_handle;
    public Vector2 inputvar;

    // Start is called before the first frame update
    void Start()
    {
        rb_handle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // rb_handle.position = new Vector2(-0.58f, 0.77f);

        if (rb_handle.position.x > 1.4f)
        {
          //  rb.velocity = new Vector2(5.0f, 0.0f);
        }

        if (rb_handle.position.x < -1f)
        {
           // rb.velocity = new Vector2(-5.0f, 0.0f);
        }

        if (rb_handle.position.y < 1.1f)
        {
            //rb.velocity = new Vector2(0.0f, 5.0f);
        }

        if (rb_handle.position.y < -0.5f)
        {
           // rb.velocity = new Vector2(0.0f, -5.0f);
        }
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position =  objPosition;
        
    }

    void OnCollisionEnter2D(Collision2D limit)
    {
        if (limit.transform.name == "controller2" || limit.transform.name == "controller")
        {
            Debug.Log("limit");
            rb_handle.velocity = new Vector2(0, 0);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.name == "Up")
        {
            inputvar = new Vector2(0, 1);
        }

        if (other.transform.name == "Down")
        {
            inputvar = new Vector2(0, -1);
        }

        if (other.transform.name == "Left")
        {
            inputvar = new Vector2(-1, 0);
        }

        if (other.transform.name == "Right")
        {
            inputvar = new Vector2(1, 0);

        }
    }

}

