

namespace Course.Repository.ViewModeles {
    public class DisplayDataInHomeViewModel {
       
        public int Books { get;set; }
        public int Courses { get;set; }
        public int TotalSubscribes { get;set; }
        public decimal TotalEarning { get; set; }
        public List<string> Months { get; set; }   
        public List<int> Counts { get; set; }
    }
}
