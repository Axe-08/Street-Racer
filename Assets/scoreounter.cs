using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreounter : MonoBehaviour
{
    public logicControl logicControl;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")&&logicControl.isPlayerAlive)
        {
            logicControl.updateScore();
        }
    }
}
