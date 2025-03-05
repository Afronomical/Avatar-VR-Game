using UnityEngine;
using System;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "Scriptable Objects/AbilitySO")]
public class AbilitySO : ScriptableObject
{
    [SerializeField] GestureDataSO[] GesturesInCombo;

    [SerializeField] public float cooldownTime = 0.7f;

    protected int currentGetsureIndex = 0;

    public virtual void ResetAbility()
    {
        currentGetsureIndex = 0;
    }

    public static event Action OnActivate;
}
