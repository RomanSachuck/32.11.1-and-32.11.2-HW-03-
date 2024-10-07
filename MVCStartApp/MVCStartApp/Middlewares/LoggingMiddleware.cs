using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MVCStartApp.Models.DB;
using MVCStartApp.Models.DB.Repositories;

namespace MVCStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repo;

        public LoggingMiddleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);
            await LogFile(context);
            await LogDB(context);
            
            await _next.Invoke(context);
        }

        private async Task LogFile(HttpContext context)
        {
            string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";
      
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");
      
            await File.AppendAllTextAsync(logFilePath, logMessage);
        }
        
        private void LogConsole(HttpContext context) =>
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        
        private async Task LogDB(HttpContext context)
        {
            Request request = new Request();
            request.Url = $"to http://{context.Request.Host.Value + context.Request.Path}";

            await _repo.AddRequest(request);
        }
    }
}