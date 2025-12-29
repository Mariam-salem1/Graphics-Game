using UnityEngine;

public class Rotator : MonoBehaviour 
{
    // دالة واحدة فقط للتحديث عشان الكوين تلف
    void Update() 
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}