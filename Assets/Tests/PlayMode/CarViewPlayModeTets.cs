using NUnit.Framework;
using UnityEngine;

public class CarViewPlayModeTests
{
    [Test]
    public void Awake_ShouldApplyDefaultVisualSettings()
    {
        GameObject carObject = new GameObject("Test Car View");
        SpriteRenderer spriteRenderer = carObject.AddComponent<SpriteRenderer>();

        carObject.AddComponent<CarView>();

        Assert.AreEqual(Color.white, spriteRenderer.color);
        Assert.AreEqual(10, spriteRenderer.sortingOrder);

        Object.DestroyImmediate(carObject);
    }

    [Test]
    public void SetSprite_ShouldAssignSpriteToRenderer()
    {
        GameObject carObject = new GameObject("Test Car View");
        SpriteRenderer spriteRenderer = carObject.AddComponent<SpriteRenderer>();
        CarView carView = carObject.AddComponent<CarView>();

        Texture2D texture = new Texture2D(16, 16);
        Sprite sprite = Sprite.Create(
            texture,
            new Rect(0f, 0f, 16f, 16f),
            new Vector2(0.5f, 0.5f)
        );

        carView.SetSprite(sprite);

        Assert.AreEqual(sprite, spriteRenderer.sprite);

        Object.DestroyImmediate(sprite);
        Object.DestroyImmediate(texture);
        Object.DestroyImmediate(carObject);
    }

    [Test]
    public void SetDirection_ShouldRotateCarToNegativeNinety_WhenDirectionIsPositive()
    {
        GameObject carObject = new GameObject("Test Car View");
        CarView carView = carObject.AddComponent<CarView>();

        carView.SetDirection(1);

        Quaternion expectedRotation = Quaternion.Euler(0f, 0f, -90f);

        Assert.Less(Quaternion.Angle(expectedRotation, carObject.transform.rotation), 0.01f);

        Object.DestroyImmediate(carObject);
    }

    [Test]
    public void SetDirection_ShouldRotateCarToPositiveNinety_WhenDirectionIsNegative()
    {
        GameObject carObject = new GameObject("Test Car View");
        CarView carView = carObject.AddComponent<CarView>();

        carView.SetDirection(-1);

        Quaternion expectedRotation = Quaternion.Euler(0f, 0f, 90f);

        Assert.Less(Quaternion.Angle(expectedRotation, carObject.transform.rotation), 0.01f);

        Object.DestroyImmediate(carObject);
    }

    [Test]
    public void ApplySortingOrder_ShouldSetRendererSortingOrder()
    {
        GameObject carObject = new GameObject("Test Car View");
        SpriteRenderer spriteRenderer = carObject.AddComponent<SpriteRenderer>();
        CarView carView = carObject.AddComponent<CarView>();

        spriteRenderer.sortingOrder = 0;

        carView.ApplySortingOrder();

        Assert.AreEqual(10, spriteRenderer.sortingOrder);

        Object.DestroyImmediate(carObject);
    }
}