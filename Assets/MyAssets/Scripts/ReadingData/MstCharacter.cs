using UnityEngine;

[System.SerializableAttribute]
public class MstCharacter
{
    [SerializeField]
    private int
        id,
        rarity,
        maxLebel,
        growthType,
        lowerEnergy,
        upperEnergy,
        initialCost;

    [SerializeField]
    private string
        name,
        imageId,
        flavorText;

    private int level;
    private int power;
    private bool hired = false;

    public int Rarity
    {
        get { return rarity; }
        private set {}
    }

    public int MaxLebel
    {
        get { return maxLebel; }
        private set {}
    }

    public int LowerEnergy
    {
        get { return lowerEnergy; }
        private set {}
    }

    public int InitialCost
    {
        get { return initialCost; }
        private set {}
    }
    public string Name
    {
        get { return name; }
        private set {}
    }

    public string ImageId
    {
        get { return imageId; }
        private set {}
    }

    public string FlavorText
    {
        get { return flavorText; }
        private set {}
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public bool Hired
    {
        get { return hired; }
        set { hired = value; }
    }

    public void SetFromCSV(string[] data)
    {
        id          = int.Parse( data[0] );
        name        = data[1];
        imageId     = data[2];
        flavorText  = data[3];
        rarity      = int.Parse( data[4] );
        maxLebel    = int.Parse( data[5] );
        growthType  = int.Parse( data[6] );
        lowerEnergy = int.Parse( data[7] );
        upperEnergy = int.Parse( data[8] );
        initialCost = int.Parse( data[9] );
    }

    public void CaluculatePower () //1秒ごとの生産性（Power）を計算する
    {
        if (growthType == 1)
        {
            double tmp = (double)(level - 1) / (maxLebel - 1);
            double calculatedPower = (upperEnergy - lowerEnergy) * tmp * tmp + lowerEnergy;
            power = (int)(calculatedPower - (calculatedPower % 1));
        } else if (growthType == 2)
        {
            double tmp = (double)(level - 1) / (maxLebel - 1);
            double calculatedPower = (upperEnergy - lowerEnergy) * tmp + lowerEnergy;
            power = (int)(calculatedPower - (calculatedPower % 1));
        } else if (growthType == 3)
        {
            double tmp = (double)(level - maxLebel) / (1 - maxLebel);
            double calculatedPower = - (upperEnergy - lowerEnergy) * tmp * tmp + upperEnergy;
            power = (int)(calculatedPower - (calculatedPower % 1));
        } else
        {
            return;
        }
    }

    public void LevelUp ()
    {
        // レベルの値を1だけあげる
        level++;
    }

}
