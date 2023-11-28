using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class FighterAgent : Agent
{
    public Animator animator;
    public Transform attackPoint;
    public GameObject otherPlayerObject;
    private Player otherPlayer;

    public GameObject deathAnimation;

    public Vector3 startingLocalPosition;

    public float moveSpeed = 5f;

    public float attackCooldown = 3f;
    public float attackRange = 0.9f;
    public float timeSinceAttack = 0;

    private Rigidbody2D rb;
    private Vector2 moveVector;

    private float wallPosition = 6;


    private void Attack()
    {
        timeSinceAttack = 0;
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        if (hitEnemies.Length > 0)
        {
            GameWon();
        }
    }

    private void GameWon()
    {
        otherPlayer.GameOver();
    }

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        otherPlayer = otherPlayerObject.GetComponent<Player>();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = startingLocalPosition;
        animator.Play("idle", -1, 0f);
        timeSinceAttack = attackCooldown;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation((transform.localPosition.x + wallPosition)/(2 * wallPosition));
        sensor.AddObservation((transform.localPosition.x - otherPlayerObject.transform.localPosition.x)/(2 * wallPosition));
        sensor.AddObservation(timeSinceAttack/attackCooldown);
        sensor.AddObservation(otherPlayer.timeSinceAttack/attackCooldown);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.DiscreteActions[0];
        float attack = actions.DiscreteActions[1];

        // Movement Logic
        switch (moveX)
        {
            case 0:
                moveVector = new Vector2(-1, 0);
                break;
            case 1:
                moveVector = Vector2.zero;
                break;
            case 2:
                moveVector = new Vector2(1, 0);
                break;
        }

        rb.velocity = moveVector * moveSpeed;

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -wallPosition, wallPosition), transform.localPosition.y, transform.localPosition.z);

        if (attack == 1 && timeSinceAttack >= attackCooldown)
        {
            Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameWon();
    }

    private void Update()
    {
        
        if (timeSinceAttack < attackCooldown)
        {
            timeSinceAttack += Time.deltaTime;
        }
    }
    
    
}
