﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Src.Modelos;

namespace BlogAPI.Src.Repositorios
{
    public interface IUsuario
    {
        /// <summary>
        /// <para>Resumo: Responsavel por representar ações de CRUD de usuario</para>
        /// <para>Criado por: Generation</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 29/04/2022</para>
        /// </summary>

        Task<Usuario> PegarUsuarioPeloEmailAsync(string email);
        Task NovoUsuarioAsync(Usuario usuario);
    }
}
