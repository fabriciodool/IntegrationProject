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
    public interface ISolicitacao
    {
        public void NovaSolicitacao(NovaSolicitacaoDTO solicitacao);
        public void AtualizarSolicitacao(AtualizarSolicitacaoDTO solicitacao);
        public void DeletarSolicitacao(int id);
        public SolicitacaoModelo PegarSolicitacaoPeloId(int id);
        public List<SolicitacaoModelo> PegarTodasSolicitacoes();
    }

}