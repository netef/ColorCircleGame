using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance { get; private set; }
    private AudioSource audio;
    public AudioClip pickUpClip;
    public AudioClip dieClip;
    public AudioClip successClip;

    void Awake() => Instance = this;
    void Start() => audio = GetComponent<AudioSource>();
    public void PlayPickupSound() => audio.PlayOneShot(pickUpClip);
    public void PlayDieSound() => audio.PlayOneShot(dieClip);
    public void PlaySuccessSound() => audio.PlayOneShot(successClip);


}
