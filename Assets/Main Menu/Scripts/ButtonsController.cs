using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] Sprite buttonDown;
    [SerializeField] Sprite buttonUp;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
            spriteRenderer.sprite = buttonDown;
        else
            spriteRenderer.sprite = buttonUp;
    }
}
