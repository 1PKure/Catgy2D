using UnityEngine;

[System.Serializable]
public class LaneData
{
    [Header("Visual Settings")]
    public Sprite CarSprite;

    [Header("Movement Settings")]
    public float CarSpeed = 4f;
    public int Direction = 1;

    [Header("Spawn Settings")]
    public float SpawnInterval = 2f;
    public float DestroyPositionX = 10f;
}