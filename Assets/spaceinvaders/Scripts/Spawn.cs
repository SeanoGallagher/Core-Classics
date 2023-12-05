using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
        public GameObject ships;
        private float timer=0;
        public float maxTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEmInBoy();
    }

    public void SpawnEmInBoy(){
           Instantiate(ships, transform.position, Quaternion.identity); 
    }

    void Update(){
    if(timer>=maxTime){
        SpawnEmInBoy();
        timer=0;
    }
        timer += Time.deltaTime;
    }
}
