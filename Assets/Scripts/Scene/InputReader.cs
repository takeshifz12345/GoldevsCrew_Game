using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public InputActionAsset inputActionPlayer;
    public string actionMapName;
    public PlayerController playerController;
    public PlayerShoot playerShoot;
    public PlayerHealth playerHealth;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction callAction;

    private bool inputsEnabled;

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
        var actionMap = inputActionPlayer.FindActionMap(actionMapName, true);

        moveAction = actionMap.FindAction("Move", true);
        jumpAction = actionMap.FindAction("Jump", true);
        shootAction = actionMap.FindAction("Shoot", true);
        callAction = actionMap.FindAction("Call", true);

        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        jumpAction.performed += OnJump;
        shootAction.performed += OnShoot;
        callAction.performed += OnCall;
    }

    public void EnableInput()
    {
        inputActionPlayer.FindActionMap(actionMapName, true).Enable();
        inputsEnabled = true;
    }

    public void DisableInput()
    {
        inputActionPlayer.FindActionMap(actionMapName, true).Disable();
        inputsEnabled = false;
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerController == null) return;
        float moveValue = ctx.ReadValue<float>();
        playerController.Move(moveValue);
    }

    void OnJump(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerController == null) return;
        if (ctx.performed) playerController.Jump();
    }

    void OnShoot(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerShoot == null || playerController == null || playerHealth == null) return;

        if (ctx.performed)
        {
            // Usa la dirección actual del jugador
            int dir = playerController.ultDirection;
            playerShoot.Shoot(dir);
            playerHealth.TakeDamage(1);
        }
    }

    void OnCall(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerHealth == null) return;

        if (ctx.performed)
            playerHealth.Heal();
    }


    void Start()
    {
        Initialize(playerController, playerShoot, playerHealth, inputActionPlayer, actionMapName);
        ConfigureActions();
        EnableInput();
    }
}