using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private Rigidbody2D rb;

    [HideInInspector] public ShellSpawer spawner;

    private bool was_hit = false;
    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * Random.Range(-1f, 1f) * 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision Enter: " + collision.gameObject.tag);
        if(collision.gameObject.name == "Bottom Wall")
        {
            rb.velocity = new Vector2(rb.velocity.x, 27);
        }

        if(collision.gameObject.name == "Left Wall" || collision.gameObject.name == "Right Wall")
        {
            if(Mathf.Abs(rb.velocity.x) < 0.5f)
            {
                rb.velocity = new Vector2(-Mathf.Sign(rb.velocity.x) * 2, rb.velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger Enter: " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Bullet" && !was_hit)
        {
            was_hit = true;
            Destroy(collision.gameObject);

            for(var i = 0; i < 5; i++)
            {
                GameObject new_bullet = Instantiate(bullet);
                new_bullet.transform.position = transform.position;
                Vector3 bullet_dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
                new_bullet.GetComponent<Bullet>().SetUp(bullet_dir);

                Destroy(new_bullet.gameObject, 0.25f);
            }

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        spawner.number_of_shells -= 1;
    }
}
