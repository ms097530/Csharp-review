namespace Intermediate.Models
{
    public class ComputerSnake
    {
        public int computer_id { get; set; }
        // best practice to make fields is to do the following:
        // field
        // private string _motherboard;
        // field accessed and manipulated by property
        // private string Motherboard {get {return _motherboard;} set {_motherboard = value;}}
        // * OR have shortcut of this:
        // ? using shortcuts to set default values as well
        public string motherboard { get; set; } = "";
        public string video_card { get; set; } = "";
        // to overcome SqlNullValueException: Data is Null (need to make data nullable since we weren't providing it, or assign a default value - did both)
        public int? cpu_cores { get; set; } = 0;
        public bool has_wifi { get; set; }
        public bool has_lte { get; set; }
        public DateTime? release_date { get; set; }
        public decimal price { get; set; }

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