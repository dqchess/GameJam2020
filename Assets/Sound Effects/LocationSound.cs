using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSound : MonoBehaviour
{
    [SerializeField] AudioClip dirtSound;
    [SerializeField] AudioClip grassSound;
    [SerializeField] AudioClip caveSound;
    [SerializeField] AudioClip iceSound;
    [SerializeField] AudioClip stormSound;
    [SerializeField] AudioClip waterSound;
    [SerializeField] AudioClip lavaSound;
    [SerializeField] AudioClip stairSound;
    [SerializeField] AudioClip airSound;

    AudioSource audioSource;
    Rigidbody rb;

    enum AudioState {
        grass,
        dirt,
        cave,
        ice,
        storm,
        lava,
        water,
        stair,
        air,
        uninitialized
    }

    AudioState newAudio = AudioState.uninitialized;
    AudioState currentAudio = AudioState.uninitialized;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        UnityEngine.Debug.Log("Collided with" + other.gameObject.tag);
        switch (other.gameObject.tag)
        {
            case "grass":
                newAudio = AudioState.grass;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(grassSound,.15f));
                }
                break;
            case "dirt":
                newAudio = AudioState.dirt;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(dirtSound,.15f));
                }
                break;
            case "cave":
                newAudio = AudioState.cave;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(caveSound,.15f));
                }
                break;
            case "ice":
                newAudio = AudioState.ice;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(iceSound,.15f));
                }
                break;
            case "storm":
                newAudio = AudioState.storm;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(stormSound,.15f));
                }
                break;
            case "water":
                newAudio = AudioState.water;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(waterSound,.15f));
                }
                break;
            case "lava":
                newAudio = AudioState.lava;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(lavaSound,.15f));
                }
                break;
            case "stair":
                newAudio = AudioState.stair;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(stairSound,.15f));
                }
                break;
            case "air":
                newAudio = AudioState.air;
                if (newAudio != currentAudio || !audioSource.isPlaying)
                {
                    currentAudio = newAudio;
                    audioSource.Stop();
                    StartCoroutine(PlaySound(airSound,.15f));
                }
                break;
            default:
                UnityEngine.Debug.Log("No sound");
                break;
        }
    }

    IEnumerator PlaySound(AudioClip audio, float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.Debug.Log("currentAudio is " + currentAudio + ", new is " + newAudio);

        audioSource.PlayOneShot(audio);
        
    }
}
