using System;
using System.Runtime.Serialization;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos
        public Serie(int id, Tipo tipo, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano;
            retorno += "Excluído" + this.Excluido;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        internal int retornaId()
        {
            return this.Id;
        }
        
        public void Excluir()
        {
            this.Excluido = true;
        }
        public void Restaurar()
        {
            this.Excluido = false;
        }
    }
}