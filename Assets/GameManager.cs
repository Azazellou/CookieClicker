using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // int result;

    private int Trees { get; set; }
    
    public float cooldown;

    private float counter;

    public Text TreesText;

    


    public List<string> Names = new List<string>();

    public List<int> Numbers = new List<int>();

    public List<int> Costs = new List<int>();

    public List<int> Cooldowns = new List<int>();

    public List<int> Rates = new List<int>();

    private List<float> Counters = new List<float>() { 0, 0, 0, 0 };




    public Text CultivatorButtonText;
    public Text FertilizerButtonText;
    public Text MachineButtonText;
    public Text RobotButtonText;


    // Start is called before the first frame update
    void Start()
    {
        Trees = 0;
        TreesText.text = "Trees : 0";
        /* result = 0;
        result = 5 + 2;
        Debug.Log(result);
        for (int i = 0; i<20; i++)
        {
            Increment();
        }
        */
    }

    public void ManualIncrement()
    {
        Trees = Increment(1);
    }

    public void BuyCultivator()
    {
        if (Trees >= Costs[0])
        {
            Trees -= Costs[0];
            UpdateTreesDisplay(Trees);
            Numbers[0]++;
            CultivatorButtonText.text = Names[0] + " : " + Numbers[0].ToString();
        }
    }

    public void BuyFertilizer()
    {
        if (Trees >= Costs[1])
        {
            Trees -= Costs[1];
            UpdateTreesDisplay(Trees);
            Numbers[1]++;
            FertilizerButtonText.text = Names[1] + " : " + Numbers[1].ToString();
        }
    }

    public void BuyMachine()
    {
        if (Trees >= Costs[2])
        {
            Trees -= Costs[2];
            UpdateTreesDisplay(Trees);
            Numbers[2]++;
            MachineButtonText.text = Names[2] + " : " + Numbers[2].ToString();
        }
    }
    
    public void BuyRobot()
    {
        if (Trees >= Costs[3])
        {
            Trees = Costs[3];
            UpdateTreesDisplay(Trees);
            Numbers[3]++;
            RobotButtonText.text = Names[3] + " : " + Numbers[3].ToString();
        }
    }
    
    public int Increment(int value)
    {
        int total = Trees + value;

        UpdateTreesDisplay(total);

        return total;
    }

  

    /*
    int Add (int a; int b)
     {
        int resultaLocal = a + b;
        Debug.Log (resultaLocal);
        return resultaLocal;
     }
    */
    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Counters[0] += Time.deltaTime; // Cultivator counter
        Counters[1] += Time.deltaTime; // Fertilizer counter
        Counters[2] += Time.deltaTime; // Machine counter
        Counters[3] += Time.deltaTime; // Robot counter

        if (counter >= cooldown)
        {
            Trees = Increment(1);
            counter -= cooldown;
        }

        if (Counters[0] >= Cooldowns[0])
        {
            Trees = Increment(Rates[0] * Numbers[0]);
            Counters[0] -= Cooldowns[0];
        }

        if (Counters[1] >= Cooldowns[1])
        {
            Trees = Increment(Rates[1] * Numbers[1]);
            Counters[1] -= Cooldowns[1];
        }

        if (Counters[2] >= Cooldowns[2])
        {
            Trees = Increment(Rates[2] * Numbers[2]);
            Counters[2] -= Cooldowns[2];
        }
        
        if (Counters[3] >= Cooldowns[3])
        {
            Trees = Increment(Rates[3] * Numbers[3]);
            Counters[3] -= Cooldowns[3];
        }
    }

    private void UpdateTreesDisplay(int newNumber)
    {
        TreesText.text = "Trees : " + newNumber.ToString();

    }
}
