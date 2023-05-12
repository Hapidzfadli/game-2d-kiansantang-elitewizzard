using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds; // array background untuk parallax
    public float[] parallaxSpeeds; // kecepatan parallax untuk masing-masing background
    public float smoothing = 1f; // faktor smoothing
    private float[] startPosX; // posisi awal x untuk masing-masing background
    


    private void Start()
    {
        // simpan posisi awal x untuk masing-masing background
        startPosX = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            startPosX[i] = backgrounds[i].position.x;
        }
    }

    private void Update()
    {
        // hitung perpindahan kamera
        float cameraMovement = Camera.main.transform.position.x * (1 - smoothing);

        // geser posisi background sesuai kecepatan parallax dan faktor smoothing
        for (int i = 0; i < backgrounds.Length; i++)
        {
            SpriteRenderer spriteRenderer = backgrounds[i].GetComponent<SpriteRenderer>();
            float width = spriteRenderer.bounds.size.x;
            float parallax = (startPosX[i] - cameraMovement) * parallaxSpeeds[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

            // jika background telah melewati batas kanan layar, pindahkan ke kiri
            if (backgrounds[i].position.x < Camera.main.transform.position.x - width)
            {
                backgrounds[i].position = new Vector3(backgrounds[i].position.x + ((width * 2) - 3f), backgrounds[i].position.y, backgrounds[i].position.z);
            }
            if (backgrounds[i].position.x > Camera.main.transform.position.x + width)
            {
                backgrounds[i].position = new Vector3(backgrounds[i].position.x - ((width * 2) - 3f), backgrounds[i].position.y, backgrounds[i].position.z);
            }
        }
    }
}
