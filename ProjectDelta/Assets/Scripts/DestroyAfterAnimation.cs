using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    private Animator animator;
    public string animationName;

    private void Start()
    {
        // Get the Animator component attached to this game object
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the animation has finished playing
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            // Destroy the game object if the animation has finished playing
            Destroy(gameObject);
        }
    }
}
