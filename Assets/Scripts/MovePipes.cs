using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipes : MonoBehaviour
{
    [SerializeField] private float pipe_speed = 0.65f;

    private void Update()
    {
        transform.position += Vector3.left * pipe_speed * Time.deltaTime;
        // the transform is of the GameObject this script is attached to
        // Vector3 is (x,y,z)
        // Vector3.left is one unit movement to the left (x-axis)
        // Time.deltaTime is the time taken to render the single current frame
    }
}
