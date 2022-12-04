using UnityEngine;
using UnityEngine.UI;

public class MobileMovement : MonoBehaviour
{

    [SerializeField] private Joystick joystick;
    MainMovement mainMovement;
    AttackSystem attackSystem;
    PurpleColbAbillity purpleColbAbillity;
    private float horizontalMove = 0;

    //UI
    [Header("UI")]
    [SerializeField] private Image[] UISprites;

    private void Awake()
    {
        mainMovement = GetComponent<MainMovement>();
        attackSystem = GetComponent<AttackSystem>();
        purpleColbAbillity = GetComponent<PurpleColbAbillity>();
    }

    void Start()
    {
        MoveButtonUp();
    }


    void Update()
    {
        horizontalMove = joystick.Horizontal; //перехват управления джостиком
    }

    private void FixedUpdate()
    {
        mainMovement.Move(horizontalMove);
    }

    public void OnJumpButtonPressed(Image jumpSprite)
    {
        mainMovement.Jump();
        jumpSprite.color = new Color(jumpSprite.color.r, jumpSprite.color.g, jumpSprite.color.b, 1);

    }

    public void OnAttackButtonPressed(Image attackSprite)
    {
        attackSprite.color = new Color(attackSprite.color.r, attackSprite.color.g, attackSprite.color.b, 1);
        attackSystem.Attack();
    }

    public void OnUseShieldPotionButtonPressed(Image UseColbButton)
    {
        UseColbButton.color = new Color(UseColbButton.color.r, UseColbButton.color.g, UseColbButton.color.b, 1);
        purpleColbAbillity.UseShield();
    }
    
    public void MoveButtonUp()
    {
        foreach (Image image in UISprites)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);
        }
    }

    
}
