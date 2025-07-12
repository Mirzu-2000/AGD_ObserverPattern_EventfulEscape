using UnityEngine;

public class LightsOffByGhostEvent : MonoBehaviour
{
    [SerializeField] private int keysRequriedToTrigger;
    [SerializeField] private SoundType gostLaugh;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null && keysRequriedToTrigger == GameService.Instance.GetPlayerController().KeysEquipped)
        {
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(gostLaugh);
           GetComponent<Collider>().enabled = false; // Disable the collider to prevent multiple triggers
        }
    }

}