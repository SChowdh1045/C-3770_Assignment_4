using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // The player's Transform
    public Vector3 offset = new Vector3(0f, 11f, -6f);

    void LateUpdate()
    {
        if (player != null)
        {
            // Set the camera position to follow the player with an offset
            transform.position = player.position + offset;
            
            // Make the camera look at the player
            transform.LookAt(player.position);
        }
    }
}
