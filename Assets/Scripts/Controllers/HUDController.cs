using UnityEngine;
using TMPro;
using System;

namespace Controllers {
    public class HUDController : Singleton<HUDController> {
        [SerializeField] private TextMeshProUGUI timerTxt;
        
        private TimeSpan timeSpan;

        private void Start() {
            timeSpan = TimeSpan.FromSeconds(LevelController._instance.timer);
            timerTxt.text = timeSpan.ToString(@"m\:ss");
        }

        private void Update() {
            timeSpan = TimeSpan.FromSeconds(LevelController._instance.timer);
            timerTxt.text = timeSpan.ToString(@"m\:ss");
        }
    }
}
