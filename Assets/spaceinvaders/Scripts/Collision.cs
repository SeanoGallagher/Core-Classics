using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Collision : MonoBehaviour
{

    ShipMovement SM; 
    

    // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.FindGameObjectWithTag("Ships").GetComponent<ShipMovement>();
    }


    // Update is called once per frame
 private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EndBoundary")
        {
            SceneManager.LoadScene("SI End");
        }

        if (collision.gameObject.tag == "Boundary")
        {
            SM.move();
        }
    }
}
