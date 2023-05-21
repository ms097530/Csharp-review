namespace Intermediate.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        // best practice to make fields is to do the following:
        // field
        // private string _motherboard;
        // field accessed and manipulated by property
        // private string Motherboard {get {return _motherboard;} set {_motherboard = value;}}
        // * OR have shortcut of this:
        // ? using shortcuts to set default values as well
        public string Motherboard { get; set; } = "";
        public string VideoCard { get; set; } = "";
        // to overcome SqlNullValueException: Data is Null (need to make data nullable since we weren't providing it, or assign a default value - did both)
        public int? CPUCores { get; set; } = 0;
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
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