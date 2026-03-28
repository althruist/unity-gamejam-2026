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



        energyText.SetText(GameData.energy.ToString());
        fuelText.SetText( GameData.fuel.ToString());

        rowBombAmountText.SetText("x" + GameData.bombAmount);
        crossBombAmountText.SetText("x" + GameData.crossBombAmount);
        plusBombAmountText.SetText("x" + GameData.plusBombAmount);


    }
    void Update()
    {
        energyText.SetText(GameData.energy.ToString());
        fuelText.SetText( GameData.fuel.ToString());
        rowBombAmountText.SetText("x" + GameData.bombAmount);
        crossBombAmountText.SetText("x" + GameData.crossBombAmount);
        plusBombAmountText.SetText("x" + GameData.plusBombAmount);
    }


}
