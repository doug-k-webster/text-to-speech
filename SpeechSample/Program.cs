using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Globalization;

namespace SpeechSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();
            foreach (var voice in synthesizer.GetInstalledVoices())
            {
                var info = voice.VoiceInfo;
                Console.WriteLine($"Id: {info.Id} | Name: {info.Name} | Age: { info.Age} | Gender: { info.Gender } | Culture: {info.Culture}");

                synthesizer.SelectVoice(info.Name);

                var builder = new PromptBuilder();
                builder.StartVoice(info.Name);
                builder.AppendText($"This is the voice {info.Name}");
                builder.StartStyle(new PromptStyle(PromptEmphasis.Strong));
                builder.AppendText("It's time for bed.");
                builder.EndStyle();
                builder.EndVoice();

                synthesizer.Speak(builder);


            }

            //synthesizer.SelectVoice("Microsoft Server Speech Text to Speech Voice (en-GB, Hazel)");

            //var builder = new PromptBuilder();
            //builder.StartVoice(CultureInfo.GetCultureInfo("en-US"));
            //builder.AppendText($"Hello. I'm a child's voice.");
            //builder.StartStyle(new PromptStyle(PromptEmphasis.Strong));
            //builder.AppendText("Why aren't you going up stairs yet?");
            //builder.EndStyle();
            //builder.EndVoice();

            //synthesizer.Speak(builder);

            Console.ReadKey();
        }
    }
}
