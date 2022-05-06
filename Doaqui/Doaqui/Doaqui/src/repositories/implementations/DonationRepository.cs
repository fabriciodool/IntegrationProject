using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;

namespace Doaqui.src.repositories.implementations
{

    /// <summary>
    /// <para> Summary: Donation repository implementation of IDoacao interface. </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public class DonationRepository : IDoacao
    {

        #region Attributes
        private readonly DoaquiContext _context;
        #endregion


        #region Constructors
        public DonationRepository(DoaquiContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        public void NewDonation(NovaDoacaoDTO donation)
        {
            _context.Doacoes.Add(new DoacaoModel
            {
                
            });
            _context.SaveChanges();
        }

        public void UpdateDonation(AtualizarDoacaoDTO donation)
        {
            _context.SaveChanges();
        } 

        public void DeleteDonation(int id)
        {
            _context.SaveChanges();
        }
        public DoacaoModel GetDonationById(int id)
        {
            
        }

        public DoacaoModel GetDonationByCnpj(int cnpj)
        {
            
        }

        public DoacaoModel GetDonationByContact(string contact)
        {
            
        }

        public List<DoacaoModel> GetAllDonations()
        {
            
        }
        #endregion

    }
}
