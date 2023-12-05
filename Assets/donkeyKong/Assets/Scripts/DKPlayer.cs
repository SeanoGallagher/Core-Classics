using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DKPlayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] runSprites;
    public Sprite climbSprite;
    private  int spriteIndex;

    private new Rigidbody2D rigidbody; 
    private new Collider2D collider;

    private Collider2D[] results;
    private Vector2 direction;

    public float moveSpeed = 1f;
    public float jumpStrength = 1f ; 

    private bool grounded;
    private bool climbing;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        results = new Collider2D[4];

    }
    private void OnEnable()
    {
        InvokeRepeating(nameof(AnimateSprite), 1f/12f , 1f/12f );
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    private void CheckCollision()
    {
        grounded = false;
        climbing =false;

    Vector2 size = collider.bounds.size;
    size.y += 0.1f;
    size.x /= 2f; 
   int amount =  Physics2D.OverlapBoxNonAlloc(transform.position,size, 0f, results );

   for (int i = 0; i < amount; i++) 
   {
    GameObject hit = results[i].gameObject;

    if(hit.layer == LayerMask.NameToLayer("Ground") ){
        grounded = hit.transform.position.y < (transform.position.y - 0.5f);
        Physics2D.IgnoreCollision(collider,results[i], !grounded);
    }
    else if (hit.layer == LayerMask.NameToLayer("Ladder")){
        climbing = true;
    }

   }
    }


    private void Update()
    {
        CheckCollision();

        if(climbing)
        {
            direction.y = Input.GetAxis("Vertical") *moveSpeed;

        }
       else if (grounded && Input.GetButtonDown("Jump")){
            direction = Vector2.up * jumpStrength;
        }else {
            direction += Physics2D.gravity * Time.deltaTime;
        }
        
        
        
        direction.x = Input.GetAxis("Horizontal") * moveSpeed;
        if (grounded){
        direction.y = Mathf.Max(direction.y , -1f);
        }
        //changing the direction mairo is looking 
        if (direction.x > 0f ){
            transform.eulerAngles = Vector3.zero;
        }else if (direction.x < 0f){
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
       
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * Time.fixedDeltaTime);
    }


    private void AnimateSprite()
    {
if (climbing){
    spriteRenderer.sprite = climbSprite;

}
else if(direction.x != 0f) {
    spriteIndex++;
    if(spriteIndex >= runSprites.Length ){
        spriteIndex = 0;
    }
    spriteRenderer.sprite = runSprites[spriteIndex];
}
    }


    //when the player hits the barrel lose a life 
    //when the player reaches the objective ...completes the level 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            DKScore.DK_score+=100;
            SceneManager.LoadScene("Dk End");
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            enabled = false;
            //change scene to "Losescene
            SceneManager.LoadScene("Dk End");

        }
    }
}
