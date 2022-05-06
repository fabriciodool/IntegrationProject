using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;
using System.Linq;

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
                Contato = donation.Contato,
                Quantidade = donation.Quantidade,
                Validade = donation.Validade,
                Descricao = donation.DescricaoDoacao,
                CNPJ_Doador = donation.CNPJ_Doador,
            });
            _context.SaveChanges();
        }

        public void UpdateDonation(AtualizarDoacaoDTO donation)
        {
            DoacaoModel model = new DoacaoModel();
            model.Contato = donation.Contato;
            model.Quantidade = donation.Quantidade;
            model.Validade = donation.Validade;
            model.Descricao = donation.DescricaoDoacao;
            model.CNPJ_Doador = donation.CNPJ_Doador;
            _context.Update(model);
            _context.SaveChanges();
        } 

        public void DeleteDonation(int id)
        {
            _context.Doacoes.Remove(GetDonationById(id));
            _context.SaveChanges();
        }

        public DoacaoModel GetDonationById(int id)
        {
            return _context.Doacoes.FirstOrDefault(d => d.Id == id);
        }

        public DoacaoModel GetDonationByCnpj(int cnpj)
        {
            return _context.Doacoes.FirstOrDefault(d => d.CNPJ_Doador == cnpj);
        }

        public DoacaoModel GetDonationByContact(string contact)
        {
            return _context.Doacoes.FirstOrDefault(d => d.Contato == contact);
        }

        public List<DoacaoModel> GetAllDonations()
        {
            return _context.Doacoes.ToList();
        }
        #endregion

    }
}
