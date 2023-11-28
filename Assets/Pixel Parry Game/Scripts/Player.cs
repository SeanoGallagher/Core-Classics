using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public FighterAgent enemy;

    public PPGameController controller;

    public Vector3 startingLocalPosition;

    public bool playerControlled = true;

    public float moveSpeed = 5f;
    
    public float attackCooldown = .1f;
    public float attackRange = 0.9f;
    public float timeSinceAttack = 0;

    

    private Rigidbody2D rb;
    private Vector2 moveVector;

    private void Start()
    {
        // Set Rigid Body
        rb = GetComponent<Rigidbody2D>();
        timeSinceAttack = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        // The movement vector is set to the player input
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = 0;

        if (timeSinceAttack < attackCooldown)
        {
            timeSinceAttack += Time.deltaTime;
        }

        // if the attack command was pressed Start the Attack
        bool attacked = Input.GetMouseButtonDown(0);
        if (timeSinceAttack >= attackCooldown && attacked)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if(playerControlled)
        {
            rb.velocity = moveVector * moveSpeed;

            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -6f, 6f), transform.localPosition.y, transform.localPosition.z);
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
        timeSinceAttack = 0;
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        if (hitEnemies.Length > 0)
        {
            Debug.Log("Hit");
            GameWon();
        }
    }
    private void GameWon()
    {
        controller.PlayerWon();
    }
    public void GameOver()
    {
        controller.AiWon();
    }
}
