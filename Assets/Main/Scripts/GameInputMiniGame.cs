using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputMiniGame : MonoBehaviour
{
    public static GameInputMiniGame Instance;

    private PlayerInputActions playerInputActions;

    public event EventHandler OnPauseAction;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.MiniGame.Enable();

        playerInputActions.MiniGame.Pause.performed += Pause_performed;

    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);    
    }
}
