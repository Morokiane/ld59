using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers {
    public class TitleScreen : MonoBehaviour {
        [SerializeField] private AudioClip audioClip;

        private AudioSource audioSource;

        private void Start() {
            audioSource = GetComponent<AudioSource>();
        }
        
        public void Play() {
            audioSource.PlayOneShot(audioClip, 0.5f);
            StartCoroutine(DelayStart());
        }

        private IEnumerator DelayStart() {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Scenes/Test");    
        }

        public void Exit() {
            Application.Quit();
        }
    }
}
