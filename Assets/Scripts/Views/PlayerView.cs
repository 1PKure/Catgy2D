using System.Collections;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;

    [Header("Animation Settings")]
    [SerializeField] private float moveAnimationDuration = 0.15f;

    [Header("Animator State Names")]
    [SerializeField] private string idleStateName = "Cat_Idle";
    [SerializeField] private string upWalkStateName = "Cat_BackWalk";
    [SerializeField] private string downWalkStateName = "Cat_FrontWalk";

    private Coroutine currentAnimationCoroutine;

#if UNITY_EDITOR
    public string LastPlayedState { get; private set; }
#endif

    public void PlayMoveAnimation(int direction)
    {
        if (currentAnimationCoroutine != null)
        {
            StopCoroutine(currentAnimationCoroutine);
        }

        currentAnimationCoroutine = StartCoroutine(PlayMoveAnimationRoutine(direction));
    }

    public void PlayIdleAnimation()
    {
        if (currentAnimationCoroutine != null)
        {
            StopCoroutine(currentAnimationCoroutine);
            currentAnimationCoroutine = null;
        }

        PlayState(idleStateName);
    }

    private IEnumerator PlayMoveAnimationRoutine(int direction)
    {
        if (direction > 0)
        {
            PlayState(upWalkStateName);
        }
        else if (direction < 0)
        {
            PlayState(downWalkStateName);
        }
        else
        {
            PlayState(idleStateName);
        }

        yield return new WaitForSeconds(moveAnimationDuration);

        PlayState(idleStateName);
        currentAnimationCoroutine = null;
    }

    private void PlayState(string stateName)
    {
#if UNITY_EDITOR
        LastPlayedState = stateName;
#endif

        if (animator == null)
        {
            return;
        }

        animator.Play(stateName, 0, 0f);
    }
}