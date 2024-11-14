using UnityEngine;
using UnityEngine.UI;

public class ControlOptionsMenu : MonoBehaviour
{
    public Toggle gyroscopeToggle;

    private void Start()
    {
        // Load the saved control method preference
        bool useGyroscope = PlayerPrefs.GetInt("ControlMethod", 0) == 1;
        gyroscopeToggle.isOn = useGyroscope;

        gyroscopeToggle.onValueChanged.AddListener(SetControlMethod);
    }

    public void SetControlMethod(bool gyroscope)
    {
        PlayerPrefs.SetInt("ControlMethod", gyroscope ? 1 : 0);
        PlayerPrefs.Save();
    }
}