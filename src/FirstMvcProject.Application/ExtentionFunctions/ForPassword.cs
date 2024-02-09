namespace FirstMvcProject.Application.ExtentionFunctions
{
    public class ForPassword
    {
        public static bool CaptalLetter(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Any(char.IsUpper);
        }
    }
}
