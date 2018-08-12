using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreader : MonoBehaviour {

    public ScoreKeeper scoreBoard;


    void OnTriggerEnter(Collider col)
    {

        scoreBoard.score(1);
        Destroy(col.gameObject);
    }
}
