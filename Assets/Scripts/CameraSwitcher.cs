
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] 
    private InputAction action;

    private Animator animator;

    public bool mainMenuCamera = true;

    public bool optionsMenu;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();  
    }

    private void OnDisable()
    {
        action.Disable();
    }

    void Start()
    {
        action.performed += _ => SwitchState();
    }

    public void SwitchState()
    {
        if (mainMenuCamera)
        {
            animator.Play("OptionsMenuCamera");
        }
        else
        {
            animator.Play("MainMenuCamera");
        }

        mainMenuCamera = !mainMenuCamera;
    }
    private void Update()
    {
        OptionsMenuSwitcher();
    }

    public void OptionsMenuSwitcher()
    {
        if (optionsMenu)
        {
            SwitchState();
            optionsMenu = !optionsMenu;
        }
    }
}
