using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
    public int score { get; set; }

    void Start () {
        (Tens.gameObject as GameObject).SetActive (false);
        (Hundreds.gameObject as GameObject).SetActive (false);
        if(Medal){(Medal.gameObject as GameObject).SetActive (false);}
        score = 0;
    }

    void Update () {
        if (previousScore != score) {
            if (score < 10) {
                //just draw units
                Units.sprite = numberSprites[score];
            } else if (score >= 10 && score < 100) {
                (Tens.gameObject as GameObject).SetActive (true);
                Tens.sprite = numberSprites[score / 10];
                Units.sprite = numberSprites[score % 10];
                if(Medal){
                    (Medal.gameObject as GameObject).SetActive (true);
                    if(score < 50) {
                        Medal.sprite = medalsSprites[(score / 10) - 1];
                    }
                    else {
                        Medal.sprite = medalsSprites[3];
                    }
                }
                
            } else if (score >= 100) {
                if(Medal){(Medal.gameObject as GameObject).SetActive (true);}
                (Hundreds.gameObject as GameObject).SetActive (true);
                Hundreds.sprite = numberSprites[score / 100];
                int rest = score % 100;
                Tens.sprite = numberSprites[rest / 10];
                Units.sprite = numberSprites[rest % 10];
            }
        }
    }

    int previousScore = -1;
    public Sprite[] numberSprites;
    public Image Units, Tens, Hundreds, Medal;
    public Sprite[] medalsSprites;
}