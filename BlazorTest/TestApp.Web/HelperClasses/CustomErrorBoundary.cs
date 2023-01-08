using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using TestApp.Logging;

namespace TestApp.Web.HelperClasses
{
    public class CustomErrorBoundary : ErrorBoundary
    {
        [Inject]
        private IWebHostEnvironment _env { get; set; } = null!;
        protected override async Task OnErrorAsync(Exception ex)
        {
            await Logger.AppendLogLineAsync(AppData.LOG_FILE_PATH, AppData.LOG_FILE_NAME, $"Exception message:\t{ex.Message}");
            await Logger.AppendLogLineAsync(AppData.LOG_FILE_PATH, AppData.LOG_FILE_NAME, $"Inner exception:\t{ex.InnerException}");
            await Logger.AppendLogLineAsync(AppData.LOG_FILE_PATH, AppData.LOG_FILE_NAME, $"Exception stack trace:\t{ex.StackTrace}");

            if (_env.IsDevelopment())
            {
                await base.OnErrorAsync(ex);
                return;
            }
            return;
        }
    }
}