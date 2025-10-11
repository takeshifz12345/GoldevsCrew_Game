using UnityEngine;
using UnityEngine.InputSystem;

public class InpurReader : MonoBehaviour
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

    }

    public void ConfigureActions()
    {

    }

    public void EnableInput()
    {

    }

    public void DisableInput()
    {

    }

    void OnMoveLeft(InputAction.CallbackContext ctx)
    {

    }

    void OnMoveRight(InputAction.CallbackContext ctx)
    {

    }

    void OnJump(InputAction.CallbackContext ctx)
    {

    }

    void OnShoot(InputAction.CallbackContext ctx)
    {

    }

    void OnCall(InputAction.CallbackContext ctx)
    {

    }
}