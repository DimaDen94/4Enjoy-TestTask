using UnityEngine;

public class PopUpView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string CloseAnimationKey = "Close";
    private const string OpenAnimationKey = "Open";

    public void PlayCloseAnimation() => _animator?.Play(CloseAnimationKey);
    public void PlayOpenAnamation() => _animator?.Play(OpenAnimationKey);

    
    public void Destroy() => Destroy(gameObject);
}