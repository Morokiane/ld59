using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Controllers {
    public class LevelController : Singleton<LevelController> {
        [SerializeField] private Color[] colors;
        [SerializeField] private Light2D[] lights;
        [SerializeField] private GameObject levelLights;
        [SerializeField] private Light2D globalLight;
        [SerializeField] private GameObject boosts;

        public int[] sequence { get; private set; }
        public int[] lampColors { get; private set; }
        public Color[] Colors => colors;
        public int currentStep = 0;
        public float timer = 1f;
        public bool startTimer;
        public float pulseRadius;
        public bool allLampsOff;

        private void Start() {
            lampColors = RandomSequence();
            sequence = RandomSequence();

            for (int i = 0; i < lights.Length; i++) {
                Color c = colors[lampColors[i]];
                c.a = 1f;
                lights[i].color = c;
                Objects.Lamp lamp = lights[i].GetComponentInChildren<Objects.Lamp>();
                if (lamp != null) {
                    lamp.colorIndex = lampColors[i];
                }
            }
        }

        private void Update() {
            if (startTimer) {
                if (timer > 0) {
                    timer -= Time.deltaTime;
                } else {
                    startTimer = false;
                    Player.Player._instance.canMove = false;
                    HUDController._instance.GameOver();
                }
            }
        }

        int[] RandomSequence() {
            int[] numbers = { 0, 1, 2, 3 };
            for (int i = numbers.Length - 1; i > 0; i--) {
                int randomIndex = UnityEngine.Random.Range(0, i + 1);
                int temp = numbers[i];
                numbers[i] = numbers[randomIndex];
                numbers[randomIndex] = temp;
            }
            return numbers;
        }

        public void TurnOnLevelLights() {
            levelLights.SetActive(true);
            boosts.SetActive(true);
            globalLight.intensity = 0;
        }

        public bool Deactivate(int colorIndex) {
            if (sequence[currentStep] == colorIndex) {
                currentStep++;

                if (currentStep == 4) {
                    Objects.Console._instance.circleCollider2D.enabled = true;
                    // HUDController._instance.PostProcess();
                    allLampsOff = true;
                }

                return true;
            }
            return false;
        }

        public bool IsComplete() {
            return currentStep >= sequence.Length;
        }
    }
}