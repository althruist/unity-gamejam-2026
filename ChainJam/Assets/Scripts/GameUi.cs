using TMPro;
using UnityEngine;

public  class GameUi : MonoBehaviour
{



    public TextMeshProUGUI energyText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI rowBombAmountText;
    public TextMeshProUGUI crossBombAmountText;
    public TextMeshProUGUI XBombAmountText;


    void Start()
    {
        GameData.energy=100;
        GameData.fuel=100;
        GameData.rowBombAmount=3;
        GameData.xBombAmount = 3;
        GameData.crossBombAmount = 3;



        energyText.SetText("Energy: " + GameData.energy);
        fuelText.SetText("Fuel: " + GameData.fuel);
        rowBombAmountText.SetText("Fuel: " + GameData.rowBombAmount);

        crossBombAmountText.SetText("Fuel: " + GameData.crossBombAmount);
        XBombAmountText.SetText("Fuel: " + GameData.xBombAmount);


    }


}
