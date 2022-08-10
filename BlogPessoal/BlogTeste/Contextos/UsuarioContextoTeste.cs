using BlogAPI.Src.Contextos;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogTeste.Contextos
{
    [TestClass]
    public class UsuarioContextoTeste
    {
        #region Atributos
        private BlogPessoalContexto _contexto;
        #endregion
        #region Métodos
        [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT1")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Matheus Carnizella",
                Email = "matheus@email.com",
                Senha = "134652",
                Foto = "URLFOTOMATHEUS",
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email == "matheus@email.com");
            Assert.IsNotNull(resultado);


        }
        [TestMethod]
        public void LerListaDeUsuariosRetornaTresUsuarios()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
 
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Voiidde",
                Email = "voiidde@email.com",
                Senha = "134652",
                Foto = "URLFOTOVOIIDDE",
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Michael Jackson",
                Email = "mj@email.com",
                Senha = "134652",
                Foto = "URLFOTOMICHAELJACKSON",
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Elvis Presley",
                Email = "elvis@email.com",
                Senha = "134652",
                Foto = "URLFOTOELVISPRESLEY",
            });
            _contexto.SaveChanges();
            var resultado = _contexto.Usuarios.ToList();
 
            Assert.AreEqual(3, resultado.Count);
        }
        [TestMethod]
        public void AtualizarUsuarioRetornaUsuarioAtualizado()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT3")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Manchinha",
                Email = "manchinha@email.com",
                Senha = "134652",
                Foto = "URLFOTOMANCHINHA",
            });
            _contexto.SaveChanges();
            
            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email == "manchinha@email.com");
            auxiliar.Nome = "Manchinha";
            _contexto.Usuarios.Update(auxiliar);
            _contexto.SaveChanges();
            
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Manchinha");
            
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void DeletaUsuarioRetornaUsuarioInesistente()
        {
           
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT4")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Son Goku",
                Email = "goku@email.com",
                Senha = "134652",
                Foto = "URLFOTOGOKU",
            });
            _contexto.SaveChanges();
            
            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email == "goku@email.com");
            _contexto.Usuarios.Remove(auxiliar);
            _contexto.SaveChanges();
            
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Son Goku");
            
            Assert.IsNull(resultado);
        }
        #endregion
    }
}