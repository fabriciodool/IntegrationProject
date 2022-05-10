using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;

namespace Doaqui.src.repositories
{

    /// <summary>
    /// <para> Summary: Representação do CRUD relacionado a usuarios </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public interface IDoacao
    {
        public void NovaDoacao(NovaDoacaoDTO doacao);
        public void AtualizarDoacao(AtualizarDoacaoDTO doacao);
        public void DeletarDoacao(int id);
        public DoacaoModelo PegarDoacaoPeloId(int id);
        public DoacaoModelo PegarDoacaoPeloCnpj(int cnpj);
        public DoacaoModelo PegarDoacaoPeloContato(string contato);
        public List<DoacaoModelo> PegarTodasDoacoes();
    }
}