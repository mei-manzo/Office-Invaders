using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float yTopRange = 3;
    private float yBottomRange = 0;
    private float xRange = 49;
    private float zRange = 49;
    private float zBottom = -1;
    public void Move(Vector2 direction)
    {
        transform.position += (transform.forward * direction.x * Time.deltaTime 
            + transform.right * direction.y * Time.deltaTime);

        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
    if(transform.position.x> xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

    if(transform.position.z < zBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottom);
        }
    if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    if(transform.position.y < yBottomRange)
        {
            transform.position = new Vector3(transform.position.x, yBottomRange, transform.position.z);
        }
    if(transform.position.y > yTopRange)
        {
            transform.position = new Vector3(transform.position.x, yTopRange, transform.position.z);
        }
    }
    
}
