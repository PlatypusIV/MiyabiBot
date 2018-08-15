using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiyabiDiscordBot
{
    class Program
    {
        
        DiscordSocketClient _client;

        CommandHandler _cHandler;

        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {

            
            if (Config.bot.token == "" || Config.bot.token == null)
            {
                return;
            }
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = Discord.LogSeverity.Verbose
            });
            _client.Log += Log;
            _cHandler = new CommandHandler();
            await _client.LoginAsync(Discord.TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            await _cHandler.InitializeAsync(_client);
            await Task.Delay(-1); 

        }

        private async Task Log(Discord.LogMessage msg)
        {
            Console.WriteLine(msg.Message);
            
        }
    }
}
