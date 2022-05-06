using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;

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
            _context.SaveChanges();
        }

        public void UpdateRequest(AtualizarSolicitacaoDTO request)
        {
            _context.SaveChanges();
        }

        public void DeleteRequest(int id)
        {
            _context.SaveChanges();
        }

        public SolicitacaoModel GetRequestById(int id)
        {

        }

        public List<SolicitacaoModel> GetAllRequests()
        {
            
        }
        #endregion

    }
}
