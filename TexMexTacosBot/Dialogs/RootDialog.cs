using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using ApiAiSDK;
using TexMexTacosBot.Helpers;

namespace TexMexTacosBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private const string clientAccessToken = "cd9a8828e9fe42e0a8c2b35efa304ba1";
        private static AIConfiguration config = new AIConfiguration(clientAccessToken, SupportedLanguage.English);
        private static ApiAi apiAi = new ApiAi(config);

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            var aiResponse = apiAi.TextRequest(activity.Text);

            var commonModel = CommonModelMapper.ApiAiToCommonModel(aiResponse);
            commonModel = IntentRouter.Process(commonModel);

            await context.PostAsync(commonModel.Response.Text);

            context.Wait(MessageReceivedAsync);
        }
    }
}