using TexMexTacosBot.Models.Common;

namespace TexMexTacosBot.Handlers
{
    public class WelcomeIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Text = "Hi there, would you like to book a table?";

            return commonModel;
        }
    }
}