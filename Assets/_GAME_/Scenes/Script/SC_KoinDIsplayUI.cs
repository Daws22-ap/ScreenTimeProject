using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class SC_KoinDIsplayUI : MonoBehaviour
{
    public TextMeshProUGUI teksKoin;
    public string[] sceneTersembunyi = { "Math_quiz" };
    
    
    private void Start()
    {

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateKoin();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sembunyikan jika scene termasuk scene kuis
        bool sembunyi = false;
        foreach (var namaScene in sceneTersembunyi)
        {
            if (scene.name == namaScene)
            {
                sembunyi = true;
                break;
            }
        }

        gameObject.SetActive(!sembunyi);
        if (!sembunyi) UpdateKoin();
    }

    public void UpdateKoin()
    {
        if (SC_KoinManager.Instance != null)
        {
            teksKoin.text = $"{SC_KoinManager.Instance.AmbilKoin()}";
        }
    }
}
