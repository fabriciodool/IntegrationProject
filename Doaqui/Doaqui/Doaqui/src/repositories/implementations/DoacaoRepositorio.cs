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
    /// <para> Summary: Donation repository implementation of IDoacao interface. </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public class DoacaoRepositorio : IDoacao
    {

        #region Attributes
        private readonly DoaquiContexto _contexto;
        #endregion


        #region Constructors
        public DoacaoRepositorio(DoaquiContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion


        #region Methods
        public async Task NovaDoacaoAsync(NovaDoacaoDTO doacao)
        {
            _contexto.Doacoes.Add(new DoacaoModelo
            {
                Contato = doacao.Contato,
                Quantidade = doacao.Quantidade,
                Validade = doacao.Validade,
                Descricao = doacao.DescricaoDoacao,
                CNPJ_Doador = doacao.CNPJ_Doador,
            });
           await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarDoacaoAsync(AtualizarDoacaoDTO doacao)
        {
            DoacaoModelo modelo = new DoacaoModelo();
            modelo.Contato = doacao.Contato;
            modelo.Quantidade = doacao.Quantidade;
            modelo.Validade = doacao.Validade;
            modelo.Descricao = doacao.DescricaoDoacao;
            modelo.CNPJ_Doador = doacao.CNPJ_Doador;
            _contexto.Update(modelo);
           await _contexto.SaveChangesAsync();
        } 

        public async Task DeletarDoacaoAsync(int id)
        {
            _contexto.Doacoes.Remove(await PegarDoacaoPeloIdAsync(id));
           await _contexto.SaveChangesAsync();
        }

        public async Task<DoacaoModelo> PegarDoacaoPeloIdAsync(int id)
        {
            return await _contexto.Doacoes.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DoacaoModelo> PegarDoacaoPeloCnpjAsync(int cnpj)
        {
            return await _contexto.Doacoes.FirstOrDefaultAsync(d => d.CNPJ_Doador == cnpj);
        }

        public async Task<DoacaoModelo> PegarDoacaoPeloContatoAsync(string contato)
        {
            return await _contexto.Doacoes.FirstOrDefaultAsync(d => d.Contato == contato);
        }

        public async Task<List<DoacaoModelo>> PegarTodasDoacoesAsync()
        {
            return await _contexto.Doacoes.ToListAsync();
        }
        #endregion

    }
}
