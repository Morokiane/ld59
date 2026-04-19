using UnityEngine;
using Controllers;

namespace Utils {
    public class Boost : MonoBehaviour {
        private CircleCollider2D circleCollider2D;

        private void Awake() {
            circleCollider2D = GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D (Collider2D other) {
            if (other.CompareTag("Player")) {
                LevelController._instance.pulseRadius += 5;
                LevelController._instance.timer += 5;
                Destroy(gameObject);
            }
        }
    }
}
