using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        private void Awake()
        {
            if (runes == null || runes.Count == 0)
            {
                Debug.LogError("Runes list belum diisi di Inspector!", this);
                enabled = false;
                return;
            }

            // ambil warna dasar (rgb) dan mulai dari alpha=0
            Color baseCol = runes[0].color;
            curColor = new Color(baseCol.r, baseCol.g, baseCol.b, 0f);
            targetColor = curColor;

            // apply awal
            foreach (var r in runes)
                r.color = curColor;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor.a = 1.0f;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor.a = 0.0f;
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }
}
