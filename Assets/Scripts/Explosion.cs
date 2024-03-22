using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimatedSpriteRenderer start;
    public AnimatedSpriteRenderer middle;
    public AnimatedSpriteRenderer end;

    public void SetActiveRenderer(AnimatedSpriteRenderer newRenderer)
    {
        start.enabled = newRenderer == start;
        middle.enabled = newRenderer == middle;
        end.enabled = newRenderer == end;
    }

    public void SetDirection(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x);
        float deg = angle * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(deg, Vector3.forward);
    }
}
