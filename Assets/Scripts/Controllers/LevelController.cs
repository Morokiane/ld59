using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Controllers {
    public class LevelController : Singleton<LevelController> {
        [SerializeField] private Color[] colors;
        [SerializeField] private Light2D[] lights;

        public int[] sequence { get; private set; }
        public Color[] Colors => colors;

        private void Start() {
            sequence = RandomSequence();

            for (int i = 0; i < lights.Length; i++) {
                lights[i].color = colors[sequence[i]];
            }
        }

        int[] RandomSequence() {
            int[] numbers = { 0, 1, 2, 3 };

            for (int i = numbers.Length - 1; i > 0; i--) {
                int randomIndex = Random.Range(0, i + 1);

                int temp = numbers[i];
                numbers[i] = numbers[randomIndex];
                numbers[randomIndex] = temp;
            }

            return numbers;
        }
    }
}
