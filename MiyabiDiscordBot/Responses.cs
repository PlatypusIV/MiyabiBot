using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiyabiDiscordBot
{
    class Responses
    {
        

        public string[] thingsToRespondTo = { "murasaki", "imu", "ryoubi", "ryouna","homura","crab","crustacean","devil","dmc","dante","vergil","nero","yumi","man","manly" };

        Dictionary<string, string[]> _responsesToQueries = new Dictionary<string, string[]>();

        string[] _murasaki = {"Murasaki sure is lazy some times. But I know she is improving!",
                                "I wish Murasaki would focus on her training as much as she does on her novels.",
                                "I'll make a proper shinobi out of that girl yet!" };

        string[] _imu = {"Imu sure is a good friend!",
                          "She can be obsessive at times, but im glad to have Imu at my side!",
                          "Im really glad to have a frie-... I mean ally like Imu!"
                           };

        string[] _ryoubi = {"Ryoubi is a great shinobi, but I believe she has a lot to learn.",
                            "I think Ryoubi needs to find confidence in herself and stop obsessing over her chest.",
                            "Im really happy we ended up as teammates with Ryoubi!"};

        string[] _ryouna = {"I know Ryouna can be weird at times, but I know she's an incredible shinobi!",
                            "Don't insult Ryouna like that!! On the other hand I think she might like it if you do...",
                            "Ryouna is a capable and strong shinobi, but she can be a bit... Weird at times."};

        string[] _devilMayCry = {"Devil May Cry sure is a fun game right! RIGHT!",
                                  "I bet the next DMC is going to be AWESOME!",
                                  "What do you think the next Devil Arms are going to be like? They're probably gonna be so cool!",
                                  "I wonder if Dante will manage to destroy Nero's store like he did his own in the next game.",
                                  "When this wickedness consumes me\nnothing can save you\nandthere's no way out!",
                                  "Gotta let it out\nGotta let it out\nGotta let it out\nGOTTA LET IT OUT!\n",
                                  "Hmpf. Jackpot!"
                                  };
        string[] _dante = {"Dante is the coolest!", "Im going to be as strong as Dante! No... STRONGER!", "I wonder if I can get a red coat like that from somewhere..." };

        string[] _vergil = {"I think im quite similar to Vergil. Hm... Are you doubting me!?",
                            "I also need more power.",
                            "Maybe I could swipe my hair back like that too... What!? Im not trying to look like Vergil or anything!!!",
                            "Let's have some fun!*MENACING*"

        };

        string[] _nero = {"Nero sure looks like he'll be fun to play in DMC 5.", "I wonder if I could secretly get a coat like Nero's.","Nero sure did change in 10 years."  };

        string[] _homura = {"Homura is WEAK! She is the reason Hebijo fell!",
                            "I will show that crustacean what true strength is!",
                             "Homura is as weak as is her sense of humor! Bwahaha!",
                             "Next time I see Homura im going to challenge her to a battle!"};

        string[] _yumi = {"She might be the grandaughter of a legendary shinobi, but I won't let that frighten me!",
            "I'm not going to lose to Yumi or any of the Gessen shinobi!",
            "If she wants to be the lead of this franchise she's going to have to defeat me first!",
            "Must be nice being able to make ice cream with your shinobi powers..."};

        string[] _man = {"BY ALL MEANS KEEP CALLING ME A HUNK!",
                        "Im. NOT. A. MAN!",
                        "STOP CALLING ME A MAN! IM A HUNK AT MOST!",
                        "Am I really that manly...",
                        "You are truly brave! Calling me a man like that."
        };



        string[] _default = {"You are getting stronger today aren't you?",
                             "*Hums Devil Trigger*",
                             "That Katsuragi from Hanzo academy sure is a pervert huh...",
                              "Make sure to do some pushups today! Every little bit of workout helps.",
                              "I wonder what Rin-sensei think's of my progress...",
                              "Remember to drink water! Dehydration leads to WEAKNESS!",
                              "Do you want to see true power!",
                              "You are not worthy as my opponent!",
                              "Im going to make Mama-shama proud... Wh-WHAT ARE YOU LOOKING AT! YOU DIDNT HEAR ANYTHING!",
                              "*Hums Devils Never Cry*",
                              "*Hums Shall Never Surrender*",
                              "*Hums Machiavellism of Despair*",
                              "MIYABI READY FOR BATTLE!",
                              "Your experience will never betray you.",
                              "Hmm..."
        };



        //constructor

        public Responses()
        {
            _responsesToQueries.Add("murasaki",_murasaki );
            _responsesToQueries.Add("imu", _imu);
            _responsesToQueries.Add("ryoubi", _ryoubi);
            _responsesToQueries.Add("ryouna", _ryouna);
            _responsesToQueries.Add("homura", _homura);
            _responsesToQueries.Add("crab", _homura);
            _responsesToQueries.Add("crustacean", _homura);
            _responsesToQueries.Add("devil", _devilMayCry);
            _responsesToQueries.Add("dmc", _devilMayCry);
            _responsesToQueries.Add("dante", _dante);
            _responsesToQueries.Add("vergil", _vergil);
            _responsesToQueries.Add("nero", _nero);
            _responsesToQueries.Add("yumi", _yumi);
            _responsesToQueries.Add("man", _man);
            _responsesToQueries.Add("manly", _man);
            _responsesToQueries.Add("default", _default);

        }

        
        public Task<string> CheckWordAsync(string i)
        {
            return Task.Factory.StartNew(() => CheckForWord(i));
        }
            



        private string CheckForWord(string input)
        {
            string[] _iStringArray = input.Split(' ');

            string _checkResult = "";

            string output = "";
            

            foreach(string s in _iStringArray)
            {
                for (int i = 0; i < thingsToRespondTo.Length; i++)
                {
                    if (s.ToLower() == thingsToRespondTo[i])
                    {
                        _checkResult = s;
                    };
                }
            }

            if(_checkResult != "")
            {
                foreach(KeyValuePair<string,string[]> key in _responsesToQueries)
                {
                    if(_checkResult == key.Key)
                    {
                        
                        output = key.Value[improvedRng(0,key.Value.Length - 1)];
                    }
                }
            }
            else
            {
                output = _responsesToQueries["default"][improvedRng(0,_responsesToQueries["default"].Length-1)];
            }

            return output;

        }

        private int improvedRng(int min,int max)
        {
            Random rng = new Random();
            int rngOutput = rng.Next(min, max);

            return rngOutput;



        }
    }

}
