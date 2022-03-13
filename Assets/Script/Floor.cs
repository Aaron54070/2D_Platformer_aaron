using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    public int Respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Respawn);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("r")) { //If you press R
         SceneManager.LoadScene("Level 1"); //Load scene called Game
     }
    }
}
