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
        public void NovaDoacao(NovaDoacaoDTO doacao)
        {
            _contexto.Doacoes.Add(new DoacaoModelo
            {
                Contato = doacao.Contato,
                Quantidade = doacao.Quantidade,
                Validade = doacao.Validade,
                Descricao = doacao.DescricaoDoacao,
                CNPJ_Doador = doacao.CNPJ_Doador,
            });
            _contexto.SaveChanges();
        }

        public void AtulizarDoacao(AtualizarDoacaoDTO doacao)
        {
            DoacaoModelo modelo = new DoacaoModelo();
            modelo.Contato = doacao.Contato;
            modelo.Quantidade = doacao.Quantidade;
            modelo.Validade = doacao.Validade;
            modelo.Descricao = doacao.DescricaoDoacao;
            modelo.CNPJ_Doador = doacao.CNPJ_Doador;
            _contexto.Update(modelo);
            _contexto.SaveChanges();
        } 

        public void DeletarDoacao(int id)
        {
            _contexto.Doacoes.Remove(PegarDoacaoPeloId(id));
            _contexto.SaveChanges();
        }

        public DoacaoModelo PegarDoacaoPeloId(int id)
        {
            return _contexto.Doacoes.FirstOrDefault(d => d.Id == id);
        }

        public DoacaoModelo PegarDoacaoPeloCnpj(int cnpj)
        {
            return _contexto.Doacoes.FirstOrDefault(d => d.CNPJ_Doador == cnpj);
        }

        public DoacaoModelo PegarDoacaoPeloContato(string contato)
        {
            return _contexto.Doacoes.FirstOrDefault(d => d.Contato == contato);
        }

        public List<DoacaoModelo> PegarTodasDoacoes()
        {
            return _contexto.Doacoes.ToList();
        }
        #endregion

    }
}
