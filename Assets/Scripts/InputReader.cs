using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public InputActionAsset inputActionPlayer;
    public string actionMapName;
    public PlayerController playerController;
    public PlayerShoot playerShoot;
    public PlayerHealth playerHealth;
    public bool inputsEnabled;
    public InputAction moveLeftAction;
    public InputAction moveRightAction;
    public InputAction jumpAction;
    public InputAction shootAction;
    public InputAction callAction;

    public void Initialize(PlayerController pc, PlayerShoot ps, PlayerHealth ph, InputActionAsset inputAsset, string mapName)
    {
        playerController = pc;
        playerShoot = ps;
        playerHealth = ph;
        inputActionPlayer = inputAsset;
        actionMapName = mapName;
        inputsEnabled = false;
    }

    public void ConfigureActions()
    {
        // Buscar el Action Map
        var actionMap = inputActionPlayer.FindActionMap(actionMapName, true);

        // Buscar cada acción
        moveLeftAction = actionMap.FindAction("MoveLeft", true);
        moveRightAction = actionMap.FindAction("MoveRight", true);
        jumpAction = actionMap.FindAction("Jump", true);
        shootAction = actionMap.FindAction("Shoot", true);
        callAction = actionMap.FindAction("Call", true);

        // Asignar callbacks
        moveLeftAction.performed += OnMoveLeft;
        moveLeftAction.canceled += OnMoveLeft;

        moveRightAction.performed += OnMoveRight;
        moveRightAction.canceled += OnMoveRight;

        jumpAction.performed += OnJump;
        shootAction.performed += OnShoot;
        callAction.performed += OnCall;
    }

    public void EnableInput()
    {
        var actionMap = inputActionPlayer.FindActionMap(actionMapName, true);
        actionMap.Enable();
        inputsEnabled = true;
    }


    public void DisableInput()
    {
        var actionMap = inputActionPlayer.FindActionMap(actionMapName, true);
        actionMap.Disable();
        inputsEnabled = false;
    }

    void OnMoveLeft(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerController == null) return;

        if (ctx.performed) // Cuando se presiona
            playerController.Move(-1);
        else if (ctx.canceled) // Cuando se suelta
            playerController.Move(0);
    }

    void OnMoveRight(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerController == null) return;

        if (ctx.performed)
            playerController.Move(1);
        else if (ctx.canceled)
            playerController.Move(0);
    }

    void OnJump(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerController == null) return;

        if (ctx.performed)
        {
            playerController.Jump();
        }
    }

    void OnShoot(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerShoot == null) return;

        if (ctx.performed)
        {
            playerShoot.Shoot();
        }
    }

    void OnCall(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerHealth == null) return;

        if (ctx.performed)
        {
            playerHealth.Heal();
        }
    }

    void Start()
    {
        Initialize(playerController, playerShoot, playerHealth, inputActionPlayer, actionMapName);
        ConfigureActions();
        EnableInput();
    }
}