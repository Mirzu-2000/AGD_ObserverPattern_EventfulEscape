using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIView : MonoBehaviour
{
    [Header("Player Sanity")]
    [SerializeField] GameObject rootViewPanel;
    [SerializeField] Image insanityImage;
    [SerializeField] Image redVignette;

    [Header("Keys UI")]
    [SerializeField] TextMeshProUGUI keysFoundText;

    [Header("Game End Panel")]
    [SerializeField] GameObject gameEndPanel;
    [SerializeField] TextMeshProUGUI gameEndText;
    [SerializeField] Button tryAgainButton;
    [SerializeField] Button quitButton;

    private void OnEnable()
    {
        EventService.Instance.OnKeyPickedUp.AddListener(OnKeyEquipped);
        EventService.Instance.OnLightsOffByGhostEvent.AddListener(SetRedVignette);
        EventService.Instance.OnPlayerEscaped.AddListener(OnPlayerEscaped);
        EventService.Instance.OnPlayerDeath.AddListener(SetRedVignette);
        EventService.Instance.OnPlayerDeath.AddListener(OnPlayerDeath);
        EventService.Instance.OnRatRush.AddListener(SetRedVignette);
        EventService.Instance.OnSkullShowered.AddListener(SetRedVignette);

        tryAgainButton.onClick.AddListener(OnTryAgainButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnDisable()
    {
        EventService.Instance.OnKeyPickedUp.RemoveListener(OnKeyEquipped);
        EventService.Instance.OnLightsOffByGhostEvent.RemoveListener(SetRedVignette);
        EventService.Instance.OnPlayerEscaped.RemoveListener(OnPlayerEscaped);
        EventService.Instance.OnPlayerDeath.RemoveListener(SetRedVignette);
        EventService.Instance.OnPlayerDeath.RemoveListener(OnPlayerDeath);
        EventService.Instance.OnRatRush.RemoveListener(SetRedVignette);
        EventService.Instance.OnSkullShowered.RemoveListener(SetRedVignette);
    }

    public void UpdateInsanity(float playerSanity) => insanityImage.rectTransform.localScale = new Vector3(1, playerSanity, 1);
    private void OnKeyEquipped(int keys) => keysFoundText.SetText($"Keys Found: {keys}/3");
    private void OnQuitButtonClicked() => Application.Quit();
    private void OnTryAgainButtonClicked() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void SetRedVignette()
    {
        redVignette.enabled = true;
        redVignette.canvasRenderer.SetAlpha(0.5f);
        redVignette.CrossFadeAlpha(0, 5, false);
    }

    private void OnPlayerDeath()
    {
        gameEndText.SetText("Game Over");
        gameEndPanel.SetActive(true);
    }

    private void OnPlayerEscaped()
    {
        gameEndText.SetText("You Escaped");
        gameEndPanel.SetActive(true);
    }
}

