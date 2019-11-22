using AppRecipeS.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppRecipeS.DAO
{
    public class Connection
    {
        public static SQLiteConnection GetConn()
        {
            var strConn = new StringConnection();
            var conn = new SQLiteConnection(strConn.GetString(), false);

            return conn;
        }
        public void StartDB()
        {
            var conn = Connection.GetConn();
            conn.BeginTransaction();
            conn.CreateTable<ProdutoModel>();
            conn.Commit();
            conn.Close();

            Seeding();
        }

        public void Seeding()
        {
            var bancoInicial = new ProdutoDAO();
            var listaProdutos = bancoInicial.ReadAll();
            if (listaProdutos != null && listaProdutos.Count() > 0)
                return;

            var conn = Connection.GetConn();
            conn.BeginTransaction();

            DadosProduto();

            conn.Commit();
            conn.Close();
        }
        private void DadosProduto()
        {
            var produtodao = new ProdutoDAO();
            for (int i = 1; i < 11; i++)
            {
                produtodao.Inserir(new ProdutoModel()
                {
                    Id = i,
                    Titulo = $"Produto {i}",
                    Descricao = "Descrição",                  
                    Imagem = "http://picsum.photos/128/128/",
                    CategoriaCodigo = 0,                   
                });
            }
        }

        /*
         * //EXTRAS
         * static : "ÚNICO", não é replicado quando um objeto da classe é instanciado
         * Async  : força o metodo a não ser esperado. 
         * 
         * //MODIFICADORES DE ACESSO
             public ;   qualquer um acessa
             internal;  aqueles que estejam no mesmo assembly
             protected; ele e os filhos acessam
             private;   apenas ele mesmo acessa
             */

    }
}