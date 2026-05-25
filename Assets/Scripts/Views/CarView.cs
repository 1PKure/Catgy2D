using UnityEngine;

public class CarView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Rendering Settings")]
    [SerializeField] private int sortingOrder = 10;

    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        ApplyDefaultVisualSettings();
    }

    public void SetSprite(Sprite sprite)
    {
        if (spriteRenderer == null || sprite == null)
        {
            return;
        }

        spriteRenderer.sprite = sprite;
        ApplyDefaultVisualSettings();
    }

    public void SetDirection(int direction)
    {
        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
    }

    public void ApplySortingOrder()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = sortingOrder;
        }
    }

    private void ApplyDefaultVisualSettings()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        spriteRenderer.color = Color.white;
        spriteRenderer.sortingOrder = sortingOrder;
    }
}