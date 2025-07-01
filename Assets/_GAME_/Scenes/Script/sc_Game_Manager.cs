using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;


public class sc_Game_Manager : MonoBehaviour
{
    public Pertanyaan[] _pertanyaan;
    private static List<Pertanyaan> _belumDijawab;

    private Pertanyaan _pertanyaanSekarang;
    private int _jumlahKoin = 0;

    public TextMeshProUGUI teksPernyataan;

    void Start()
    {
        if (_belumDijawab == null || _belumDijawab.Count == 0)
        {
            _belumDijawab = _pertanyaan.ToList<Pertanyaan>();
        }

        GetRandomQuestion();
    }

    void GetRandomQuestion()
    {
        int _indeksPertanyaan = Random.Range(0, _belumDijawab.Count);
        _pertanyaanSekarang = _belumDijawab[_indeksPertanyaan];

        teksPernyataan.text = _pertanyaanSekarang._fakta;
    }

    public void Jawab(bool jawaban)
    {
        StartCoroutine(FeedbackJawaban(jawaban));
    }

    IEnumerator FeedbackJawaban(bool jawaban)
    {
        if (jawaban == _pertanyaanSekarang._benar)
        {
            teksPernyataan.text = "Benar!";
            _jumlahKoin += 5;
        }
        else
        {
            teksPernyataan.text = "Salah!";
        }

        yield return new WaitForSeconds(1f);

        _belumDijawab.Remove(_pertanyaanSekarang);

        if (_belumDijawab.Count > 0)
        {
            GetRandomQuestion();
        }
        else
        {
            teksPernyataan.text = $"Kuis selesai!\nTotal Koin Baru: {_jumlahKoin}";
            SC_KoinManager.Instance.TambahKoin(_jumlahKoin);

            yield return new WaitForSeconds(1f);

            int total = SC_KoinManager.Instance.AmbilKoin();
            teksPernyataan.text = $"Total Semua Koin: {total}";
          
            yield return new WaitForSeconds(5f);

            SceneManager.LoadScene(0, LoadSceneMode.Single);

        }
    }
}
