using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCalculator : MonoBehaviour
{
    public InventoryCar inventoryCar = null;

    public Text doleritoMoney;
    public Text granadaMoney;
    public Text esmeraldaMoney;
    public Text turmalinaMoney;
    public Text chaveMoney;

    public Text totalMoney;

    bool timeIsUp = false;
    bool canClose = false;
    
    int moneyFios = 0;
    int moneyBateria = 0;
    int moneyEngrenagem = 0;
    int moneyParafuso = 0;
    int moneyChave = 0;

    public Goal goal = null;
    public PlayerManager player;

    public int total = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsUp && canClose &&(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space) ) )
        {
            OpenMoneyCalculator();
            // goal.CalculateWinOrLose();
        }
    }
    
    public void ResetCalculator()
    {
        total = 0;

        timeIsUp = false;
        canClose = false;

        moneyFios = 0;
        moneyBateria = 0;
        moneyEngrenagem = 0;
        moneyParafuso = 0;
        moneyChave = 0;
    }

    public void Calculate()
    {
        var collectedOres = inventoryCar.collectedOres;
        moneyFios = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Fios);
        moneyBateria = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Bateria);
        moneyEngrenagem = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Engrenagem);
        moneyParafuso = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Parafuso);
        moneyChave = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Chave);
        
        Text(inventoryCar.collectedOres);
    }

    public void Text(InventoryCar.CollectedOre[] ores)
    {
        foreach (var ore in ores)
        {
            switch (ore.oreType) 
            {
                case (int)Constants.Ore.Fios:
                    doleritoMoney.text = ore.amount + " x 2 açais = " + moneyFios;
                    break;
                case (int)Constants.Ore.Bateria:
                    granadaMoney.text = ore.amount + " x 1 paçoca = " + moneyBateria;
                    break;
                case (int)Constants.Ore.Engrenagem:
                    esmeraldaMoney.text = ore.amount + " x 1 açai = " + moneyEngrenagem;
                    break;
                case (int)Constants.Ore.Parafuso:
                    turmalinaMoney.text = ore.amount + " x 2 paçocas = " + moneyParafuso;
                    break;
                case (int)Constants.Ore.Chave:
                    chaveMoney.text = ore.amount + " x me vê 3 = " + moneyChave;
                    break;
            }
        }
        total = moneyFios + moneyBateria + moneyEngrenagem + moneyParafuso;
        totalMoney.text = total + " gold";
    }

    public int CalculateOre(InventoryCar.CollectedOre[] ores, Constants.Ore oreType)
    {
        int total = 0;
        foreach (var ore in ores)
        {
            if (ore.oreType == (int)oreType)
            {
                switch (oreType)
                {
                    case Constants.Ore.Fios:
                        total = ore.amount * 2;
                        break;
                    case Constants.Ore.Bateria:
                        total = ore.amount * 1;
                        break;
                    case Constants.Ore.Engrenagem:
                        total = ore.amount * 1;
                        break;
                    case Constants.Ore.Parafuso:
                        total = ore.amount * 2;
                        break;
                    case Constants.Ore.Chave:
                        total = ore.amount * 0;
                        break;
                }
            }
        }
        return total;
    }

    public void OpenMoneyCalculator()
    {
        player.canMove = false;
        var child = this.transform.GetChild(0);
        
        child.gameObject.SetActive(true);
        timeIsUp = true;
        Calculate();
        StartCoroutine(CanClose());
        StartCoroutine(AutomaticGoal());
        
        //
        // if (child.gameObject.activeSelf)
        // {
        //     child.gameObject.SetActive(false);
        //     Time.timeScale = 1;
        //     timeIsUp = false;
        // }
        // else
        // {
        //
        // }
    }

    IEnumerator CanClose()
    {
        yield return new WaitForSeconds(2);
        canClose = true;
    }

    IEnumerator AutomaticGoal()
    {
        yield return new WaitForSeconds(10);

        if (timeIsUp) {
            player.canMove = true;
            OpenMoneyCalculator();
            // goal.CalculateWinOrLose();
        }
    }
}
