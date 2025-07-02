using UnityEngine;

public class SC_KoinIdle : MonoBehaviour
{
    public float amplitude = 0.1f;   // tinggi ayunan
    public float frequency = 2f;     // kecepatan ayunan
    public float rotationSpeed = 50f; // derajat per detik

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Gerakan mengambang naik-turun
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPos + new Vector3(0, y, 0);

        // Rotasi atau spin
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}




