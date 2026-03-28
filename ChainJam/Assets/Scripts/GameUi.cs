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



        energyText.SetText("Energy: " + GameData.energy);
        fuelText.SetText("Fuel: " + GameData.fuel);
        rowBombAmountText.SetText("Bomb: " + GameData.bombAmount);

        crossBombAmountText.SetText("Cross Bomb: " + GameData.crossBombAmount);
        XBombAmountText.SetText("Plus Bomb: " + GameData.plusBombAmount);


    }
    void Update()
    {
        energyText.SetText("Energy: " + GameData.energy);
        fuelText.SetText("Fuel: " + GameData.fuel);
        rowBombAmountText.SetText("Bomb: " + GameData.bombAmount);
        crossBombAmountText.SetText("Cross Bomb: " + GameData.crossBombAmount);
        XBombAmountText.SetText("Plus Bomb: " + GameData.plusBombAmount);
    }


}
