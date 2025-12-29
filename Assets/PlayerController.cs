using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;

    public TextMeshProUGUI countText;   // نص العداد
    public GameObject winTextObject;    // رسالة الفوز
    public AudioClip coinSound;         // 🔊 صوت الكوين

    private Rigidbody rb;
    private int count;

    private AudioSource audioSource;    // 👈 إضافة AudioSource للتحكم بالصوت

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        UpdateCountText();
        winTextObject.SetActive(false);

        // إعداد AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            // تشغيل الصوت عبر AudioSource
            if (coinSound != null)
            {
                audioSource.PlayOneShot(coinSound);
            }

            // حذف الكوين
            other.gameObject.SetActive(false);

            // زيادة العداد
            count++;
            UpdateCountText();
        }
    }

    void UpdateCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 34)
        {
            winTextObject.SetActive(true);
        }
    }
}
