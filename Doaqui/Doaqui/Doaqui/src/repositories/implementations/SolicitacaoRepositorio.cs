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
    public class SolicitacaoRepositorio : ISolicitacao
    {

        #region Attributes
        private readonly DoaquiContexto _contexto;
        #endregion


        #region Constructors
        public SolicitacaoRepositorio(DoaquiContexto context)
        {
            _contexto = context;
        }
        #endregion


        #region Methods
        public void NovaSolicitacao(NovaSolicitacaoDTO solicitacao)
        {
            _contexto.Solicitacoes.Add(new SolicitacaoModelo
            {
                ONG = solicitacao.ONG,
                Doacao = solicitacao.Doacao,
            });
            _contexto.SaveChanges();
        }

        public void AtualizarSolicitacao(AtualizarSolicitacaoDTO solicitacao)
        {
            SolicitacaoModelo modelo = PegarSolicitacaoPeloId(solicitacao.Id);
            modelo.ONG = solicitacao.ONG;
            modelo.Doacao = solicitacao.Doacao;
            _contexto.Update(modelo);
            _contexto.SaveChanges();
        }

        public void DeletarSolicitacao(int id)
        {
            _contexto.Solicitacoes.Remove(PegarSolicitacaoPeloId(id));
            _contexto.SaveChanges();
        }

        public SolicitacaoModelo PegarSolicitacaoPeloId(int id)
        {
            return _contexto.Solicitacoes.FirstOrDefault(r => r.Id == id);
        }

        public List<SolicitacaoModelo> PegarTodasSolicitacoes()
        {
            return _contexto.Solicitacoes.ToList();
        }
        #endregion

    }
}
