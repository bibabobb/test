using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    playerStats stats;
    // PlayerComponents components;

    public void test(){
        Debug.Log(stats.state);
    }
    public void Start(){
        // components = new  PlayerComponents(this);
        // Debug.Log(components.spriteRenderer.name);
        
        // components.rigidbody.mass = 100
    }

    public void Update(){

    }
}
