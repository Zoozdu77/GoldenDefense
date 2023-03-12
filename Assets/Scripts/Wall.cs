using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Destroyed;

    public float life;

    void Update()
    {
        if (life <= 0)
        {
            Audio.PlayOneShot(Destroyed);
            Destroy(gameObject);
        }    
    }
}
