using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OfficeCrawler {
    class InsultSystem {
    }

    class InsultCollection {

        public List<Word> Words;
        public List<Insult> Synergies;

        public InsultCollection(params Word[] inputtedWords) {
            Words = new List<Word>(inputtedWords);
            Synergies = new List<Insult>();
        }
        
        public void SetSynergies() {
            Synergies.Add(new Insult("you're momma dork"));
            Synergies.Add(new Insult("ugly momma"));
            Synergies.Add(new Insult("ugly looking momma"));
        }

        public static Insult ConvertToInsult(List<Word> words) {
            string insultString = string.Empty;
            foreach(Word word in words) {
                insultString += word.Name + " ";
            }
            insultString.Remove(insultString.Length - 1);
            return new Insult(insultString);
        }

    }

    struct Insult {
        public string InsultString;
        //public int Damage;

        public Insult(string insultString) {
            InsultString = insultString;
        }

        public static bool operator == (Insult a, Insult b) {
            return a.InsultString == b.InsultString;
        }

        public static bool operator != (Insult a, Insult b) {
            return a.InsultString != b.InsultString;
        }

        public override bool Equals(object obj) {
            var objType = obj.GetType();
            if(objType.IsInstanceOfType(this)) {
                return (obj.ToString() == ToString());
            }
            return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return InsultString;
        }
    }

    struct Word {

        public string Name;
        public PartOfSpeech PartOfSpeech;

        public Word(string name, PartOfSpeech partOfSpeech) {
            Name = name;
            PartOfSpeech = partOfSpeech;
        }
    }

    enum PartOfSpeech {
        Noun = 0,
        Pronoun = 1,
        Verb = 2,
        Adjective = 3,
    }
}
