using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.ViewModels.Account {
    public class AccountView {

        public bool Result { get; set; }

        public string ResultDescription { get; set; }

        public string SessionKey { get; set; }

        public UsersView User { get; set; }
    }
}
