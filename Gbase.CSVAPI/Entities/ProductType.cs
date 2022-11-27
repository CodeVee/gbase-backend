#nullable disable
namespace Gbase.CSVAPI.Entities
{
    public class ProductType
    {
        public static readonly ProductType GuitarsElectricSolid = new(1, "Guitars : Electric Solid Body");
        public static readonly ProductType GuitarsElectricSemi = new(2, "Guitars : Electric Semi-Hollow Body");
        public static readonly ProductType Guitars12String = new(3, "Guitars : 12 String Electric & Acoustic");
        public static readonly ProductType GuitarsAcoustic = new(4, "Guitars : Acoustic");
        public static readonly ProductType GuitarsFattop = new(5, "Guitars : Flattop Electric & Acoustic");
        public static readonly ProductType GuitarsArchtop = new(6, "Guitars : Archtop Electric & Acoustic");
        public static readonly ProductType GuitarsClassical = new(7, "Guitars : Classical & Nylon");
        public static readonly ProductType Guitars7String = new(8, "Guitars : 7 String");
        public static readonly ProductType GuitarsLap = new(9, "Guitars : Lap, Pedal & Table");
        public static readonly ProductType GuitarsResonator = new(10, "Guitars : Resonator");
        public static readonly ProductType GuitarsTenor = new(11, "Guitars : Tenor");
        public static readonly ProductType GuitarsBass = new(12, "Guitars : Bass");
        public static readonly ProductType GuitarsUpright = new(13, "Guitars : Upright Bass");
        public static readonly ProductType GuitarsHollow = new(14, "Guitars : Hollow Body");
        public static readonly ProductType AmpsPreamps = new(15, "Amps & Preamps");
        public static readonly ProductType AmpParts = new(16, "Amp Parts");
        public static readonly ProductType AmpSpeakers = new(17, "Amp Speakers");
        public static readonly ProductType AmpTubes = new(18, "Amp Tubes");
        public static readonly ProductType Speaker = new(19, "Speaker Cabinets");
        public static readonly ProductType Drums = new(20, "Drums & Percussion");
        public static readonly ProductType BassSpeaker = new(21, "Bass Speaker Cabinets");
        public static readonly ProductType BassAmps = new(22, "Bass Amps");
        public static readonly ProductType Band = new(23, "Band & Orchestra");
        public static readonly ProductType Banjos = new(24, "Banjos");
        public static readonly ProductType Effects = new(25, "Effects");
        public static readonly ProductType Mandolin = new(26, "Mandolin Family");
        public static readonly ProductType PA = new(27, "P.A. & Sound Reinforcement");
        public static readonly ProductType Pickups = new(28, "Pickups");
        public static readonly ProductType Recording = new(29, "Recording Equipment");
        public static readonly ProductType Ukulele = new(30, "Ukulele & Banjo Ukes");
        public static readonly ProductType Accessories = new(31, "Accessories");
        public static readonly ProductType Apparel = new(32, "Apparel");
        public static readonly ProductType BooksVideos = new(33, "Books, Videos & Instrumental");
        public static readonly ProductType CloseOutItems = new(34, "Close Out Items");
        public static readonly ProductType GuitarParts = new(35, "Guitar Parts");
        public static readonly ProductType HighEndAudio = new(36, "High End Audio");
        public static readonly ProductType Karaoke = new(37, "Karaoke");
        public static readonly ProductType Miscellaneous = new(38, "Miscellaneous");
        public static readonly ProductType MusicNovelties = new(39, "Music Novelities");
        public static readonly ProductType Software = new(40, "Software");
        public static readonly ProductType Keyboards = new(41, "Keyboards");
        public static readonly ProductType Cases = new(42, "Cases");
        public static readonly ProductType[] Types = {
            GuitarsElectricSolid, GuitarsElectricSemi, Guitars12String, GuitarsAcoustic,
            GuitarsFattop, GuitarsArchtop, GuitarsClassical, Guitars7String, GuitarsLap,
            GuitarsResonator, GuitarsTenor, GuitarsBass, GuitarsUpright, GuitarsHollow,
            AmpsPreamps, AmpParts, AmpSpeakers, AmpTubes, Speaker, Drums, BassSpeaker,
            BassAmps, Band, Banjos, Effects, Mandolin, PA, Pickups, Recording, Ukulele,
            Accessories, Apparel, BooksVideos, CloseOutItems, GuitarParts, HighEndAudio,
            Karaoke, Miscellaneous, MusicNovelties, Software, Keyboards, Cases
        };
        public ProductType(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public static ProductType FromName(string name) => 
            Types.SingleOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());
    }
}
