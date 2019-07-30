using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.ViewModels.Account {
    public class AccountView {

        public int code { get; set; }

        public string message { get; set; }

        public string token { get; set; }
        public string tokenHead { get; set; }

        public UsersView User { get; set; }
    }
}
