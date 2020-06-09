using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.85f;
        audioSource.volume = 0.35f;
    }

    void Update()
    {
        if (Anxiety.anxiety < 10 && Courage.courage == 6)
        {
            audioSource.pitch = 1;
            audioSource.volume = 0.5f;
        }
        else if (Courage.courage < 6)
        {
            audioSource.pitch = 0.95f;
            audioSource.volume = 0.45f;
        }
        if (Anxiety.anxiety < 20 && Anxiety.anxiety >= 10 && Courage.courage >= 4)
        {
            audioSource.pitch = 0.95f;
            audioSource.volume = 0.45f;
        }
        else if (Courage.courage < 4)
        {
            audioSource.pitch = 0.9f;
            audioSource.volume = 0.4f;
        }
        if (Anxiety.anxiety < 30 && Anxiety.anxiety >= 20 && Courage.courage >= 2)
        {
            audioSource.pitch = 0.9f;
            audioSource.volume = 0.4f;
        }
        else if (Courage.courage < 2)
        {
            audioSource.pitch = 0.85f;
            audioSource.volume = 0.35f;
        }
        if (Anxiety.anxiety < 40 && Anxiety.anxiety >= 30)
        {
            audioSource.pitch = 0.85f;
            audioSource.volume = 0.35f;
        }
        if (Anxiety.anxiety >= 40)
        {
            audioSource.pitch = 0.8f;
            audioSource.volume = 0.3f;
        }
    }
}
