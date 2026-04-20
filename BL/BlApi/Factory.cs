using BlImplementation;

namespace BlApi;

public static class Factory
{
    public static IBl Get()
    {
        Bl instance = new Bl();
        return instance;
    }
}
