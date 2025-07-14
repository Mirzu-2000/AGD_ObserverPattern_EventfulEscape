public class EventService
{
    private static EventService instance;
    public static EventService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventService();
            }
            return instance;
        }
    }

    public EventController OnLightSwitchToggled { get; private set; }
    public EventController<int> OnKeyPickedUp { get; private set; }
    public EventController OnLightsOffByGhostEvent { get; private set; }

    public EventController OnPlayerEscaped { get; private set; }
    public EventController OnPlayerDeath { get; private set; }
    public EventController OnRatRush { get; private set; }
    public EventController OnSkullShowered { get; private set; }

    public EventService()
    {
        OnLightSwitchToggled = new EventController();
        OnKeyPickedUp = new EventController<int>();
        OnLightsOffByGhostEvent = new EventController();
        OnRatRush = new EventController();
        OnSkullShowered = new EventController();


        OnPlayerEscaped = new EventController();
        OnPlayerDeath = new EventController();

    }
}
