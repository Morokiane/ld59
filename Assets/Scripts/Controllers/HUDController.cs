using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace Controllers {
    public class HUDController : Singleton<HUDController> {
        [SerializeField] private TextMeshProUGUI timerTxt;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private VolumeProfile postProcessingVolume;
        
        private ChromaticAberration chromaticAberration;
        private FilmGrain filmGrain;
        private TimeSpan timeSpan;

        private void Start() {
            timeSpan = TimeSpan.FromSeconds(LevelController._instance.timer);
            timerTxt.text = timeSpan.ToString(@"m\:ss");

        }

        private void Update() {
            timeSpan = TimeSpan.FromSeconds(LevelController._instance.timer);
            timerTxt.text = timeSpan.ToString(@"m\:ss");
        }

        public void PostProcess() {
            if (postProcessingVolume.TryGet(out chromaticAberration)) {
                // Set the chromatic aberration intensity using the .value field
                chromaticAberration.intensity.value = 0;  // Set to desired value between 0 and 1
            }

            if (postProcessingVolume.TryGet(out filmGrain)) {
                filmGrain.intensity.value = 1;
            }
        }

        public void GameOver() {
            gameOver.SetActive(true);
        }

        public void Restart() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDisable() {
            if (postProcessingVolume.TryGet(out filmGrain)) {
                filmGrain.intensity.value = 0;
            }
        }
    }
}
