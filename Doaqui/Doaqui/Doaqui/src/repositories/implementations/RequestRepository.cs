using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;
using System.Linq;

namespace Doaqui.src.repositories.implementations
{

    /// <summary>
    /// <para> Summary: Request repository implementation of ISolicitacao interface. </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public class RequestRepository : ISolicitacao
    {

        #region Attributes
        private readonly DoaquiContext _context;
        #endregion


        #region Constructors
        public RequestRepository(DoaquiContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        public void NewRequest(NovaSolicitacaoDTO request)
        {
            _context.Solicitacoes.Add(new SolicitacaoModel
            {
                ONG = request.ONG,
                Doacao = request.Doacao,
            });
            _context.SaveChanges();
        }

        public void UpdateRequest(AtualizarSolicitacaoDTO request)
        {
            SolicitacaoModel model = GetRequestById(request.Id);
            model.ONG = request.ONG;
            model.Doacao = request.Doacao;
            _context.Update(model);
            _context.SaveChanges();
        }

        public void DeleteRequest(int id)
        {
            _context.Solicitacoes.Remove(GetRequestById(id));
            _context.SaveChanges();
        }

        public SolicitacaoModel GetRequestById(int id)
        {
            return _context.Solicitacoes.FirstOrDefault(r => r.Id == id);
        }

        public List<SolicitacaoModel> GetAllRequests()
        {
            return _context.Solicitacoes.ToList();
        }
        #endregion

    }
}
