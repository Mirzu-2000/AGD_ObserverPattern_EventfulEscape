using UnityEngine;

public class KeyView : MonoBehaviour, IInteractable
{
    //[SerializeField] GameUIView gameUIView;
    public void Interact()
    {
        int currentKeys = GameService.Instance.GetPlayerController().KeysEquipped;

        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.KeyPickUp);
        // Increment the key count in the player controller
        currentKeys++;
        EventService.Instance.Onkeypickedup.InvokeEvent(currentKeys);
        //gameUIView.UpdateKeyText();

        gameObject.SetActive(false);
    }
}
