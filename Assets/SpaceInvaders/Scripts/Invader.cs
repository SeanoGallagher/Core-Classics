using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1f;

    public System.Action killed;
    //public int score = 10;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    private SIScores scores;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        scores = GameObject.FindWithTag("Score Controller").GetComponent< SIScores>();
        
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        // Loop back to the start if the animation frame exceeds the length
        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            scores.IncrementScore();
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
        
    }

}