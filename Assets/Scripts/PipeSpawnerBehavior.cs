using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerBehavior : MonoBehaviour
{
    [SerializeField] private float max_time = 1.75f;
    [SerializeField] private float height_range = 0.45f;
    [SerializeField] private GameObject pipe;   // we would assign the pipe prefab here

    private float timer;

    // Calling the Start funtion to create the first pipe
    private void Start()
    {
        SpawnPipe();
    }

    // Check if timer has exceeded the time limit to create a new pipe
    // if yes, create a new pipe, reset the timer to keep check
    // if no, simply update timer
    // time.deltaTime is the time taken to create the current frame
    private void Update()
    {
        if (timer > max_time) {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    // tansform is of the object this script is attached to
    // We use 'new' with Vector3 to create a new instance of this structure during the creation of new position
    // While creating it, we did not add the Z-axis value because for 2D projects, it's default value is zero
    // Quaternion.identity means no rotation to the new pipe being generated
    private void SpawnPipe()
    {
        Vector3 pipe_spawn_pos = transform.position + new Vector3(0, Random.Range(-height_range, height_range));
        GameObject new_pipe = Instantiate(pipe, pipe_spawn_pos, Quaternion.identity);

        Destroy(new_pipe, 9f);
    }

}
