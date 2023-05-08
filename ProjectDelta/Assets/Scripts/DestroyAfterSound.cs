using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSound : MonoBehaviour
{
   private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to this game object
        audioSource = GetComponent<AudioSource>();

        // Destroy the game object after the sound has finished playing
        Destroy(gameObject, audioSource.clip.length);
    }
}
