using System.Collections;
using UnityEngine;

namespace Utils {
    public class ButtonScaler : MonoBehaviour {
        [SerializeField] private Vector3 scaleUpSize = new Vector3(1.2f, 1.2f, 1f);
        [SerializeField] private float scaleDuration = 0.1f;

        private Vector3 originalSize;

        private void Start() {
            originalSize = transform.localScale;
        }

        public void OnMouseEnter() {
            StopAllCoroutines();
            StartCoroutine(ScaleButton(scaleUpSize));
        }

        public void OnMouseExit() {
            StopAllCoroutines();
            StartCoroutine(ScaleButton(originalSize));
        }

        private IEnumerator ScaleButton(Vector3 targetScale) {
            Vector3 currentScale = transform.localScale;
            float timer = 0;

            while (timer < scaleDuration) {
                transform.localScale = Vector3.Lerp(currentScale, targetScale, timer / scaleDuration);
                timer += Time.unscaledDeltaTime;
                yield return null;
            }
            transform.localScale = targetScale;
        }
    }
}
