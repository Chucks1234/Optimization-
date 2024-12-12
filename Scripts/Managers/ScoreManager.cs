using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public static int score = 0;
    [SerializeField] Text text;

    public ScoreData scoreData;

    void Update()
    {
        text.text = "Score: " + scoreData.amount.ToString();
    }
}
