using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicOnSceneStart : MonoBehaviour
{
    [SerializeField] private AudioClip playAtStart;

    private void Start()
    {
        Buttons SoundGestion = GameObject.Find("SoundController").GetComponent<Buttons>();
        SoundGestion.SoundSource.clip = playAtStart;
        SoundGestion.SoundSource.Play();
    }
}
