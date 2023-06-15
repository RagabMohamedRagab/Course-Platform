﻿using Course.Domain.Domains;
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface ITitleService {
        Task<bool> Create(TitleFormViewModel title);
        Task<List<TitleDropDownListViewModel>> GetAll();
        Task<IEnumerable<DisplayTitlesViewModel>> GetAllTitles(string userName, string Search = "", string order = "");
    }
}
