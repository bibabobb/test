using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerInputs : MonoBehaviour
{

    // Start is called before the first frame update

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    CapsuleCollider2D capsuleCollider;
    public float speed = 3f;
    public float jumpPower  = 60f;
    private int extraJump = 2;
    private int jumpCount;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb.mass = 1;
        capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {

        
    }

    void FixedUpdate() {
        movementLogic();
        jumpLogic();
    }
    
    private void movementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0){
            spriteRenderer.flipX = false;
        }
        else if (moveHorizontal < 0){
            spriteRenderer.flipX = true;
        }
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);


    }

    void jumpLogic()
    {
        if (isGround()){
            jumpCount = extraJump;

            // Debug.Log("ground");
            // Debug.Log(jumpCount);
        }
        if (Input.GetAxis("Jump") > 0 && jumpCount > 0 ){
            jumpCount--;
            // Debug.Log(jumpCount);
            jump();
        } else if (isGround() && Input.GetAxis("Jump") > 0 && jumpCount == 0){
            jump();
        }
    }

    void jump(){
        rb.AddForce(Vector2.up * jumpPower);
        // rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        Debug.Log("JUMP");
    }

    bool isGround()
    {   
        LayerMask layer = LayerMask.GetMask("Ground");
        Color rayColor;
        float distance = 2f;
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center,
                    Vector2.down,
                    capsuleCollider.bounds.extents.y * distance, layer);

        if (raycastHit.collider != null){
            rayColor = Color.white;
        } else {
            rayColor = Color.blue;
        } 
        // Debug.DrawRay(transform.position,
        //             transform.TransformDirection(Vector3.forward) * 10, rayColor,10f);
        // Debug.DrawRay(capsuleCollider.bounds.center,
        //              Vector2.down * (capsuleCollider.bounds.extents.y * distance),
        //              rayColor, 1f);
        // Debug.Log(boxCollider.bounds.center);
        // Debug.Log(Vector2.down);
        // Debug.Log(boxCollider.bounds.extents.y);
        // Debug.Log(raycastHit.collider != null);   
        return raycastHit.collider != null;
    }
}
