using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OfficeCrawler {
    public static class Program {

        //[STAThread]
        static void Main() {
            using (var game = new OfficeCrawler())
                game.Run();
            /*
            Word[] words = new Word[7];
            words[0] = new Word("you're", PartOfSpeech.Pronoun);
            words[1] = new Word("momma", PartOfSpeech.Noun);
            words[2] = new Word("dork", PartOfSpeech.Noun);
            words[3] = new Word("stupid", PartOfSpeech.Adjective);
            words[4] = new Word("faced", PartOfSpeech.Adjective);
            words[5] = new Word("ugly", PartOfSpeech.Adjective);
            words[6] = new Word("looking", PartOfSpeech.Adjective);
            InsultCollection collection = new InsultCollection(words);
            collection.SetSynergies();
            Console.WriteLine("--Words--");
            for(int i = 0; i < collection.Words.Count; i++) {
                Console.WriteLine("[" + i + "] " + collection.Words[i].Name);
            }
            Console.WriteLine("--Synergies--");
            foreach(Insult synergy in collection.Synergies) {
                Console.WriteLine(synergy.InsultString);
            }

            List<Word> currentInsult = new List<Word>();
            while(true) {
                Console.Write("Input the index of the word you want: ");
                string input = Console.ReadLine();
                if(input.ToLower() == "done") {
                    if(collection.Synergies.Contains(InsultCollection.ConvertToInsult(currentInsult))) {
                        Console.WriteLine("An insult! Good job Neanderthal Nate!");
                    } else {
                        RankInsult(currentInsult);
                    }
                    currentInsult = new List<Word>();
                    continue;
                }
                int index;
                if(!int.TryParse(input, out index)) {
                    Console.WriteLine("Please input an index.");
                    continue;
                }
                if(index < collection.Words.Count || index >= 0) {
                    currentInsult.Add(collection.Words[index]);
                }
                foreach(Word word in currentInsult) {
                    Console.Write(word.Name + " ");
                }
                Console.WriteLine();
            }
            */
        }
            /*
        static void RankInsult(List<Word> currentInsult) {
            Console.WriteLine("No synergy detected");
        }
            */
    }
}
