using Gbase.CSVAPI.Entities;

namespace Gbase.CSVAPI.Models
{
    public class ApiConstants
    {
        public static readonly string[] ValidCases = new string[] {
            "None", "Hard", "Soft","GigBag",
            "Original Hard", "Original Soft"
        };
        public static readonly string[] ValidConditions = new string[] { 
            "Brand New", "Mint", "Near Mint", "Excellent", 
            "Very Good", "Good", "Fair", "Poor",
        };
        public static readonly string[] ValidTypes = new string[] {
            "Guitars : Electric Solid Body", "Guitars : Electric Semi-Hollow Body",
            "Guitars : 12 String Electric & Acoustic", "Guitars : Acoustic",
            "Guitars : Flattop Electric & Acoustic", "Guitars : Archtop Electric & Acoustic",
            "Guitars : Classical & Nylon", "Guitars : 7 String", "Guitars : Lap, Pedal & Table",
            "Guitars : Resonator", "Guitars : Tenor", "Guitars : Bass", "Guitars : Upright Bass",
            "Guitars : Hollow Body", "Amps & Preamps", "Amp Parts", "Amp Speakers", "Amp Tubes",
            "Speaker Cabinets", "Drums & Percussion", "Bass Speaker Cabinets", "Bass Amps",
            "Band & Orchestra", "Banjos", "Effects", "Mandolin Family", "P.A. & Sound Reinforcement",
            "Pickups", "Recording Equipment", "Ukulele & Banjo Ukes", "Accessories", "Apparel",
            "Books, Videos & Instrumental", "Close Out Items", "Guitar Parts", "High End Audio", 
            "Karaoke", "Miscellaneous", "Music Novelities", "Software", "Keyboards", "Cases",
        };
    }
}
