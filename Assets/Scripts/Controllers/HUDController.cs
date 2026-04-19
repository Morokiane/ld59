using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace Controllers {
    public class HUDController : Singleton<HUDController> {
        [SerializeField] private TextMeshProUGUI timerTxt;
        [SerializeField] private GameObject tutWindow;
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject beatGame;
        [SerializeField] private Volume postProcessingVolume;

        public bool menuOpen;
        
        private ChromaticAberration chromaticAberration;
        private FilmGrain filmGrain;
        private TimeSpan timeSpan;

        private void Start() {
            timeSpan = TimeSpan.FromSeconds(LevelController._instance.timer);
            timerTxt.text = timeSpan.ToString(@"m\:ss");
            tutWindow.SetActive(true);

            postProcessingVolume.profile = Instantiate(postProcessingVolume.profile);

            if (postProcessingVolume.profile.TryGet(out chromaticAberration)) {
                chromaticAberration.intensity.Override(0f);
            }

            if (postProcessingVolume.profile.TryGet(out filmGrain)) {
                // filmGrain.intensity.Override(0f);
                filmGrain.intensity.value = 0f;
            }
        }

        private void Update() {
            timeSpan = TimeSpan.FromSeconds(LevelController._instance.timer);
            timerTxt.text = timeSpan.ToString(@"m\:ss");

            if (LevelController._instance.timer < 30 && filmGrain.intensity.value != 1) {
                filmGrain.intensity.value = Mathf.MoveTowards(filmGrain.intensity.value, 1f, 0.05f * Time.deltaTime);
                chromaticAberration.intensity.value = Mathf.MoveTowards(chromaticAberration.intensity.value, 1f, 0.05f * Time.deltaTime);
            }
        }

        public void OpenMenu(bool state) {
            if (state) {
                Time.timeScale = 0;
                menu.SetActive(state);
                Player.Player._instance.canMove = false;
            } else if (!state) {
                Time.timeScale = 1;
                menu.SetActive(state);
                Player.Player._instance.canMove = true;
            }
        }

        public void CloseWindow() {
            Time.timeScale = 1;
            Player.Player._instance.canMove = true;
            tutWindow.SetActive(false);
        }

        public void GameOver() {
            gameOver.SetActive(true);
        }

        public void Return() {
            SceneManager.LoadScene("Scenes/Title");    
        }

        public void BeatIt() {
            Time.timeScale = 0;
            beatGame.SetActive(true);
        }

        public void Exit() {
            Application.Quit();
        }

        public void Restart() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnDisable() {
            if (postProcessingVolume.profile.TryGet(out filmGrain)) {
                filmGrain.intensity.value = 0;
            }

            if (postProcessingVolume.profile.TryGet(out chromaticAberration)) {
                chromaticAberration.intensity.value = 0;
            }
        }
    }
}