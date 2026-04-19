using System.Collections;
using Controllers;
using UnityEngine;

namespace Objects {
    public class Console : Singleton<Console> {
        [SerializeField] private GameObject lights;
        [SerializeField] private GameObject removedWalls;
        [SerializeField] private SpriteRenderer[] sprite;
        [SerializeField] private AudioClip audioClip;
        public CircleCollider2D circleCollider2D;

        private AudioSource audioSource;

        protected override void Awake() {
            base.Awake();

            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                if (!LevelController._instance.allLampsOff) {
                    Player.Player._instance.action = 1;
                    // Player.Player._instance.canInteract = true;
                } else if (LevelController._instance.allLampsOff) {
                    Player.Player._instance.action = 2;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                Player.Player._instance.action = 0;
                // Player.Player._instance.canInteract = false;
            }
        }

        public void GetColors() {
            lights.SetActive(true);

            int[] sequence = LevelController._instance.sequence;
            Color[] colors = LevelController._instance.Colors;
            for (int i = 0; i < sprite.Length; i++) {
                Color c = colors[sequence[i]];
                c.a = 1f;
                sprite[i].color = c;
                Debug.Log($"Console sprite {i} -> colorIndex {sequence[i]}");
            }

            LevelController._instance.TurnOnLevelLights();
            audioSource.PlayOneShot(audioClip, 1.0f);
            Player.Player._instance.playerLight.intensity = 1f;
            removedWalls.SetActive(false);

            StartCoroutine(TurnOffLights());
            LevelController._instance.startTimer = true;
        }

        private IEnumerator TurnOffLights() {
            yield return new WaitForSeconds(3f);

            lights.SetActive(false);
        }

    }
}