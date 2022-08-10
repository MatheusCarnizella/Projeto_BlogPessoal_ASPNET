﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Src.Contextos;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Src.Repositorios.Implentacoes
{
    public class TemaRepositorio : ITema
    {

        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion

        #region Construtor

        public TemaRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos

        public async Task<List<Tema>> PegarTodosTemasAsync()
        {
            return await _contexto.Temas.ToListAsync();
        }

        public async Task<Tema> PegarTemaPeloIdAsync(int id)
        {
            if (!ExisteId(id)) throw new Exception("id do Tema não encontrado");

            return await _contexto.Temas.FirstOrDefaultAsync(t => t.Id == id);

            bool ExisteId(int id)
            {
                var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Id == id);

                return auxiliar != null;
            }
        }

        public async Task NovoTemaAsync(Tema tema)
        {
            if (await ExisteDescricao(tema.Descricao)) throw new Exception("Descrição já existente no sistema!");

            await _contexto.Temas.AddAsync(new Tema
            {
                Descricao = tema.Descricao
            });
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarTemaAsync(Tema tema)
        {
            if (await ExisteDescricao(tema.Descricao)) throw new Exception("Descrição já existente no sistema!");

            var auxiliar = await PegarTemaPeloIdAsync(tema.Id);
            auxiliar.Descricao = tema.Descricao;
            _contexto.Temas.Update(auxiliar);
            await _contexto.SaveChangesAsync();

        }

        public async Task DeletarTemaAsync(int id)
        {
            _contexto.Temas.Remove(await PegarTemaPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        private async Task<bool> ExisteDescricao(string descricao)
        {
            var auxiliar = await _contexto.Temas.FirstOrDefaultAsync(t => t.Descricao == descricao);

            return auxiliar != null;
        }

        #endregion

    }
}
