using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Utils {
    public class Pulse : MonoBehaviour {
        private Light2D light2D;

        [SerializeField] private float minRadius = 1f;
        [SerializeField] private float maxRadius = 20f;
        [SerializeField] private float pulseSpeed = 10f;
        [SerializeField] private float radiusReduction = 1f;

        // private float currentMaxRadius;
        private float randomOffset;

        private void Awake() {
            light2D = GetComponent<Light2D>();
        }

        private void OnEnable() {
            Controllers.LevelController._instance.pulseRadius = maxRadius;
            light2D.pointLightOuterRadius = Random.Range(minRadius, maxRadius);
            // randomOffset = Random.Range(0f, Mathf.PI * 2f);
        }

        private void Update() {
            if (light2D.pointLightOuterRadius > minRadius) {
                light2D.pointLightOuterRadius = Mathf.MoveTowards(light2D.pointLightOuterRadius, minRadius, pulseSpeed * Time.deltaTime);
            } else {
                Controllers.LevelController._instance.pulseRadius = Mathf.Max(minRadius, Controllers.LevelController._instance.pulseRadius - radiusReduction);
                light2D.pointLightOuterRadius = Controllers.LevelController._instance.pulseRadius;
            }
        }
    }
}
