using UnityEngine;
using Mediapipe.Unity;
// This namespace is usually needed for the Runner
using Mediapipe.Unity.Sample.HandLandmarkDetection; 

public class HandToPhysics : MonoBehaviour
{
    [Header("Assign in Inspector")]
    // FIXED: changed to 'HandLandmarkerRunner' (the file visible in your screenshot)
    public HandLandmarkerRunner solution; 
    public Camera mainCamera;
    
    private GameObject _physicsFinger;

    void Start()
    {
        _physicsFinger = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _physicsFinger.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f); 
        _physicsFinger.name = "IndexFingerTip";
        
        SphereCollider col = _physicsFinger.GetComponent<SphereCollider>();
        col.isTrigger = false; 
        
        Rigidbody rb = _physicsFinger.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true; 
        
        _physicsFinger.tag = "MainCamera"; 
    }

   void Update()
    {
        if (solution == null) return;

        // FIXED: Removed "solution.myResult != null" because it is a Struct
        if (solution.myResult.handLandmarks != null)
        {
            if (solution.myResult.handLandmarks.Count > 0)
            {
                var hand = solution.myResult.handLandmarks[0];
                
                // IMPORTANT: Check if landmarks exist before accessing [8]
                if (hand.landmarks == null || hand.landmarks.Count <= 8) return;

                var indexTip = hand.landmarks[8];

                Vector3 screenPoint = new Vector3(
                    indexTip.x * UnityEngine.Screen.width, 
                    (1 - indexTip.y) * UnityEngine.Screen.height, 
                    2.0f 
                );

                Vector3 worldPoint = mainCamera.ScreenToWorldPoint(screenPoint);
                _physicsFinger.transform.position = worldPoint;
            }
        }
    }
}