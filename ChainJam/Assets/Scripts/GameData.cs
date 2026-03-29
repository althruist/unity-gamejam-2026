using UnityEngine;

public enum LevelType
{
    Normal, EneFuel, Bomb, Crate
}

public abstract class GameData
{
    public static int energy =50;
    public static int fuel=0;
    public static int fuelToWin = 200;
    public static int lasersinScene = 0;



    
    public static int bombAmount =3;
    public static int crossBombAmount=3;
    public static int plusBombAmount = 3;
    public static int bombLevel = 1;
    public static int plusBombLevel = 1;
    public static int crossBombLevel = 1;

    public static LevelType levelType = LevelType.Normal;


    public static int gridLenght = 10; 


}
