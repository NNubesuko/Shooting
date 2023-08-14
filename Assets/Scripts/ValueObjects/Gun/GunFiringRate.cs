public class GunFiringRate : Rate {

    private GunFiringRate(float value) : base(value, 0f, 10f) {
    }

    public static GunFiringRate Of(float value) {
        return new GunFiringRate(value);
    }

    public static GunFiringRate operator +(GunFiringRate rate, float deltaTime)
    {
        return GunFiringRate.Of(rate.Value + deltaTime);
    }

    public static bool operator<=(GunFiringRate rate, float time) {
        return rate.Value <= time;
    }

    public static bool operator <=(GunFiringRate lhRate, GunFiringRate rhRate)
    {
        return lhRate.Value <= rhRate.Value;
    }

    public static bool operator>=(GunFiringRate rate, float time) {
        return rate.Value >= time;
    }
    
    public static bool operator >=(GunFiringRate lhRate, GunFiringRate rhRate)
    {
        return lhRate.Value >= rhRate.Value;
    }

}
