using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public enum StatType
    {
        Energy,
        Fuel
    }

    public static UIManager Instance;

    public TextMeshProUGUI energyText;
    public TextMeshProUGUI fuelText;

    void Awake()
    {
        Instance = this;
    }

    public void Modify(StatType statType)
    {
        switch (statType)
        {
            case StatType.Energy:
                energyText.GetComponent<Animator>().SetTrigger("Modify");
                break;
            case StatType.Fuel:
                fuelText.GetComponent<Animator>().SetTrigger("Modify");
                break;
        }
    }
}
