
using System;

public class EventController 
{
    public Action baseEvent;

    public void AddListener(Action listrner) => baseEvent += listrner; 
    public void RemoveListener(Action listrner) => baseEvent -= listrner; 
    public void InvokeEvent() => baseEvent?.Invoke();

}
