using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
    public int score { get; set; }

    // Use this for initialization
    void Start () {
        (Tens.gameObject as GameObject).SetActive (false);
        (Hundreds.gameObject as GameObject).SetActive (false);
        score = 0;
    }

    // Update is called once per frame
    void Update () {
        if (previousScore != score) {
            if (score < 10) {
                //just draw units
                Units.sprite = numberSprites[score];
            } else if (score >= 10 && score < 100) {
                (Tens.gameObject as GameObject).SetActive (true);
                Tens.sprite = numberSprites[score / 10];
                Units.sprite = numberSprites[score % 10];
            } else if (score >= 100) {
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
    public Image Units, Tens, Hundreds;
}