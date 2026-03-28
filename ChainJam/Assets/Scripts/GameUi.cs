using TMPro;
using UnityEngine;

public  class GameUi : MonoBehaviour
{



    public TextMeshProUGUI energyText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI rowBombAmountText;
    public TextMeshProUGUI plusBombAmountText;
    public TextMeshProUGUI crossBombAmountText;


    void Start()
    {
        GameData.energy=100;
        GameData.fuel=100;
        GameData.bombAmount=3;
        GameData.plusBombAmount = 3;
        GameData.crossBombAmount = 3;



        energyText.SetText("Energy: " + GameData.energy);
        fuelText.SetText("Fuel: " + GameData.fuel);

        rowBombAmountText.SetText("x" + GameData.bombAmount);
        crossBombAmountText.SetText("x" + GameData.crossBombAmount);
        plusBombAmountText.SetText("x" + GameData.plusBombAmount);


    }
    void Update()
    {
        energyText.SetText("Energy: " + GameData.energy);
        fuelText.SetText("Fuel: " + GameData.fuel);
        rowBombAmountText.SetText("x" + GameData.bombAmount);
        crossBombAmountText.SetText("x" + GameData.crossBombAmount);
        plusBombAmountText.SetText("x" + GameData.plusBombAmount);
    }


}
