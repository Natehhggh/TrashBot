using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    
    public static int points;
    public Text scoreBoard;
    //bool created = false;

	
	void Start () {
        //scoreBoard = GetComponent<Text>();
        reset();
	}
	
    public void score(int x)
    {
        points += x;
        scoreBoard.text = "Score: " + points.ToString();
    }

    public static void reset()
    {
        points = 0;
        //scoreBoard.text = "Score: " + points.ToString();
    }


/*    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }

    }
*/
}
