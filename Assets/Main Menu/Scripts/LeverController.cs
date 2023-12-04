using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite idle;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;
    [SerializeField] Sprite up;
    [SerializeField] Sprite down;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Mouse X");

        if (horizontal == 0)
            spriteRenderer.sprite = idle;

        else if (horizontal > 0)
            spriteRenderer.sprite = right;

        else
            spriteRenderer.sprite = left;
    }
}
