using System.Collections;
using UnityEngine;

public class SpeedBonusCalculator : MonoBehaviour
{
    //[SerializeField] private int SpeedBonus = 50;
    public int SpeedBonus;
    public int SpeedBonusCap = 5000;
    //public GameObject playerInstance;
    /*
    public int GetSpeedBonus()
    {
        return SpeedBonus;
    }
    */

    private Coroutine thisCoroutine;

    public void calculateSpeed()
    {
        //playerInstance.SetActive(true);
        if (thisCoroutine != null)
        {
            StopCoroutine(ReduceValueOverTime());
        }

        thisCoroutine = StartCoroutine(ReduceValueOverTime());
    }

    public void stopCalculator()
    {
        StopCoroutine(ReduceValueOverTime());
    }

    IEnumerator ReduceValueOverTime()
    {
        SpeedBonus = SpeedBonusCap;

        yield return new WaitForSeconds(1f);

        SpeedBonus = SpeedBonus - 1000;

        yield return new WaitForSeconds(1f);

        SpeedBonus = SpeedBonus - 1000;
        
        yield return new WaitForSeconds(1f);

        SpeedBonus = SpeedBonus - 1000;
        
        yield return new WaitForSeconds(1f);

        SpeedBonus = SpeedBonus - 1000;

        yield return new WaitForSeconds(1f);

        SpeedBonus = SpeedBonus - 1000;
        /*
        while (SpeedBonus > 0)
        {

            yield return new WaitForSeconds(1f);

            SpeedBonus = SpeedBonus - 10;
            //Debug.Log("SpeedBonus - 10");

        }
        */
        thisCoroutine = null;
        /*
        if (SpeedBonus <= 0)
        {

            stopCalculator();
            Debug.Log("SpeedBonus Reset!");
        }
        */
    }
    void OnDisable()
    {
        Debug.Log(gameObject.name + " got disabled");
    }
    void OnEnable()
    {
        Debug.Log(gameObject.name + " is enabled");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        calculateSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        //SpeedBonusCapping
        if (SpeedBonus <= 0)
        {
            
            SpeedBonus = 0;
            thisCoroutine = null;

        }

    }
}
