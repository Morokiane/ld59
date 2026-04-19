using UnityEngine;
using UnityEngine.Rendering.Universal;
using Controllers;

namespace Objects {
    public class Lamp : MonoBehaviour {
        [SerializeField] private Light2D lamp;
        [SerializeField] private AudioClip audioClip;
        public int colorIndex;
        private CircleCollider2D circleCollider2D;
        private AudioSource audioSource;

        private void Awake() {
            circleCollider2D = GetComponent<CircleCollider2D>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                // Debug.Log($"Player touched lamp with colorIndex {colorIndex}");
                if (!LevelController._instance.allLampsOff) {
                    if (LevelController._instance.Deactivate(colorIndex)) {
                        LevelController._instance.pulseRadius += 10;
                        LevelController._instance.timer += 10;
                        audioSource.PlayOneShot(audioClip, 0.5f);
                    
                        lamp.intensity = 0;
                    }
                }
            }
        }
    }
}