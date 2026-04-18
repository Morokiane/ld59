using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Utils {
    public class Pulse : MonoBehaviour {
        private Light2D light2D;

        [SerializeField] private float minRadius = 1f;
        [SerializeField] private float maxRadius = 500f;
        [SerializeField] private float pulseSpeed = 1f;
        [SerializeField] private float radiusReduction = 10f;

        private float currentMaxRadius;
        private float randomOffset;

        private void Awake() {
            light2D = GetComponent<Light2D>();
        }

        /* private void Start() {
            currentMaxRadius = maxRadius;
            randomOffset = Random.Range(0f, Mathf.PI * 2f);
        } */

        private void OnEnable() {
            currentMaxRadius = maxRadius;
            light2D.pointLightOuterRadius = Random.Range(minRadius, maxRadius);
            // randomOffset = Random.Range(0f, Mathf.PI * 2f);
        }

        private void Update() {
            if (light2D.pointLightOuterRadius > minRadius) {
                light2D.pointLightOuterRadius = Mathf.MoveTowards(light2D.pointLightOuterRadius, minRadius, pulseSpeed * Time.deltaTime);
            } else {
                currentMaxRadius = Mathf.Max(minRadius, currentMaxRadius - radiusReduction);
                light2D.pointLightOuterRadius = currentMaxRadius;
            }
        }
    }
}
