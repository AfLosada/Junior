using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private TextMeshProUGUI DrainText;
    [SerializeField]
    private TextMeshProUGUI HealthText;

    [Range (0,100)] public float health;
    public float score;
    /*
     This is an example of Encapsulation, because the DrainRate property should only be accessed from this class but it still needs to be set from the PlayerController class
     */
    [Range (1, 20)] private float m_DrainRate;
    public float DrainRate {
        get { return m_DrainRate; }
        set { m_DrainRate = value; } 
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        score = 0;
        StartCoroutine(drainHealth());
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;
        DrainText.text = "Drain Rate: " + m_DrainRate;
        HealthText.text = "Health: " + health;
    }

    IEnumerator drainHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            health -= m_DrainRate;
        }
    }

}
