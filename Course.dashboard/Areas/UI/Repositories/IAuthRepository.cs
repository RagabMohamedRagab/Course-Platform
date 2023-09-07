﻿namespace Course.dashboard.Areas.UI.Repositories {
    public interface IAuthRepository {

        Task<bool> RegisterUI(RegisterViewModel model);
        Task LogOut();
        Task<string> Login(LoginViewModel model);
        Task<bool> Contactus(ContactUsViewModel contact);
    }
}
