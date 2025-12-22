using UnityEngine;
using UnityEngine.Video;

public class AnimalSoundTouch : MonoBehaviour
{
    [Header("Assign Assets")]
    public AudioClip animalSound;
    public Transform playerHand; // Drag your "Hand" or "Main Camera" here
    public float triggerDistance = 1.5f; // How close you need to be (in meters)

    private AudioSource _audioSource;
    private VideoPlayer _videoPlayer;
    private bool _hasPlayed = false; // Prevents it from playing 100 times a second

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        // 1. Safety Check: Do we have a hand to track?
        if (playerHand == null) return;

        // 2. Measure the distance
        float distance = Vector3.Distance(transform.position, playerHand.position);

        // 3. If close enough, play the content!
        if (distance < triggerDistance && !_hasPlayed)
        {
            PlayContent();
        }
        // 4. Optional: Reset if you walk away (so you can play it again)
        else if (distance > triggerDistance + 1.0f) 
        {
            _hasPlayed = false;
        }
    }

    void PlayContent()
    {
        _hasPlayed = true;
        Debug.Log("Triggered by Distance! Playing: " + gameObject.name);

        if (animalSound != null && _audioSource != null)
        {
            _audioSource.clip = animalSound;
            _audioSource.Play();
        }

        if (_videoPlayer != null)
        {
            _videoPlayer.Play();
        }
    }
}