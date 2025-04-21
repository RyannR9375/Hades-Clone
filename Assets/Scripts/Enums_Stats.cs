public enum StatCategory
{
    Damage,
    Health,
    Speed
}

public enum StatType
{
    Buff,
    Debuff
}

public enum StatTime
{
    Instant,
    Over_Time,
    Curve
}

public interface IStatModifier
{
    public abstract StatType Type { get; set; }
    public abstract StatTime Time { get; set; }
    public abstract StatCategory BoonCategory { get; set; }

    public abstract float Change { get; set; }
    public abstract float TotalTime { get; set; }
}
