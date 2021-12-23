using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreData : MonoBehaviour {

    public int score;
    public Text ScoreText;
    public Text AddScoreText;
    public bool isCombo;
    public float comboTimer;
    private bool startedCoroutine;
    private int multiplier;


    void Start ()
    {
        startedCoroutine = false;
        multiplier = 1;
        isCombo = false;
        score = 0;
        comboTimer = 0;
        ScoreText.text = "0";
        AddScoreText.text = "";
    }

    public void AddScore(int amount)
    {
        AddScoreText.text = amount.ToString();
        if (isCombo) multiplier += 1;
        else multiplier = 1;

        score += amount * multiplier;
        isCombo = true;

        if (startedCoroutine) StopAllCoroutines();
        StartCoroutine(StartComboTimer(amount));
        ScoreText.text = score.ToString();
        StartCoroutine(StopAnim());
    }
    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.8f);
        AddScoreText.text = "";
    }


    IEnumerator StartComboTimer(int amount)
    {
        startedCoroutine = true;
        yield return new WaitForSeconds(0.5f);
        isCombo = false;
        startedCoroutine = false;
    }
}
