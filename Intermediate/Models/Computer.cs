using System.Text.Json.Serialization;

namespace Intermediate.Models
{
    public class Computer
    {
        // * sets attribute on field below
        // * determines what JSON version of property name will be when serializing/deserializing
        [JsonPropertyName("computer_id")]

        public int ComputerId { get; set; }
        // best practice to make fields is to do the following:
        // field
        // private string _motherboard;
        // field accessed and manipulated by property
        // private string Motherboard {get {return _motherboard;} set {_motherboard = value;}}
        // * OR have shortcut of this:
        // ? using shortcuts to set default values as well
        [JsonPropertyName("motherboard")]
        public string Motherboard { get; set; } = "";
        [JsonPropertyName("video_card")]
        public string VideoCard { get; set; } = "";
        // to overcome SqlNullValueException: Data is Null (need to make data nullable since we weren't providing it, or assign a default value - did both)
        [JsonPropertyName("cpu_cores")]
        public int? CPUCores { get; set; } = 0;
        [JsonPropertyName("has_wifi")]
        public bool HasWifi { get; set; }
        [JsonPropertyName("has_lte")]
        public bool HasLTE { get; set; }
        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        // needs to be public to access - set values that are non-nullable
        // public Computer()
        // {
        //     if (VideoCard == null)
        //     {
        //         VideoCard = "";
        //     }
        //     if (Motherboard == null)
        //     {
        //         Motherboard = "";
        //     }
        // }

        // ! BELOW ARE PUBLIC FIELDS - these go against best practice
        // public string Motherboard;
        // public string VideoCard;
        // public int CPUCores;
        // public bool HasWifi, HasLTE;
        // public DateTime ReleaseDate;
        // public decimal Price;
    }
}