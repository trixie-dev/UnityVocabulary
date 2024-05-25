using TMPro;

public class LoginManager: Tab
{
    public TMP_InputField EmailInput;
    public TMP_InputField PasswordInput;
    public TextMeshProUGUI ErrorText;
    
    public void Login()
    {
        GameManager.Instance.FirebaseManager.AuthManager.LoginUser(EmailInput.text, PasswordInput.text, (success, error) =>
        {
            if (success)
            {
                GameManager.Instance.MainMenu();
            }
            else
            {
                ErrorText.text = error;
            }
        });
    }
    
    public void Register()
    {
        GameManager.Instance.FirebaseManager.AuthManager.RegisterUser(EmailInput.text, PasswordInput.text, (success, error) =>
        {
            if (success)
            {
                GameManager.Instance.MainMenu();
            }
            else
            {
                ErrorText.text = error;
            }
        });
    }
    
}