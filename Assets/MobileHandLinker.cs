using UnityEngine;
using System.Collections.Generic;
using Mediapipe.Tasks.Vision.HandLandmarker;

// Namespace �nemli, Runner scriptini g�rmesi i�in:
namespace Mediapipe.Unity.Sample.HandLandmarkDetection
{
    public class MobileHandLinker : MonoBehaviour
    {
        [Header("Ba�lant�lar")]
        public HandLandmarkerRunner handRunner;
        public Camera mainCamera;

        [Header("2D Ayarlar�")]
        [Tooltip("Top kameradan ne kadar uzakta dursun? (Sabit Z mesafesi)")]
        public float distanceFromCamera = 10f;

        [Header("Hassasiyet")]
        public float smoothSpeed = 12f;
        public bool mirrorX = true;

        private void Update()
        {
            if (handRunner == null) return;

            // Struct null olamaz hatası için
            if (handRunner.latestResult.handLandmarks == null) return;

            var result = handRunner.latestResult;

            // El tespitinikontrol etmek için
            if (result.handLandmarks.Count > 0)
            {
               
                var currentHand = result.handLandmarks[0];
                var indexTip = currentHand.landmarks[8];

                float xPos = indexTip.x;
                float yPos = indexTip.y;

                // 3. EKRAN AYARLARI
                if (mirrorX) xPos = 1 - xPos;
                yPos = 1 - yPos;

                // 4. HAREKET z yi sabitlemek için
                Vector3 targetPos = mainCamera.ViewportToWorldPoint(new Vector3(xPos, yPos, distanceFromCamera));

                
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
            }
        }
    }
}