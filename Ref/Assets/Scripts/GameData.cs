using UnityEngine;

public enum Dir { Up, Down, Left, Right }

public abstract class GameData
{
    public static float MoveUnit = 1;
    public static int MaxStamina = 100;

    public static int score;
    public static int stamina;
    public static int level = 1;
    

    public static Vector3 GetVector3FromDir(Dir dir)
    {
        switch (dir)
        {
            case Dir.Up:
                return Vector3.up;
            case Dir.Down:
                return Vector3.down;
            case Dir.Left:
                return Vector3.left;
            case Dir.Right:
                return Vector3.right;
        }

        return Vector3.zero;
    }

    public static Vector3 MousePos
    {
        get { return GetMousePos(); }
    }

    private static Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static float XMin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x; }
    }

    public static float XMax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x; }
    }

    public static float YMin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y; }
    }

    public static float YMax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y; }
    }
}
