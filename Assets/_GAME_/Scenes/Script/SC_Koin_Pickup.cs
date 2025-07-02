using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Koin_Pickup : MonoBehaviour
{
    public int nilaiKoin = 1;
    public AudioClip sfxAmbilKoin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SC_KoinManager.Instance.TambahKoin(nilaiKoin);
            FindObjectOfType<SC_KoinDIsplayUI>()?.UpdateKoin();

            // Animasi sebelum hancur
            StartCoroutine(HilangkanDenganAnimasi());
        }
    }

    IEnumerator HilangkanDenganAnimasi()
    {
        float durasi = 0.2f;
        Vector3 scaleAwal = transform.localScale;
        Vector3 scaleAkhir = Vector3.zero;

        float waktu = 0;
        while (waktu < durasi)
        {
            transform.localScale = Vector3.Lerp(scaleAwal, scaleAkhir, waktu / durasi);
            waktu += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

}
