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
        GameData.bombAmount=3;
        GameData.plusBombAmount = 3;
        GameData.crossBombAmount = 3;



        energyText.SetText("Energy: " + GameData.energy);
        fuelText.SetText("Fuel: " + GameData.fuel);
        rowBombAmountText.SetText("Row Bomb: " + GameData.bombAmount);

        crossBombAmountText.SetText("Cross Bomb: " + GameData.crossBombAmount);
        XBombAmountText.SetText("X Bomb: " + GameData.plusBombAmount);


    }


}
