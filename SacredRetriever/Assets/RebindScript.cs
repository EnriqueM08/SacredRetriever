using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RebindScript : MonoBehaviour
{
    [SerializeField] private InputActionReference attackAction = null;
    [SerializeField] private InputActionReference walkAction = null;
    [SerializeField] private Text bindingDisplayLeftText = null;
    [SerializeField] private Text bindingDisplayRightText = null;
    [SerializeField] private Text bindingDisplayUpText = null;
    [SerializeField] private Text bindingDisplayDownText = null;
    [SerializeField] private Text bindingDisplayAttackText = null;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    public Canvas options;
    public Canvas keyBinds;

    public void StartRebinding() {
        EventSystem.current.SetSelectedGameObject(null);
        attackAction.action.Disable();
        bindingDisplayAttackText.text = "PRESS ANY BUTTON";
        rebindingOperation = attackAction.action.PerformInteractiveRebinding()
    
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(
            operation =>
            {
                bindingDisplayAttackText.text = InputControlPath.ToHumanReadableString(attackAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
                rebindingOperation.Dispose();
                attackAction.action.Enable();
            }
        )
        .Start();
    }

    public void StartRebindingLeft() {
        EventSystem.current.SetSelectedGameObject(null);
        walkAction.action.Disable();
        bindingDisplayLeftText.text = "PRESS ANY BUTTON";
        rebindingOperation = walkAction.action.PerformInteractiveRebinding()
        .WithTargetBinding(3)
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(
            operation =>
            {
                bindingDisplayLeftText.text = InputControlPath.ToHumanReadableString(walkAction.action.bindings[3].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
                rebindingOperation.Dispose();
                walkAction.action.Enable();
            }
        )
        .Start();
    }

    public void StartRebindingRight() {
        EventSystem.current.SetSelectedGameObject(null);
        walkAction.action.Disable();
        bindingDisplayRightText.text = "PRESS ANY BUTTON";
        rebindingOperation = walkAction.action.PerformInteractiveRebinding()
        .WithTargetBinding(4)
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(
            operation =>
            {
                bindingDisplayRightText.text = InputControlPath.ToHumanReadableString(walkAction.action.bindings[4].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
                rebindingOperation.Dispose();
                walkAction.action.Enable();
            }
        )
        .Start();
    }

    public void StartRebindingUp() {
        EventSystem.current.SetSelectedGameObject(null);
        walkAction.action.Disable();
        bindingDisplayUpText.text = "PRESS ANY BUTTON";
        rebindingOperation = walkAction.action.PerformInteractiveRebinding()
        .WithTargetBinding(1)
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(
            operation =>
            {
                bindingDisplayUpText.text = InputControlPath.ToHumanReadableString(walkAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
                rebindingOperation.Dispose();
                walkAction.action.Enable();
            }
        )
        .Start();
    }

    public void StartRebindingDown() {
        EventSystem.current.SetSelectedGameObject(null);
        walkAction.action.Disable();
        bindingDisplayDownText.text = "PRESS ANY BUTTON";
        rebindingOperation = walkAction.action.PerformInteractiveRebinding()
        .WithTargetBinding(2)
        .OnMatchWaitForAnother(0.1f)
        .OnComplete(
            operation =>
            {
                bindingDisplayDownText.text = InputControlPath.ToHumanReadableString(walkAction.action.bindings[2].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
                rebindingOperation.Dispose();
                walkAction.action.Enable();
            }
        )
        .Start();
    }

    public void GoBack() {
        keyBinds.enabled = false;
        options.enabled = true;
    }

    public void GoToRebindScreen() {
        options.enabled = false;
        keyBinds.enabled = true;
    }
}
