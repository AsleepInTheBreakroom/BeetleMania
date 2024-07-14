using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawer : MonoBehaviour
{
    [HideInInspector] public int number_of_shells = 0;
    public GameObject shell;
    private float shell_spawn_time = 0.35f;
    private float shell_spawn_timer = 0;
    private int max_shell_spawns = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        shell_spawn_timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(number_of_shells < max_shell_spawns)
        {
            if (shell_spawn_timer > 0)
            {
                shell_spawn_timer -= Time.deltaTime;

            }
            else SpawnShell();
        }
    }

    private void SpawnShell()
    {
        GameObject new_shell = Instantiate(shell);

        new_shell.GetComponent<Shell>().spawner = this;

        new_shell.transform.position = new Vector3(Random.Range(-7f, 7f), 6.5f, 0);

        number_of_shells += 1;

        shell_spawn_timer = shell_spawn_time;
    }
}
