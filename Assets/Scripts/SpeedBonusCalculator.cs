using System.Collections;
using UnityEngine;

public class SpeedBonusCalculator : MonoBehaviour
{
    [SerializeField] private int SpeedBonus = 5;

    public int GetSpeedBonus()
    {
        return SpeedBonus;
    }

    IEnumerator ReduceValueOverTime()
    {
        while (SpeedBonus > 0)
        {
            yield return new WaitForSeconds(1f);

            SpeedBonus--;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
