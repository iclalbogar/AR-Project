using UnityEngine;
using Mediapipe.Unity.Sample.HandLandmarkDetection;

public class FingerFollower : MonoBehaviour
{
    public HandLandmarkerRunner handRunner;
    public Camera cam;

    [Header("Derinlik Ayarları")]
    public float sensitivity = 2.0f; 
    public float minDistance = 0.12f;
    public float maxDistance = 0.30f;
    
    private float minHandSize = 0.05f; 
    private float maxHandSize = 0.35f; 

    void Update()
    {
       
        if (handRunner != null && handRunner.latestResult.handLandmarks != null && handRunner.latestResult.handLandmarks.Count > 0)
        {
            var landmarks = handRunner.latestResult.handLandmarks[0].landmarks;

            if (landmarks != null && landmarks.Count >= 21)
            {
                // El Boyutu Hesabı
                Vector3 wrist = new Vector3(landmarks[0].x, landmarks[0].y, 0);
                Vector3 middleMCP = new Vector3(landmarks[9].x, landmarks[9].y, 0);
                float handSize = Vector3.Distance(wrist, middleMCP);

                // Derinlik Hesabı
                float t = Mathf.InverseLerp(minHandSize, maxHandSize, handSize);
                // Sensitivity ile derinlik etkisini artırıyoruz
                float dynamicZ = Mathf.Lerp(maxDistance, minDistance, t * (sensitivity / 10f));
                dynamicZ = Mathf.Clamp(dynamicZ, minDistance, maxDistance);

                // İşaret parmağı ucu
                var fingerPos = landmarks[8];
                Vector3 viewportPos = new Vector3(1 - fingerPos.x, 1 - fingerPos.y, dynamicZ);
                
                // KOORDİNAT ATAMASI
                Debug.Log("Kod çalışıyor Z: " + dynamicZ);
                transform.position = cam.ViewportToWorldPoint(viewportPos);
            }
        }
    }
}