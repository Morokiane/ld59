using UnityEngine;
using Controllers;
using System.Collections;

namespace Utils {
    public class Boost : MonoBehaviour {
        [SerializeField] private AudioClip audioClip;
        public CircleCollider2D circleCollider2D;

        private AudioSource audioSource;

        private void Awake() {
            circleCollider2D = GetComponent<CircleCollider2D>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D (Collider2D other) {
            if (other.CompareTag("Player")) {
                LevelController._instance.pulseRadius += 5;
                LevelController._instance.timer += 5;
                audioSource.PlayOneShot(audioClip, 1f);
                Destroy(gameObject, 0.2f);
            }
        }
    }
}
