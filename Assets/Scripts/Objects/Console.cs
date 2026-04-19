using System.Collections;
using Controllers;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Objects {
    public class Console : Singleton<Console> {
        [SerializeField] private GameObject lights;
        [SerializeField] private SpriteRenderer[] sprite;
        public CircleCollider2D circleCollider2D;

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
            Player.Player._instance.playerLight.intensity = 1f;

            StartCoroutine(TurnOffLights());
            LevelController._instance.startTimer = true;
        }

        private IEnumerator TurnOffLights() {
            yield return new WaitForSeconds(3f);

            lights.SetActive(false);
        }

    }
}