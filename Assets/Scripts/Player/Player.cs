using Controllers;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
 
namespace Player {
    public class Player : Singleton<Player> {

        // public GameObject interactionIcon;
        
        public bool canMove = true;
        public int action;
        public Light2D playerLight;

        [HideInInspector] public SpriteRenderer sprite;

        private void Start() {
            sprite = GetComponent<SpriteRenderer>();
        }

        private void Update() {
            if (LevelController._instance.timer <= 15) {
                playerLight.intensity = Mathf.MoveTowards(playerLight.intensity, 0, 0.1f * Time.deltaTime);
            }
        }

        public void OnInteract(InputAction.CallbackContext context) {
            if (context.started) {
                switch (action) {
                    case 1:
                        Objects.Console._instance.GetColors();
                        Objects.Console._instance.circleCollider2D.enabled = false;
                    break;

                    case 2:
                        canMove = false;
                        HUDController._instance.BeatIt();
                    break;
                }
            }
        }

        public void OpenMenu(InputAction.CallbackContext context) {
            if (context.started) {
                HUDController._instance.OpenMenu(true);
            }
        }

        /* public void CancelMenu(InputAction.CallbackContext context) {
            if (context.performed && LevelController._instance.currentCraftingStation && LevelController._instance.menuOpen) {
                if (LevelController._instance.inTutorial) {
                    return;
                }

                LevelController._instance.currentCraftingStation.CloseMenu();

                if (LevelController._instance.currentRecipe != null) {
                    LevelController._instance.currentRecipe.CloseWindow();
                }

                LevelController._instance.menuOpen = false;
                canMove = true;
                HUDController._instance.canOpenInventory = true;
            } else if (context.performed && inventoryOpen) {
                inventoryOpen = false;
                inventory.SetActive(false);
            } else if (context.performed) {
                if (!HUDController._instance.mainMenuOpen) {
                    HUDController._instance.mainMenuOpen = true;
                    HUDController._instance.canOpenInventory = false;
                    HUDController._instance.ShowMainMenu(true);
                } else if (HUDController._instance.mainMenuOpen) {
                    HUDController._instance.mainMenuOpen = false;
                    HUDController._instance.canOpenInventory = true;
                    HUDController._instance.ShowMainMenu(false);
                }
            }
        } */
    }
}
