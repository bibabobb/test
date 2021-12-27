using UnityEngine;

public class PlayerComponents {


    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    CapsuleCollider2D capsuleCollider;
    public Player player;

    public PlayerComponents(){

        this.rigidBody = player.gameObject.GetComponent<Rigidbody2D>();
        this.spriteRenderer = player.gameObject.GetComponent<SpriteRenderer>();
        this.capsuleCollider = player.gameObject.GetComponent<CapsuleCollider2D>();
        this.boxCollider = player.gameObject.GetComponent<BoxCollider2D>();
    }
    

    // public Rigidbody2D rigidbody
    // {
    //     get { return _rigidBody; }
        
    // }
    

}

