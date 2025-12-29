using UnityEngine;

public class SmartGhost : MonoBehaviour
{
    public Transform player;
    public float speed = 0f;
    private CameraFollow cameraFollow;

    void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        if (cameraFollow == null)
        {
            Debug.LogError("CameraFollow NOT found!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // اتجاه الحركة نحو اللاعب
            Vector3 direction = (player.position - transform.position);
            direction.y = 0; // منع الطيران

            // تحريك Ghost باتجاه اللاعب
            transform.position += direction.normalized * speed * Time.deltaTime;

            // يمكن للـGhost النظر نحو اللاعب
            if (direction != Vector3.zero)
                transform.forward = direction.normalized;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cameraFollow != null)
                cameraFollow.PlayLoseSound();

            Time.timeScale = 0f;
        }
    }
}
