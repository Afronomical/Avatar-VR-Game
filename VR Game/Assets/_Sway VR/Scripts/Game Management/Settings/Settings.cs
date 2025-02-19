using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

public class Settings : MonoBehaviour
{ 
    

    [Header("Rotation Settings")]


    [SerializeField] SnapTurnProvider snapTurnScript;
    [SerializeField] bool snapRotation;

    [SerializeField] int snapByDegrees;
    int minSnap, maxSnap;

    public bool isSnapRotating
    {
        get { return isSnapRotating; }
        set { isSnapRotating = value; }
    }

      [Space]


    [SerializeField] ContinuousTurnProvider contTurnProvider;
    [SerializeField] public int turnSensitivity
    {
        get { return turnSensitivity; }

        set { turnSensitivity = Mathf.Clamp(value, minSnap, maxSnap); }
    }
    


   
    public void SaveSettings()
    {
        SaveSystem.SaveSettings(this);
    }

    public void LoadSettings()
    {
        //SettingsData data = SaveSystem.LoadSettings();

        //level = data.level
        //vice versa
    }
}
