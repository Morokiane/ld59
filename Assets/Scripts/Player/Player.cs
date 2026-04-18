using Controllers;
using UnityEngine;
// using UnityEngine.InputSystem;
 
namespace Player {
    public class Player : Singleton<Player> {

        // public GameObject interactionIcon;
        
        public bool canMove = true;
        // public uint action;
        // private PlayerMovement playerMovement;

        [HideInInspector] public SpriteRenderer sprite;

        private void Start() {
            // playerMovement = GetComponent<PlayerMovement>();
            sprite = GetComponent<SpriteRenderer>();
            
            // inventory.SetActive(false);
        }

        /* public void OnInteract(InputAction.CallbackContext context) {
            if (context.performed) {
                switch (action) {
                    case 1:
                        if (LevelController._instance.menuOpen && LevelController._instance.canCraft) {
                            // Close current menu
                            if (LevelController._instance.currentCraftingStation != null && !LevelController._instance.inTutorial) {
                                LevelController._instance.currentCraftingStation.CloseMenu();
                                LevelController._instance.menuOpen = false;
                                canMove = true;
                            }
                        } else {
                            // Open menu
                            if (LevelController._instance.currentCraftingStation != null) {
                                LevelController._instance.currentCraftingStation.Craft();
                                LevelController._instance.menuOpen = true;
                                canMove = false;
                            }
                        }
                    break;

                    case 2:
                        if (!LevelController._instance.boulangerieOpen && !LevelController._instance.goHome) {
                            LevelController._instance.boulangerieOpen = true;
                            LevelController._instance.OpenBoulangerie(LevelController._instance.boulangerieOpen);
                        } else if (LevelController._instance.goHome) {
                            LevelController._instance.boulangerieOpen = false;
                            LevelController._instance.CloseBoulangerie();
                        }
                    break;

                    case 3:
                        // if (LevelController._instance.ActiveNpcAtCounter == null) return; 
                        if (LevelController._instance.canCompleteSale)
                            LevelController._instance.CompleteSale();
                    break;
                }
            }
        } */

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
