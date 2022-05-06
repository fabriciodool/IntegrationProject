using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;

namespace Doaqui.src.repositories
{

    /// <summary>
    /// <para> Summary: Represets all CRUD actions related to donations </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public interface IDoacao
    {
        public void NewDonation(NovaDoacaoDTO donation);
        public void UpdateDonation(AtualizarDoacaoDTO donation);
        public void DeleteDonation(int id);
        public DoacaoModel GetDonationById(int id);
        public DoacaoModel GetDonationByCnpj(int cnpj);
        public DoacaoModel GetDonationByContact(string contact);
        public List<DoacaoModel> GetAllDonations();
    }
}