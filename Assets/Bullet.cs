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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if(player != null)
        {
            player.bullet_count -= 1;
        } 
    }

    public void SetUp(Vector3 dir)
    {
        //Get rreference to rigidbody.
        rb = GetComponent<Rigidbody2D>();

        //Set starting velocity of bullet to make it travel upwards.
        rb.velocity = dir * 500 * Time.fixedDeltaTime;
    }
}
