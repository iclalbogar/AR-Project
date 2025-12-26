using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(AudioSource))]
public class AnimalSoundTouch : MonoBehaviour
{
    [Header("Settings")]
    public AudioClip animalSound;
    public float spinSpeed = 200f;
    public string fingerTag = "MainCamera"; 

    private AudioSource _audioSource;
    private VideoPlayer _videoPlayer;
    private bool _isPlaying = false;
    private Quaternion _originalRotation; 

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _videoPlayer = GetComponent<VideoPlayer>();
        _originalRotation = transform.rotation;
        _audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(fingerTag) && !_isPlaying)
        {
            Debug.Log($"{gameObject.name} el ile temas etti!");
            StartAction();
        }
    }

    void Update()
    {
        if (_isPlaying && _videoPlayer == null)
        {
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }

    void StartAction()
    {
        _isPlaying = true;

        if (_audioSource != null && animalSound != null)
        {
            _audioSource.PlayOneShot(animalSound);
        }

        if (_videoPlayer != null) 
        {
            _videoPlayer.Play();
        }

   
        Invoke("StopAction", 3.0f);
    }

    void StopAction()
    {
        _isPlaying = false;
        
        if (_videoPlayer != null) 
        {
            _videoPlayer.Stop();
        }
        
        transform.rotation = _originalRotation;
    }
}