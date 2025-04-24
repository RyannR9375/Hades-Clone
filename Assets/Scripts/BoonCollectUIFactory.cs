using UnityEngine;

//FLUENT BUILDER PATTERN
public class BoonCollectUI
{
    public string FamilyName { get; set; }
    public string BoonName { get; set; }
    public string Description { get; set; }
}

public class BoonCollectUIFactory : MonoBehaviour
{
    private string _familyName;
    private string _boonName;
    private string _description;

    public static BoonCollectUIFactory Empty() => new();
    public BoonCollectUIFactory WithFamilyName(string familyName)
    {
        this._familyName = familyName;
        return this;
    }

    public BoonCollectUIFactory WithBoonName(string boonName)
    {
        this._boonName = boonName;
        return this;
    }

    public BoonCollectUIFactory WithDescription(string description)
    {
        this._description = description;
        return this;
    }

    public BoonCollectUI Build()
    {
        return new BoonCollectUI
        {
            FamilyName = _familyName,
            BoonName = _boonName,
            Description = _description
        };
    }
}
