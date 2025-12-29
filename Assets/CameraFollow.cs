using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow")]
    public Transform player;
    public Vector3 offset = new Vector3(0, 10, -10);
    public float smoothSpeed = 0.125f;

    [Header("Sounds")]
    public AudioClip startSound;   // صوت البداية
    public AudioClip loseSound;    // صوت الخسارة
    private AudioSource audioSource;

    void Start()
    {
        // Camera checks
        if (player == null)
        {
            Debug.LogError("Player is NOT assigned in CameraFollow!");
        }

        // Audio setup
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is missing on Camera!");
        }
        else
        {
            PlayStartSound();
        }
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition =
            Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(player);
    }

    // ================== Sounds ==================

    void PlayStartSound()
    {
        if (startSound == null || audioSource == null) return;

        audioSource.clip = startSound;
        audioSource.Play();
    }

    public void PlayLoseSound()
    {
        if (loseSound == null || audioSource == null) return;

        audioSource.clip = loseSound;
        audioSource.Play();
    }
}
