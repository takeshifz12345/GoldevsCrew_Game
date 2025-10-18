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
    private InputAction moveAction;
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
        moveAction = actionMap.FindAction("Move", true);
        jumpAction = actionMap.FindAction("Jump", true);
        shootAction = actionMap.FindAction("Shoot", true);
        callAction = actionMap.FindAction("Call", true);

        // Asignar callbacks
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

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

    void OnMove(InputAction.CallbackContext ctx)
    {
        if (!inputsEnabled || playerController == null) return;
        float moveValue = ctx.ReadValue<float>(); // -1 izquierda, 0 quieto, 1 derecha
        playerController.Move(moveValue);
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