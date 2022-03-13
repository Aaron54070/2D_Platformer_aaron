using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
  
    void Update () 
    {
        transform.position = new Vector3 (player.position.x, player.position.y, offset.z); // Camera follows the player with specified offset position
    }

}
