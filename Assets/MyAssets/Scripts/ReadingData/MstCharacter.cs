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

    public int Rarity
    {
        get { return rarity; }
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

}
