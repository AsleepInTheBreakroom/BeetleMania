using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get rreference to rigidbody.
        rb = GetComponent<Rigidbody2D>();

        //Set starting velocity of bullet to make it travel upwards.
        rb.velocity = Vector3.up * 500 * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        player.bullet_count -= 1;
    }
}
