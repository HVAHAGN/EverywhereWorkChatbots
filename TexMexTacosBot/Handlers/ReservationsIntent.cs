using System.Linq;
using TexMexTacosBot.Models.Common;

namespace TexMexTacosBot.Handlers
{
    public class ReservationsIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            var time = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "time");
            var date = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "date");
            var number = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "number");

            commonModel.Response.Text = $"Perfect, your table for {number} is reserved for {time}. Buen provecho!";

            return commonModel;
        }
    }
}