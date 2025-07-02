using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_KoinManager : MonoBehaviour
{
    public static SC_KoinManager Instance;

    private const string KEY_KOIN = "JumlahKoin";

    private int _koin;
    private static bool sudahReset = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            sudahReset = false;
            DontDestroyOnLoad(gameObject);

            if (!sudahReset)
            {
                _koin = 0;
                SimpanKoin();
                sudahReset = true;
            }
            else
            {
                LoadKoin();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TambahKoin(int jumlah)
    {
        _koin += jumlah;
        SimpanKoin();
    }

    public int AmbilKoin()
    {
        return _koin;
    }

    private void SimpanKoin()
    {
        PlayerPrefs.SetInt(KEY_KOIN, _koin);
        PlayerPrefs.Save();
    }

    private void LoadKoin()
    {
        _koin = PlayerPrefs.GetInt(KEY_KOIN, 0);
    }
}
