using UnityEngine;
using Controllers;
using System.Collections;

namespace Utils {
    public class Console : Singleton<Console> {
        [SerializeField] private GameObject lights;
        [SerializeField] private SpriteRenderer[] sprite;

        private CircleCollider2D circleCollider2D;

        protected override void Awake() {
            base.Awake();
            circleCollider2D = GetComponent<CircleCollider2D>();
        }


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                Debug.Log("Found player");
                Player.Player._instance.action = 1;
                Player.Player._instance.canInteract = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                Player.Player._instance.action = 0;
                Player.Player._instance.canInteract = false;
            }
        }

        public void GetColors() {
            lights.SetActive(true);

            int[] sequence = LevelController._instance.sequence;
            Color[] colors = LevelController._instance.Colors;

            for (int i = 0; i < sprite.Length; i++) {
                Color c = colors[sequence[i]];
                sprite[i].color = c;
            }

            StartCoroutine(TurnOffLights());
        }

        private IEnumerator TurnOffLights() {
            yield return new WaitForSeconds(3f);

            lights.SetActive(false);
        }
    }
}