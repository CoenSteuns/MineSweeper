using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeperNode : Node {

    public bool isMine = false;


    private void OnMouseDown()
    {


        if (isMine)
        {
            print("gameOver");
        }



    }
}
