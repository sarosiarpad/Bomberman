using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float animationTime = 0.1666667f;
    public int frameIndex = 0;
    public Sprite[] activeSprites;
    public Sprite idleSprite;
    public bool isIdle = true;
    public bool shouldLoop = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }
    private void NextFrame()
    {
        frameIndex++;
        if (shouldLoop && frameIndex >= activeSprites.Length)
        {
            frameIndex = 0;
        }

        if (isIdle)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else if (frameIndex < activeSprites.Length)
        {
            spriteRenderer.sprite = activeSprites[frameIndex];
        }
    }
    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }
}
