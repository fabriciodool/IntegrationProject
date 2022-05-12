using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task NovaSolicitacaoAsync(NovaSolicitacaoDTO solicitacao)
        {
            _contexto.Solicitacoes.Add(new SolicitacaoModelo
            {
                ONG = solicitacao.ONG,
                Doacao = solicitacao.Doacao,
            });
          await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarSolicitacaoAsync(AtualizarSolicitacaoDTO solicitacao)
        {
            SolicitacaoModelo modelo = await PegarSolicitacaoPeloCnpjAsync(solicitacao.Cnpj);
            modelo.ONG = solicitacao.ONG;
            modelo.Doacao = solicitacao.Doacao;
            _contexto.Update(modelo);
           await _contexto.SaveChangesAsync();
        }

        public async Task DeletarSolicitacaoAsync(int Cnpj)
        {
            _contexto.Solicitacoes.Remove(await PegarSolicitacaoPeloCnpjAsync(Cnpj));
          await _contexto.SaveChangesAsync();
        }

        public async Task<SolicitacaoModelo> PegarSolicitacaoPeloCnpjAsync(int id)
        {
            return await _contexto.Solicitacoes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<SolicitacaoModelo>> PegarTodasSolicitacoesAsync()
        {
            return await _contexto.Solicitacoes.ToListAsync();
        }
        #endregion

    }
}
