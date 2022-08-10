using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Src.Modelos;

namespace BlogAPI.Src.Repositorios
{
    public interface IPostagem
    {
        Task<List<Postagem>> PegarTodosPostagensAsync();
        Task<Postagem> PegarPostagemPeloIdAsync(int id);
        Task NovoPostagemAsync(Postagem postagem);
        Task AtualizarPostagemAsync(Postagem postagem);
        Task DeletarPostagemAsync(int id);
    }
}
