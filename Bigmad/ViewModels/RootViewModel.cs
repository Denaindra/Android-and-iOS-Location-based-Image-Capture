using System;
namespace XamarinKit.ViewModels
{
    public class RootViewModel
    {
        public RootViewModel()
        {
        }
        public bool IsEdit { get; set; }
        public int ID { get; set; }
        public string Group { get; set; }
        public string ItemType { get; set; }
    }
}
