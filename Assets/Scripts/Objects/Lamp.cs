using UnityEngine;
using UnityEngine.Rendering.Universal;
namespace Objects {
    public class Lamp : MonoBehaviour {
        [SerializeField] private Light2D lamp;
        public int colorIndex;
        private CircleCollider2D circleCollider2D;

        private void Awake() {
            circleCollider2D = GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                // Debug.Log($"Player touched lamp with colorIndex {colorIndex}");
                if (Controllers.LevelController._instance.Deactivate(colorIndex)) {
                    lamp.intensity = 0;
                }
            }
        }
    }
}