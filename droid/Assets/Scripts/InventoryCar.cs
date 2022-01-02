using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCar : MonoBehaviour
{
    Sprite obj1;
    Sprite obj2;
    Sprite obj3;
    Sprite obj4;

    public Sprite Fios;
    public Sprite Bateria; 
    public Sprite Engrenagem;
    public Sprite Parafuso;
    public Sprite Chave;

    //public int[] pontos = new int[] { 0, 0, 0, 0 };

    public struct CollectedOre
    {
        public Sprite sprite;
        public int amount;
        public int oreType;
    }

    public CollectedOre[] collectedOres = new CollectedOre[4];

    int inventoryAmout = 0;

    public void CleanCar()
    {
        collectedOres = new CollectedOre[4];
        inventoryAmout = 0;
        obj1 = null;
        obj2 = null;
        obj3 = null;
        obj4 = null;
    }

    public int SwitchOre(Sprite obj)
    {
        if (obj == Fios)
        {
            return (int)Constants.Ore.Fios;
        }
        else if (obj == Bateria)
        {
            return (int)Constants.Ore.Bateria;
        }
        else if (obj == Engrenagem)
        {
            return (int)Constants.Ore.Engrenagem;
        }
        else if (obj == Chave)
        {
            return (int)Constants.Ore.Chave;
        }
        return (int)Constants.Ore.Parafuso;
    }

    public void AddInventoryImage()
    {
        var canvas = transform.GetChild(0);
        var panel = canvas.GetChild(0);
        foreach (Transform child in panel.transform)
        {
            switch (inventoryAmout)
            {
                case 0:
                    //N�o entra nesse caso
                    break;
                case 1:
                    if (child.gameObject.name == "Obj1" && obj1 != null)
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj1;

                    }
                    break;
                case 2:
                    if (child.gameObject.name == "Obj2" && obj2 != null)
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj2;

                    }
                    break;
                case 3:
                    if (child.gameObject.name == "Obj3" && obj3 != null)
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj3;
                    }
                    break;
                case 4:
                    if (child.gameObject.name == "Obj4" && obj4 != null)
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj4;
                        //inventoryFull = true;
                    }
                    break;
            }
        }
    }

    public void AddPoints(Sprite newObj)
    {
        if (newObj == collectedOres[0].sprite)
        {
            //pontos[0]++;
            collectedOres[0].amount++;
        }
        else if (newObj == collectedOres[1].sprite)
        {
            //pontos[1]++;
            collectedOres[1].amount++;
        }
        else if (newObj == collectedOres[2].sprite)
        {
            //pontos[2]++;
            collectedOres[2].amount++;
        }
        else if (newObj == collectedOres[3].sprite)
        {
            collectedOres[3].amount++;
            //pontos[2]++;
        }
    }

    public void ReceiveObject(Sprite newObj)
    {
        switch (inventoryAmout)
        {
            case 0:
                obj1 = newObj;
                collectedOres[0].sprite = newObj;
                inventoryAmout++;
                collectedOres[0].amount++;
                //pontos[0]++;
                AddInventoryImage();
                collectedOres[0].oreType = SwitchOre(collectedOres[0].sprite);
                break;
            case 1:
                if (newObj != collectedOres[0].sprite)
                {
                    obj2 = newObj;
                    collectedOres[1].sprite = newObj;
                    collectedOres[1].amount++;
                    //pontos[1]++;
                    inventoryAmout++;
                    AddInventoryImage();
                    collectedOres[1].oreType = SwitchOre(collectedOres[1].sprite);
                }
                else
                {
                    collectedOres[0].amount++;
                    //pontos[0]++;
                }
                break;
            case 2:
                if (newObj != collectedOres[1].sprite && newObj != collectedOres[0].sprite)
                {
                    obj3 = newObj;
                    collectedOres[2].sprite = newObj;
                    collectedOres[2].amount++;
                    //pontos[2]++;
                    inventoryAmout++;
                    AddInventoryImage();
                    collectedOres[2].oreType = SwitchOre(collectedOres[2].sprite);
                }
                else if (newObj == collectedOres[0].sprite)
                {
                    collectedOres[0].amount++;
                    //pontos[0]++;
                }
                else if (newObj == collectedOres[1].sprite)
                {
                    collectedOres[1].amount++;
                    //pontos[1]++;
                }
                break;
            case 3:
                if (newObj != collectedOres[2].sprite && newObj != collectedOres[1].sprite && newObj != collectedOres[0].sprite)
                {
                    obj4 = newObj;
                    collectedOres[3].sprite = newObj;
                    collectedOres[3].amount++;
                    inventoryAmout++;
                    //pontos[3]++;
                    AddInventoryImage();
                    collectedOres[3].oreType = SwitchOre(collectedOres[3].sprite);
                }
                else if (newObj == collectedOres[0].sprite)
                {
                    collectedOres[0].amount++;
                    //pontos[0]++;
                }
                else if (newObj == collectedOres[1].sprite)
                {
                    collectedOres[1].amount++;
                    //pontos[1]++;
                }
                else if (newObj == collectedOres[2].sprite)
                {
                    collectedOres[2].amount++;
                    // pontos[2]++;
                }
                break;
            case 4:
                AddPoints(newObj);
                break;
        }
    }
}
