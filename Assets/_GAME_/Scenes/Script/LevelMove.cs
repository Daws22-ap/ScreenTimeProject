using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class LevelMove : MonoBehaviour
{
    [Header("Scene Transition")]
    [Tooltip("Build index dari scene yang akan dimuat")]
    [SerializeField] int sceneBuildIndex = 0;

    private void Reset()
    {
        // Pastikan collider jadi trigger saat script di-attach
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Opsi: Debug.Log($"Pindah ke scene #{sceneBuildIndex}");
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
