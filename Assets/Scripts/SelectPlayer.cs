using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{ 
    public int numPlayer, numPlayer2;
    [SerializeField]GameData selectionP;

    public void SelectSpining()
    {
        selectionP.numberOfPlayer = numPlayer;
    }
    public void SelectSpining2()
    {
        selectionP.numberOfPlayer2 = numPlayer2;
    }
}
