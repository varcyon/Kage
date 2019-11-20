using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Magic : MonoBehaviour
{

    public static Magic Instance { get; set; }
    void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int HellFire = 0;
    public int PurgatoryWater = 0;
    public int HeavenMetal = 0;

    public int magicPurchaseAmount = 10;
    public int ultimateSkillPurchase = 100;

    public List<int> HeavenMetalWeapon = new List<int>();
    public List<int> HeavenMetalWeaponMax = new List<int>();
    public List<GameObject> HMButton = new List<GameObject>();
    public List<TextMeshProUGUI> HMSkillLevel = new List<TextMeshProUGUI>();
    public int HMSkillTotal = 0;

    public List<int> HellFireWeapon = new List<int>();
    public List<int> HellFireWeaponMax = new List<int>();
    public List<GameObject> HFButton = new List<GameObject>();
    public List<TextMeshProUGUI> HFSkillLevel = new List<TextMeshProUGUI>();
    public int HFSkillTotal = 0;


    public List<int> PurgatoryWaterWeapon = new List<int>();
    public List<int> PurgatoryWaterWeaponMax = new List<int>();
    public List<GameObject> PWButton = new List<GameObject>();
    public List<TextMeshProUGUI> PWSkillLevel = new List<TextMeshProUGUI>();
    public int PWSkillTotal = 0;


    void Awake()
    {
        MakeSingleton();
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        ButtonStatus();
    }

    void ButtonStatus()
    {
        for (int i = 0; i < 10; i++)
        {
            HFSkillLevel[i].text = HellFireWeapon[i].ToString();
            HMSkillLevel[i].text = HeavenMetalWeapon[i].ToString();
            PWSkillLevel[i].text = PurgatoryWaterWeapon[i].ToString();

            if (HellFireWeapon[i] == HellFireWeaponMax[i])
            {
                HFButton[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                HFButton[i].GetComponent<Button>().interactable = true;
            }

            if (HeavenMetalWeapon[i] == HeavenMetalWeaponMax[i])
            {
                HMButton[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                HMButton[i].GetComponent<Button>().interactable = true;
            }

            if (PurgatoryWaterWeapon[i] == PurgatoryWaterWeaponMax[i])
            {
                PWButton[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                PWButton[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void PurchaseHF1()
    {
        if (HellFire > magicPurchaseAmount)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[0]++;
            HFSkillTotal++;
        }
    }
    public void PurchaseHF2()
    {
        if (HellFire > magicPurchaseAmount)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[1]++;
            HFSkillTotal++;
        }
    }
    public void PurchaseHF3()
    {
        if (HellFire > magicPurchaseAmount)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[2]++;
            HFSkillTotal++;
        }
    }

    public void PurchaseHF4()
    {
        if (HellFire > magicPurchaseAmount)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[3]++;
            HFSkillTotal++;
        }
    }
    public void PurchaseHF5()
    {
        if (HellFire > magicPurchaseAmount && HellFireWeapon[1] >= 1)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[4]++;
            HFSkillTotal++;
        }
    }
    public void PurchaseHF6()
    {
        if (HellFire > magicPurchaseAmount && HellFireWeapon[4] >= 1)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[5]++;
            HFSkillTotal++;
        }
    }
    public void PurchaseHF7()
    {
        if (HellFire > magicPurchaseAmount && HellFireWeapon[2] >= 1)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[6]++;
            HFSkillTotal++;
        }
    }
    public void PurchaseHF8()
    {
        if (HellFire > magicPurchaseAmount && HellFireWeapon[3] >= 1)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[7]++;
            HFSkillTotal++;
        }
    }
    public void PurchaseHF9()
    {
        if (HellFire > magicPurchaseAmount && HellFireWeapon[5] >= 1)
        {
            HellFire -= magicPurchaseAmount;
            HellFireWeapon[8]++;
            HFSkillTotal++;
        }
    }
    public void PurchaseHF10()
    {
        if (HellFire > ultimateSkillPurchase && HFSkillTotal >= 14)
        {
            HellFire -= ultimateSkillPurchase;
            HellFireWeapon[9]++;
        }
    }


    public void PurchaseHM1()
    {
        if (HeavenMetal > magicPurchaseAmount)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[0]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM2()
    {
        if (HeavenMetal > magicPurchaseAmount)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[1]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM3()
    {
        if (HeavenMetal > magicPurchaseAmount)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[2]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM4()
    {
        if (HeavenMetal > magicPurchaseAmount && HeavenMetalWeapon[0] >= 1)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[3]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM5()
    {
        if (HeavenMetal > magicPurchaseAmount && HeavenMetalWeapon[1] >= 1)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[4]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM6()
    {
        if (HeavenMetal > magicPurchaseAmount && HeavenMetalWeapon[4] >= 1)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[5]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM7()
    {
        if (HeavenMetal > magicPurchaseAmount && HeavenMetalWeapon[2] >= 1)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[6]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM8()
    {
        if (HeavenMetal > magicPurchaseAmount && HeavenMetalWeapon[3] >= 2)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[7]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM9()
    {
        if (HeavenMetal > magicPurchaseAmount && HeavenMetalWeapon[5] >= 1)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[8]++;
            HMSkillTotal++;
        }
    }
    public void PurchaseHM10()
    {
        if (HeavenMetal > ultimateSkillPurchase && HMSkillTotal == 14)
        {
            HeavenMetal -= magicPurchaseAmount;
            HeavenMetalWeapon[9]++;
            HMSkillTotal++;
        }
    }


public void PurchasePW1()
    {
        if (PurgatoryWater > magicPurchaseAmount)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[0]++;
            PWSkillTotal++;
        }
    }

    public void PurchasePW2()
    {
        if (PurgatoryWater > magicPurchaseAmount)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[1]++;
            PWSkillTotal++;
        }
    }
    public void PurchasePW3()
    {
        if (PurgatoryWater > magicPurchaseAmount && PurgatoryWaterWeapon[0] ==1)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[2]++;
            PWSkillTotal++;
        }
    }
    public void PurchasePW4()
    {
        if (PurgatoryWater > magicPurchaseAmount && PurgatoryWaterWeapon[0] ==1)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[3]++;
            PWSkillTotal++;
        }
    }

    public void PurchasePW5()
    {
        if (PurgatoryWater > magicPurchaseAmount && PurgatoryWaterWeapon[1] ==1)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[4]++;
            PWSkillTotal++;
        }
    }
    public void PurchasePW6()
    {
        if (PurgatoryWater > magicPurchaseAmount && PurgatoryWaterWeapon[4] ==1)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[5]++;
            PWSkillTotal++;
        }
    }

    public void PurchasePW7()
    {
        if (PurgatoryWater > magicPurchaseAmount && PurgatoryWaterWeapon[2] == 3)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[6]++;
            PWSkillTotal++;
        }
    }

    public void PurchasePW8()
    {
        if (PurgatoryWater > magicPurchaseAmount && PurgatoryWaterWeapon[3] == 2)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[7]++;
            PWSkillTotal++;
        }
    }

    public void PurchasePW9()
    {
        if (PurgatoryWater > magicPurchaseAmount && PurgatoryWaterWeapon[5] == 1)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[8]++;
            PWSkillTotal++;
        }
    }
    public void PurchasePW10()
    {
        if (PurgatoryWater > ultimateSkillPurchase && PWSkillTotal == 14)
        {
            PurgatoryWater -= magicPurchaseAmount;
            PurgatoryWaterWeapon[9]++;
            
        }
    }

}