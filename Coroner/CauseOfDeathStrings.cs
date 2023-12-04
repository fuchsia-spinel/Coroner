using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coroner
{
    class CauseOfDeathStrings
    {
        // General causes of death

        public static readonly List<string> bldgnList = new List<string> {
            "Bludgeoned to death.",
            "Constitution save failed against rebar.",
            "Head caved in."
        };

        public static readonly List<string> grvList = new List<string> {
            "Fell to their death.",
            "Didn't study Isaac Newton in school.",
            "Turned into soup on the sidewalk."
        };

        public static readonly List<string> blastList = new List<string> {
            "Went out with a bang.",
            "Resting in pieces.",
            "Ignored the blinking red light on the ground."
        };

        public static readonly List<string> strngList = new List<string> {
            "Strangled to death.",
            "Tied their tie too tight."
        };

        public static readonly List<string> suffList = new List<string> {
            "Suffocated to death.",
            "Forgot to refill their oxygen tanks.",
            "SUFFOCATION! NO BREATHING!"
        };

        public static readonly List<string> maulList = new List<string> {
            "Mauled to death.",
            "Cut in ha-...wait, that's Star Wars.",
            "Ended up on the wrong side of some claws.",
            "Tried to hug a bear."
        };

        public static readonly List<string> shotList = new List<string> {
            "Shot to death by a turret.",
            "Didn't shoot Greedo first.",
            "Turned into swiss cheese.",
            "Filled full of lead or whatever bullets are made of.",
            "Walked in front of a gun.",
            "Became proof that the US needs gun control.",
            "Brought a flashlight to a gun fight.",
            "Didn't have someone manning the terminal."
        };

        public static readonly List<string> crshList = new List<string> {
            "Crushed to death.",
            "Asked for more weight."
        };

        public static readonly List<string> drownList = new List<string> {
            "Drowned to death.",
            "Worse at swimming than Jason Voorhees.",
            "Failed a Breathing check."
        };

        public static readonly List<string> abndnList = new List<string> {
            "Abandoned by their coworkers.",
            "Failed a Charisma check.",
            "Everyone left their birthday party early."
        };

        public static readonly List<string> elecList = new List<string> {
            "Electrocuted to death.",
            "Met quite the shocking end.",
            "Died doing what they loved...The Electric Slide."
        };

        // Enemy causes of death

        public static readonly List<string> brcknList = new List<string> {
            "Had their neck snapped by a Bracken.",
            "Hugged to death.",
            "Went towards the glowing eyes."
        };

        public static readonly List<string> dogList = new List<string> {
            "Was eaten by an Eyeless Dog.",
            "The pupper was not friendly.",
            "Should not have tried to pet the dog.",
            "Couldn't pet the dog.",
            "Became a chew toy."
        };

        public static readonly List<string> giantList = new List<string> {
            "Swallowed whole by a Forest Giant.",
            "Vored",
            "Thought they could win against an ent.",
            "Got stuck in a tree.",
            "Eaten by Treebeard."
        };

        public static readonly List<string> beeList = new List<string> {
            "Electro-stung to death by Circuit Bees.",
            "Fucked with the hive.",
            "THE BEEEEEEEEESSSSSS",
            "Got wickered, man."
        };

        public static readonly List<string> ghostList = new List<string> {
            "Died a mysterious death.",
            "Saw dead people.",
            "Shouldn't have said a name into the mirror three times."
        };

        public static readonly List<string> lvthnList = new List<string> {
            "Swallowed whole by an Earth Leviathan.",
            "Went out like Boba Fett.",
            "Got too greedy for spice.",
            "Digested like C. Carmine."
        };

        public static readonly List<string> hawkList = new List<string> {
            "Was eaten by a Baboon Hawk.",
            "Got deathed from above.",
            "Pecked to death."
        };

        public static readonly List<string> jstrList = new List<string> {
            "Was the butt of a joke.",
            "Shouldn't have heckled."
        };

        public static readonly List<string> fleaList = new List<string> {
            "Was suffocated a Snare Flea.",
            "Got headcrabbed.",
            "Met a facehugger.",
            "Got fleas.",
            "Probably host to an alien lifeform now."
        };

        public static readonly List<string> blobList = new List<string> {
            "Was absorbed by a Hygrodere.",
            "Became one with a blob.",
            "Slowest runner.",
            "Got outsmarted by a pile of goo."
        };

        public static readonly List<string> hrdrList = new List<string> {
            "Was hoarded by a Hoarder Bug.",
            "Thief.",
            "YIPEE!"
        };

        public static readonly List<string> lzrdList = new List<string> {
            "Was puffed by a Spore Lizard.",
            "Toked for too long.",
            "Tried to get high on poisonous spores...for some reason."
        };

        public static readonly List<string> spdrList = new List<string> {
            "Ensnared in the Sand Spider's web.",
            "A bit tied up."
        };

        // Player-related causes of death

        public static readonly List<string> jtpkGrvList = new List<string> {
            "Flew too close to the sun.",
            "0/10 Fudged the landing.",
            "Flew head first into...the ground."
        };

        public static readonly List<string> jtpkBlstList = new List<string> {
            "Turned into a firework.",
            "Smoked too close to a jetpack."
        };

        public static readonly List<string> mrdrList = new List<string> {
            "Was the victim of a murder.",
            "Voted least liked on the ship.",
            "Killed by the Stop Sign Murderer."
        };

        public static readonly List<string> qksndList = new List<string> {
            "Got stuck in quicksand.",
            "Couldn't tell that they were sinking.",
            "Tried to save their Pumas from some mud.",
            "Tried to live underground."
        };

        public static readonly List<string> deskList = new List<string> {
            "Received a demotion.",
            "Rang the bell too many times.",
            "Disturbed an Eldritch horror.",
            "Didn't get enough loot to appease the Company.",
            "Don't stand / Don't stand so / Don't stand so close to me."
        };

        public static readonly List<string> drpshpList = new List<string> {
            "Couldn't wait for their items.",
            "Stared into a jet engine.",
            "Killed by an ice cream truck."
        };

        public static readonly List<string> grndList = new List<string> {
            "Was the victim of a murder.",
            "I guess phasers weren't set to stun."
        };

        // Unknown cause of death

        public static readonly List<string> unknwnList = new List<string> {
            "We don't know what the fuck happened to them, but we know they're dead.",
            "Oh my god, they're fucking dead.",
            "They're dead, Jim."
        };
    }
}
