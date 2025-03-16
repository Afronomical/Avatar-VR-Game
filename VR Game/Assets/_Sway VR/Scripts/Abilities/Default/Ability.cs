using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class Ability : MonoBehaviour
{
    public string abilityName = "DefaultAbilityName";
    [Tooltip("The time the player must complete the gestures, in order to activate the ability")]
    public float activationTimer = 1f;

    [Tooltip("The time the player must wait to activate the ability since the previous activation")]
    public float cooldownTimer = 0.5f;
    bool isCooldownComplete = true;

    bool _isActive = false;
    protected bool isActive
    {
        get { return _isActive; } 
        set { _isActive = value;  gestureIndex = 0; }
    }

    protected int gestureIndex = 0;
    [Tooltip("The sequence of gestures the player must complete to activate an ability")]
    [SerializeField]protected GestureDataSO[] requiredGestures;

    public AbilityManager abilityManager;

    public void Initialize(AbilityManager _abilityManager)
    {
        abilityManager = _abilityManager;
    }
    public void SetActive(bool _isActive)
    {
        isActive= _isActive;

        gestureIndex = 0;
    }

    
    
    protected void StartCooldown()
    {
        StartCoroutine(BeginCooldown());
    }

    IEnumerator BeginCooldown()
    {
        isCooldownComplete = false;

        yield return new WaitForSeconds(cooldownTimer);

        gestureIndex = 0;
        isCooldownComplete = true;
    }

}
