using TMPro;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI rowBombAmountText;
    public TextMeshProUGUI plusBombAmountText;
    public TextMeshProUGUI crossBombAmountText;
    [SerializeField] private GameObject controls;
    Animator anim;

    void Start()
    {
        controls.SetActive(true);
        energyText.SetText(GameData.energy.ToString());
        fuelText.SetText(GameData.fuel.ToString());
        rowBombAmountText.SetText("x" + GameData.bombAmount);
        crossBombAmountText.SetText("x" + GameData.crossBombAmount);
        plusBombAmountText.SetText("x" + GameData.plusBombAmount);
        anim = controls.GetComponent<Animator>();
    }
    void Update()
    {
        energyText.SetText(GameData.energy.ToString());
        fuelText.SetText(GameData.fuel.ToString());
        rowBombAmountText.SetText("x" + GameData.bombAmount);
        crossBombAmountText.SetText("x" + GameData.crossBombAmount);
        plusBombAmountText.SetText("x" + GameData.plusBombAmount);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("MoveDown");
        }
    }
}