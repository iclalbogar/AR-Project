using UnityEngine;

public class CamTest : MonoBehaviour
{
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0) {
            Debug.LogError("Kamera bulunamadı!");
        } else {
            for (int i = 0; i < devices.Length; i++) {
                Debug.Log("Kamera bulundu: " + devices[i].name);
            }
        }
    }
}