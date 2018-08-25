using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord.Commands;
using Discord;


namespace MiyabiDiscordBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {

        Responses responseObject = new Responses();



        [Command("Hello")]
        public async Task Echo([Remainder]string whatMiyabiHears)
        {
            //Context is bloody amazing!
            //context.User.Username

            //var embed = new EmbedBuilder();
            //embed.WithTitle("Echoed message: ");
            //embed.WithDescription(whatMiyabiHears);
            //embed.WithColor(new Color(255,0,0));


            //await Context.Channel.SendMessageAsync("",false,embed);

            string greeting = $"Hello, {Context.User.Username}";

            await Context.Channel.SendMessageAsync(greeting);
        }



        [Command("talk")]
        public async Task Talk([Remainder]string whatMiyabiHears)//doesnt work without typing the command in twice.
        {
            

            
            if (checkForGrats(whatMiyabiHears))
            {
                Random rng = new Random();

                string[] congratulations =
                {       $"Thank you {Context.User.Username}!",
                        $"That makes me happy, {Context.User.Username}! thank you very much!",
                        $"I appreciate it deeply, {Context.User.Username}."
                };

                string[] filePaths = { "Images\\MeebsASmile.jpg",
                                       "Images\\MeebsAHappy.jpg",
                                       "Images\\MeebsSmiling2.jpg"

                };

                await Context.Channel.SendMessageAsync(congratulations[rng.Next(0,congratulations.Length-1)]);
                await Context.Channel.SendFileAsync(filePaths[rng.Next(0,filePaths.Length-1)]);


            }
            else
            {
                string whatMiyabiSays = await responseObject.CheckWordAsync(whatMiyabiHears.ToLower());

                await Context.Channel.SendMessageAsync(whatMiyabiSays);
            }



        }

        [Command("smile")]
        public async Task respondToAnything([Remainder]string whatMiyabiHears)
        {
            string[] filePathArr = { "Images\\MeebsASmile.jpg", "Images\\MeebsSmiling2.jpg", "Images\\MeebsAHappy.jpg" };

            string filePath = filePathArr[impRng(0, filePathArr.Length - 1)];



            await Context.Channel.SendFileAsync(filePath);
        }


        [Command("help")]
        public async Task tasukete()
        {
            string helpText = string.Format($"Very well then! I shall assist you {Context.User.Username}!\n " +
                                            $"Use $Talk *text here* or @MiyabiBot Talk *text here* to talk with me!" +
                                            $"More options to come soon.\n");

            


            await Context.User.SendMessageAsync(helpText);
            
        }

        private bool checkForGrats(string input)
        {
            var date = new DateTime(DateTime.Now.Year, 8, 15);

            if ((DateTime.Now.Date == date) && input.ToLower().Contains("congratulations") || input.ToLower().Contains("congrats") || input.ToLower().Contains("grats"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int impRng(int min,int max)
        {
            Random rng = new Random();
            return rng.Next(min, max);
        }

    }
}
