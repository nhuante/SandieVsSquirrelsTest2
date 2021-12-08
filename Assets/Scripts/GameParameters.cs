using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters : MonoBehaviour
{
    // corgi
    public static float MinimumDistancefromCorgi = 1.5f;
    public static int CorgiLives = 5;

    // mega squirrel
    public static int TimesToMoveInSameRandomDirectionMegaSquirrel = 1400;
    public static int MegaSquirrelLives = 3;

    // crack squirrel
    public static float CrackSquirrelMoveAmount = 0.002f;
    public static int CrackSquirrelLives = 2;

    // normal squirrel
    public static float RangeToShootFor = 5f;
    public static int NormalSquirrelLives = 1;

    // acorn
    public static float AcornSpeed = 0.05f;
}
