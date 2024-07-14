using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    private Rigidbody2D rb;
    private Vector3 input_vec = Vector3.zero;
    public float speed = 300f;

    //Bullet
    public GameObject bullet;
    private float rate_of_fire = 0.05f; //In seconds.
    private float shoot_timer = 0f;
    [HideInInspector] public int bullet_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Get reference to rigidbody.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set input vector.
        input_vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        //Shooting
        if(Input.GetKeyDown(KeyCode.Space) && shoot_timer <= 0 && bullet_count < 5)
        {
            shoot_timer = rate_of_fire;
            
            SpawnBullet();
        }

        //Countdown shoot timer.
        if(shoot_timer > 0)
        {
            shoot_timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
       //Set velocity.
        rb.velocity = input_vec * speed * Time.fixedDeltaTime;
    }

    void SpawnBullet()
    {
        GameObject new_bullet = Instantiate(bullet);
        new_bullet.transform.position = transform.position;
        new_bullet.GetComponent<Bullet>().player = this;
        new_bullet.GetComponent<Bullet>().SetUp(Vector3.up);
        bullet_count += 1;
    }
}
