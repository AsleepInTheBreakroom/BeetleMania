using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    //Score
    public int current_score = 0;
    private int point_value = 1;

    //Chain
    private float chain_timer = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chain_timer > 0)
        {
            chain_timer -= Time.deltaTime;
        }
    }

    public void AddPoints()
    {
        //Rest points if timer couinted down.
        if(chain_timer <= 0)
        {
            point_value = 1;
        }
        
        //Continue the chain by reseting the timer.
        chain_timer = 0.5f;
        
        current_score += point_value;

        point_value *= 2;

        point_value = Mathf.Min(point_value, 9999);

        Debug.Log(current_score);

    }
}
